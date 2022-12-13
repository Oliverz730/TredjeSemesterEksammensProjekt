using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Kalender.Contract;
using TSEP.App.Infrastructure.StamData.Contract;

namespace TSEP.App.Pages.Kalender
{
    public class IndexModel : PageModel
    {
        private readonly IKalenderService _kalenderService;
        private readonly IStamDataService _stamDataService;

        public IndexModel(IKalenderService kalenderService, IStamDataService stamDataService)
        {
            _kalenderService = kalenderService;
            _stamDataService = stamDataService;
        }

        [BindProperty]
        public List<BookingIndexViewModel> BookingIndexList { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
            var ansatte = await _stamDataService.GetAllAnsat();
            var bookings = await _kalenderService.GetAllBookings();

            BookingIndexList = bookings.Select(b => new BookingIndexViewModel
            {
                Id = b.Id,
                AnsatNavn = ansatte.First(a => a.UserId == b.MedarbejderId).Name,
                EndDate = b.EndDate,
                Rowversion = b.RowVersion,
                StartDate = b.StartDate
            }).ToList();

            BookingIndexList = BookingIndexList.OrderBy(b => b.StartDate).ToList();

            return Page();
        }
    }
}
