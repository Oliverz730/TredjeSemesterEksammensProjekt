using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Igangsættelse.Contract;

namespace TSEP.App.Pages.OpgaveType
{
    public class IndexModel : PageModel
    {
        private readonly IIgangsættelseService _igangsættelseService;

        public IndexModel(IIgangsættelseService igangsættelseService)
        {
            _igangsættelseService = igangsættelseService;
        }

        public List<OpgaveTypeIndexViewModel> OpgaveTypeList { get; set; }

        public void OnGet()
        {
            OpgaveTypeList = new();
        }
    }
}
