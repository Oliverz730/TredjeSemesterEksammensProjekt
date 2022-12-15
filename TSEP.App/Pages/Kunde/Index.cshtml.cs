using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Igangs�ttelse.Contract;

namespace TSEP.App.Pages.Kunde
{
    public class IndexModel : PageModel
    {
        private readonly IIgangs�ttelseService _igangs�ttelseService;

        public IndexModel(IIgangs�ttelseService igangs�ttelseService)
        {
            _igangs�ttelseService = igangs�ttelseService;
        }


        [BindProperty]
        public List<KundeProjektIndexViewModel> IndexViewModels { get; set; } = new();

        public async Task<ActionResult> OnGet()
        {
            if (User.Identity.Name == null) return NotFound();

            var businessModels = await _igangs�ttelseService.GetAllProjektByKunde(User.Identity.Name);

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
