using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSEP.App.Infrastructure.Igangsættelse.Contract;
using TSEP.App.Infrastructure.Igangsættelse.Contract.Dto;

namespace TSEP.App.Pages.Booking
{
    public class CreateModel : PageModel
    {
        private readonly IIgangsættelseService _igangsættelseService;

        public CreateModel(IIgangsættelseService igangsættelseService)
        {
            _igangsættelseService = igangsættelseService;
        }

        [BindProperty]
        public BookingCreateViewModel BookingModel { get; set; }
        [BindProperty]
        public List<SelectListItem> OpgaveTypeSelect { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("./AssignAnsat", BookingModel);
        }

        public async Task<IActionResult> OnGetAsync(int? projektId, DateTime? startDate)
        {
            if(projektId == null) return NotFound();
            if (startDate == null) return NotFound();
            var sælgerId = User.Identity.Name;

            BookingModel = new BookingCreateViewModel
            {
                ProjektId = projektId.Value,
                StartTid = startDate.Value
            };

            var opgaveTyper = await _igangsættelseService.GetAllOpgaveType();

            OpgaveTypeSelect = opgaveTyper.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Beskrivelse
            }).ToList();

            return Page();
        }
    }
}
