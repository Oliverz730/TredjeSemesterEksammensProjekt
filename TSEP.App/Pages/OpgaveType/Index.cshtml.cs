using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Igangsættelse.Contract;
using TSEP.App.Infrastructure.StamData.Contract;

namespace TSEP.App.Pages.OpgaveType
{
    public class IndexModel : PageModel
    {
        private readonly IIgangsættelseService _igangsættelseService;
        private readonly IStamDataService _stamDataService;

        public IndexModel(IIgangsættelseService igangsættelseService, IStamDataService stamDataService)
        {
            _igangsættelseService = igangsættelseService;
            _stamDataService = stamDataService;
        }

        public List<OpgaveTypeIndexViewModel> OpgaveTypeList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var kompetanceList = await _stamDataService.GetAllKompetance();
            OpgaveTypeList = (await _igangsættelseService.GetAllOpgaveType()).Select(o => new OpgaveTypeIndexViewModel
            {
                Id = o.Id,
                Beskrivelse = o.Beskrivelse,
                KompetanceBeskrivelse = kompetanceList.First(k => k.Id == o.KompetanceId).Description,
            }).ToList();

            return Page();
        }
    }
}
