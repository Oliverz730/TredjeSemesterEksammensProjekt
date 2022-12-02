using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Igangsættelse.Contract;

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
        public List<ProjektIndexViewModel> IndexViewModels { get; set; } = new();

        //public async Task<ActionResult> OnPostAsync() { await _igangsættelseService.EditProjekt(dto); }
        public async Task<ActionResult> OnGet()
        {
            if (User.Identity.Name == null) return NotFound();

            var businessModels = await _igangsættelseService.GetAllProjekt(User.Identity.Name);
            //var projektModel = await _igangsættelseService.GetProjekt();  // Skal have et indtastet input fra siden

            IndexViewModels = businessModels.Select(pDto => new ProjektIndexViewModel
            {
                RowVersion = pDto.RowVersion,
                ProjektName = pDto.ProjektName,
                SælgerUserId = pDto.SælgerUserId,
                EndDate = pDto.EndDate,
                StartDate = pDto.StartDate,
                Id = pDto.Id,
                EstimatedTime = pDto.EstimatedTime,
                ActualEstimated = pDto.ActualEstimated,
                KundeUserId = pDto.KundeUserId
                
            }).ToList();
            

            return Page();
        }
    }
}
