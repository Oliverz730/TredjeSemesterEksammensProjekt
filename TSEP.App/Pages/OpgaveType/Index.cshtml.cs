using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Igangs�ttelse.Contract;
using TSEP.App.Infrastructure.StamData.Contract;

namespace TSEP.App.Pages.OpgaveType
{
    public class IndexModel : PageModel
    {
        private readonly IIgangs�ttelseService _igangs�ttelseService;
        private readonly IStamDataService _stamDataService;

        public IndexModel(IIgangs�ttelseService igangs�ttelseService, IStamDataService stamDataService)
        {
            _igangs�ttelseService = igangs�ttelseService;
            _stamDataService = stamDataService;
        }

        public List<OpgaveTypeIndexViewModel> OpgaveTypeList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var kompetanceList = await _stamDataService.GetAllKompetance();
            OpgaveTypeList = (await _igangs�ttelseService.GetAllOpgaveType()).Select(o => new OpgaveTypeIndexViewModel
            {
                Id = o.Id,
                Beskrivelse = o.Beskrivelse,
                KompetanceBeskrivelse = kompetanceList.First(k => k.Id == o.KompetanceId).Description,
            }).ToList();

            return Page();
        }
    }
}
