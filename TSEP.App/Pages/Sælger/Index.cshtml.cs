using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Contract;
using TSEP.App.Infrastructure.Contract.Dto;

namespace TSEP.App.Pages.Sælger
{
    public class IndexModel : PageModel
    {
        private readonly IIgangsættelseService _igangsættelseService;

        public IndexModel(IIgangsættelseService igangsættelseService)
        {
            _igangsættelseService = igangsættelseService;
        }

        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public DateTime StartDate { get; set; }
        [BindProperty]
        public DateTime EndDate { get; set; }
        [BindProperty]
        public string EstimatedTime { get; set; }
        [BindProperty]
        public string ActualEstimated { get; set; }
        [BindProperty]
        public string SælgerUserId { get; set; }
        [BindProperty]
        public string KundeUserId { get; set; }
        [BindProperty]
        public byte[] RowVersion { get; set; }


        [BindProperty]
        public List<ProjektIndexViewModel> IndexViewModel { get; set; } = new();


        //public async Task<ActionResult> OnPostAsync() { await _igangsættelseService.EditProjekt(dto); }
        public async Task<ActionResult> OnGet()
        {
            var businessModel = await _igangsættelseService.GetAllProjekt(User.Identity.Name);
            //var projektModel = await _igangsættelseService.GetProjekt();  // Skal have et indtastet input fra siden



            return Page();
        }
    }
}
