using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Igangsættelse.Contract;

namespace TSEP.App.Pages.Kunde
{
    public class IndexModel : PageModel
    {
        private readonly IIgangsættelseService _igangsættelseService;

        public IndexModel(IIgangsættelseService igangsættelseService)
        {
            _igangsættelseService = igangsættelseService;
        }


        [BindProperty]
        public List<KundeProjektIndexViewModel> IndexViewModels { get; set; } = new();

        public async Task<ActionResult> OnGet()
        {
            if (User.Identity.Name == null) return NotFound();

            var businessModels = await _igangsættelseService.GetAllProjektByKunde(User.Identity.Name);

            IndexViewModels = businessModels.Select(pDto => new KundeProjektIndexViewModel
            {
                ProjektNavn = pDto.ProjektName,
                StartDate = pDto.StartDate,
                EndDate = pDto.EndDate
            }).ToList();


            return Page();
        }
    }
}
