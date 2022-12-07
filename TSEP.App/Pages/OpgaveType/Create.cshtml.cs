using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSEP.App.Infrastructure.Igangsættelse.Contract;
using TSEP.App.Infrastructure.Igangsættelse.Contract.Dto;
using TSEP.App.Infrastructure.StamData.Contract;

namespace TSEP.App.Pages.OpgaveType
{
    public class CreateModel : PageModel
    {
        private readonly IIgangsættelseService _igangsættelseService;
        private readonly IStamDataService _stamDataService;

        public CreateModel(IIgangsættelseService igangsættelseService, IStamDataService stamDataService)
        {
            _igangsættelseService = igangsættelseService;
            _stamDataService = stamDataService;
        }

        [BindProperty]
        public OpgaveTypeCreateViewModel Input { get; set; }

        public List<SelectListItem> KompetanceList { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _igangsættelseService.CreateOpgaveType(new OpgaveTypeCreateRequestDto
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
