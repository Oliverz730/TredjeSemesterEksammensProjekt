using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Igangs�ttelse.Contract;

namespace TSEP.App.Pages.OpgaveType
{
    public class IndexModel : PageModel
    {
        private readonly IIgangs�ttelseService _igangs�ttelseService;

        public IndexModel(IIgangs�ttelseService igangs�ttelseService)
        {
            _igangs�ttelseService = igangs�ttelseService;
        }

        public List<OpgaveTypeIndexViewModel> OpgaveTypeList { get; set; }

        public void OnGet()
        {
            OpgaveTypeList = new();
        }
    }
}
