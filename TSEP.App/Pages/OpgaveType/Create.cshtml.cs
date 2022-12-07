using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSEP.App.Infrastructure.Igangs�ttelse.Contract;
using TSEP.App.Infrastructure.Igangs�ttelse.Contract.Dto;
using TSEP.App.Infrastructure.StamData.Contract;

namespace TSEP.App.Pages.OpgaveType
{
    public class CreateModel : PageModel
    {
        private readonly IIgangs�ttelseService _igangs�ttelseService;
        private readonly IStamDataService _stamDataService;

        public CreateModel(IIgangs�ttelseService igangs�ttelseService, IStamDataService stamDataService)
        {
            _igangs�ttelseService = igangs�ttelseService;
            _stamDataService = stamDataService;
        }

        [BindProperty]
        public OpgaveTypeCreateViewModel Input { get; set; }

        public List<SelectListItem> KompetanceList { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _igangs�ttelseService.CreateOpgaveType(new OpgaveTypeCreateRequestDto
            {
                Beskrivelse = Input.Beskrivelse,
                KompetanceId = Input.KompetanceId
            });

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var kompetancer = await _stamDataService.GetAllKompetance();

            KompetanceList = kompetancer.Select(k => new SelectListItem
            {
                Text = k.Description,
                Value = k.Id.ToString()
            }).ToList();

            return Page();
        }
    }
}
