using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using TSEP.App.Infrastructure.Igangs�ttelse.Contract;
using TSEP.App.Infrastructure.Igangs�ttelse.Contract.Dto;
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
        private readonly IIgangs�ttelseService _igangs�ttelseService;

        public AssignAnsatModel(IKalenderService kalenderService, IStamDataService stamDataService, IIgangs�ttelseService igangs�ttelseService)
        {
            _kalenderService = kalenderService;
            _stamDataService = stamDataService;
            _igangs�ttelseService = igangs�ttelseService;
        }


        [BindProperty] 
        public BookingCreateViewModel BookingModel { get; set; }
        [BindProperty]
        public List<AnsatBookingViewModel> AnsatSelectList { get; set; }

        public async Task<IActionResult> OnGetAsync( BookingCreateViewModel? model)
        {
            BookingModel = model;

            var opgaveType = await _igangs�ttelseService.GetOpgaveType(BookingModel.OpgaveTypeId);

            if (opgaveType == null) return NotFound();

            var ansatte = await _stamDataService.GetAllAnsat();

            if(ansatte == null) return NotFound();

            var bookings = await _kalenderService.GetAllBookings();

            AnsatSelectList = FindTilr�digeAnsatte(opgaveType,ansatte,bookings).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _kalenderService.CreateBooking(new BookingCreateRequestDto
            {
                MedarbejderId = BookingModel.AnsatId,
                EndDate = BookingModel.SlutTid,
                StartDate = BookingModel.StartTid
            });

            await _kalenderService.CreateOpgave(new OpgaveCreateRequestDto
            {
                StartTid = BookingModel.StartTid,
                SlutTid = BookingModel.SlutTid,
                AnsatId = BookingModel.AnsatId,
                OpgaveTypeId = BookingModel.OpgaveTypeId,
                ProjektId = BookingModel.ProjektId,
                Status = "TEST"
            });

            return Redirect("/Projekt/Create");
        }


        IEnumerable<AnsatBookingViewModel> FindTilr�digeAnsatte(
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
                var ansatOrderedBooking = orderedBookingList.Where(b => b.MedarbejderId == ansat.UserId);
                if (ansatOrderedBooking.Count() == 0)
                {
                    orderedTidBetweenBookings.Add(new BookingQueryResultDto
                    {
                        MedarbejderId = ansat.UserId,
                        StartDate = BookingModel.StartTid,
                        EndDate = BookingModel.SlutTid
                    });
                    continue;
                }
                
                for (int i = 0; i < ansatOrderedBooking.Count(); i++)
                {
                    int next = i + 1;
                    var BetweenTid = new BookingQueryResultDto
                    {
                        MedarbejderId = ansat.UserId,
                        RowVersion = orderedBookingList[i].RowVersion,
                        StartDate = orderedBookingList[i].EndDate
                    };

                    if (next == ansatOrderedBooking.Count())
                    {
                        BetweenTid.EndDate = BetweenTid.StartDate + OpgaveDuration;
                        orderedTidBetweenBookings.Add(BetweenTid);
                        break;
                    }
                    else
                    {
                        BetweenTid.EndDate = orderedBookingList[next].StartDate;
                        orderedTidBetweenBookings.Add(BetweenTid);
                        break;
                    }

                }
            }

            var f�rsteLedigeTid = ansatteMedKompetancen.Select(
                a => orderedTidBetweenBookings.First(
                    b => b.MedarbejderId == a.UserId && (b.EndDate - b.StartDate) <= OpgaveDuration));

            return f�rsteLedigeTid.Select(b => new AnsatBookingViewModel
            {
                StartTid = b.StartDate,
                AnsatId = b.MedarbejderId,
                Navn = ansatteMedKompetancen.First(a => a.UserId == b.MedarbejderId).Name
            });
        }
    }
}
