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

             
            return RedirectToPage("");
        }

        public async Task<IActionResult> OnGet(int? projektId)
        {
            if(projektId == null) return NotFound();

            BookingModel = new();

            var sælgerId = User.Identity.Name;

            BookingModel.ProjektId = projektId.Value;

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
