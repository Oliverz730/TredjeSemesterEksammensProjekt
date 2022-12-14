using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using TSEP.App.Infrastructure.Igangsættelse.Contract;
using TSEP.App.Infrastructure.Igangsættelse.Contract.Dto;
using TSEP.App.Infrastructure.Kalender.Contract;
using TSEP.App.Infrastructure.Kalender.Contract.Dto;
using TSEP.App.Infrastructure.StamData.Contract;
using TSEP.App.Infrastructure.StamData.Contract.Dto;

namespace TSEP.App.Pages.Booking
{
    public class AssignAnsatModel : PageModel
    {
        private readonly IKalenderService _kalenderService;
        private readonly IStamDataService _stamDataService;
        private readonly IIgangsættelseService _igangsættelseService;

        public AssignAnsatModel(IKalenderService kalenderService, IStamDataService stamDataService, IIgangsættelseService igangsættelseService)
        {
            _kalenderService = kalenderService;
            _stamDataService = stamDataService;
            _igangsættelseService = igangsættelseService;
        }


        [BindProperty] 
        public BookingCreateViewModel BookingModel { get; set; }
        [BindProperty]
        public List<AnsatBookingViewModel> AnsatSelectList { get; set; }

        public async Task<IActionResult> OnGetAsync( BookingCreateViewModel? model)
        {
            BookingModel = model;

            var opgaveType = await _igangsættelseService.GetOpgaveType(BookingModel.OpgaveTypeId);

            if (opgaveType == null) return NotFound();

            var ansatte = await _stamDataService.GetAllAnsat();

            if(ansatte == null) return NotFound();

            var bookings = await _kalenderService.GetAllBookings();

            AnsatSelectList = FindTilrådigeAnsatte(opgaveType,ansatte,bookings).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var updatedBookingStart = AnsatSelectList.Find(a => BookingModel.AnsatId == a.AnsatId).StartTid;
            var updatedBookingSlut = updatedBookingStart + (BookingModel.SlutTid - BookingModel.StartTid); 

            await _kalenderService.CreateBooking(new BookingCreateRequestDto
            {
                MedarbejderId = BookingModel.AnsatId,
                EndDate = updatedBookingSlut,
                StartDate = updatedBookingStart
            });

            await _kalenderService.CreateOpgave(new OpgaveCreateRequestDto
            {
                StartTid = updatedBookingStart,
                SlutTid = updatedBookingSlut,
                AnsatId = BookingModel.AnsatId,
                OpgaveTypeId = BookingModel.OpgaveTypeId,
                ProjektId = BookingModel.ProjektId,
                Status = "TEST"
            });

            return RedirectToPage("/Projekt/Edit",new{id = BookingModel.ProjektId});
        }


        IEnumerable<AnsatBookingViewModel> FindTilrådigeAnsatte(
            OpgaveTypeQueryResultDto opgaveType, 
            IEnumerable<AnsatQueryResultDto>? ansatte, 
            IEnumerable<BookingQueryResultDto>? bookings
            )
        {

            var OpgaveDuration = TimeSpan.FromDays(1);

            BookingModel.SlutTid = BookingModel.StartTid + OpgaveDuration;

            var ansatteMedKompetancen = ansatte.Where(
                a => a.Kompetancer.Any(
                    k => k.Id == opgaveType.KompetanceId
                         ));

            if (bookings.Count() == 0)
                return ansatteMedKompetancen.Select(a => new AnsatBookingViewModel
                {
                    AnsatId = a.UserId,
                    Navn = a.Name,
                    StartTid = BookingModel.StartTid
                });

            var bookingEfter = bookings.Where(
                b => b.EndDate > BookingModel.StartTid);

            if (bookingEfter.Count() == 0)
                return ansatteMedKompetancen.Select(a => new AnsatBookingViewModel
                {
                    AnsatId = a.UserId,
                    Navn = a.Name,
                    StartTid = BookingModel.StartTid
                });

            var bookingsOverAnsatte = bookingEfter.Where(
                b => ansatteMedKompetancen.Any(
                    a => a.UserId == b.MedarbejderId
                    ));
            if (bookingsOverAnsatte.Count() == 0)
                return ansatteMedKompetancen.Select(a => new AnsatBookingViewModel
                {
                    AnsatId = a.UserId,
                    Navn = a.Name,
                    StartTid = BookingModel.StartTid
                });

            var orderedBookingOverAnsatte = bookingsOverAnsatte.OrderBy
                (b => b.StartDate);

            var orderedTidBetweenBookings = new List<BookingQueryResultDto>();
            var orderedBookingList = orderedBookingOverAnsatte.ToList();

            foreach (var ansat in ansatteMedKompetancen)
            {
                var ansatOrderedBooking = orderedBookingList.Where(b => b.MedarbejderId == ansat.UserId).ToList();
                if (ansatOrderedBooking.Count == 0)
                {
                    orderedTidBetweenBookings.Add(new BookingQueryResultDto
                    {
                        MedarbejderId = ansat.UserId,
                        StartDate = BookingModel.StartTid,
                        EndDate = BookingModel.SlutTid
                    });
                    continue;
                }
                
                for (int i = 0; i < ansatOrderedBooking.Count; i++)
                {
                    int next = i + 1;
                    var BetweenTid = new BookingQueryResultDto
                    {
                        MedarbejderId = ansat.UserId,
                        RowVersion = ansatOrderedBooking[i].RowVersion,
                        StartDate = ansatOrderedBooking[i].EndDate
                    };

                    if (next == ansatOrderedBooking.Count())
                    {
                        BetweenTid.EndDate = BetweenTid.StartDate + OpgaveDuration;
                        orderedTidBetweenBookings.Add(BetweenTid);
                    }
                    else
                    {
                        BetweenTid.EndDate = orderedBookingList[next].StartDate;
                        orderedTidBetweenBookings.Add(BetweenTid);
                    }

                }
            }

            var førsteLedigeTid = ansatteMedKompetancen.Select(
                a => orderedTidBetweenBookings.First(
                    b =>
                    {
                        bool o = b.EndDate >= b.StartDate + OpgaveDuration;

                        return b.MedarbejderId == a.UserId && o;
                    }));

            return førsteLedigeTid.Select(b => new AnsatBookingViewModel
            {
                StartTid = b.StartDate,
                AnsatId = b.MedarbejderId,
                Navn = ansatteMedKompetancen.First(a => a.UserId == b.MedarbejderId).Name
            });
        }
    }
}
