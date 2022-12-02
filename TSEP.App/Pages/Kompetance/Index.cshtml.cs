using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.StamData.Contract;
using TSEP.App.Infrastructure.StamData.Contract.Dto;

namespace TSEP.App.Pages.Kompetance
{
    public class IndexModel : PageModel
    {

        private readonly IStamDataService _stamdataService;

        public IndexModel(IStamDataService stamDataService)
        {
            _stamdataService = stamDataService;
        }

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string UserId { get; set; }
        [BindProperty]
        public byte[] RowVersion { get; set; }

        [BindProperty]
        public List<KompetanceIndexViewModel> IndexViewModel { get; set; } = new();
        [BindProperty]
        public List<int> KompetanceIder { get; set; } = new();

        public async Task<ActionResult> OnPostAsync()
        {
            //Find de Kompetancer som er blevet markeret via checkboxes
            var kompetanceDtoer = IndexViewModel.FindAll(k => KompetanceIder.Contains(k.Id)).Select(k => new AnsatKompetanceEditRequestDto { Id = k.Id, RowVersion = k.RowVersion}).ToList();
            
            //Konverter fra Bindproperties til AnsatEditRequestDto
            var dto = new AnsatEditRequestDto { Name = UserName,UserId = UserId,Kompetancer = kompetanceDtoer, RowVersion = RowVersion};

            //Send Edit request via StamdataService
            await _stamdataService.EditAnsat(dto);

            //Opdater siden med de nye informationer
            return RedirectToPage("/Kompetance/Index");
        }

        public async Task<ActionResult> OnGet()
        {
            //Hvis  brugeren ikke er logget ind, vis ikke siden
            if (User.Identity.Name == null) return NotFound();

            //Hent data på den Ansat samt alle kompetancer
            var kompetanceModel = await _stamdataService.GetAllKompetance();
            var ansatModel = await _stamdataService.GetAnsat(User.Identity.Name);

            //Hvis der ikke blev fundet nogen ansat, smid en Exception
            if (ansatModel == null) throw new Exception("Ansat findes ikke");

            //Gem relevant Ansat data i bindproperties'ne 
            UserName = ansatModel.Name;
            UserId = ansatModel.UserId;
            RowVersion = ansatModel.RowVersion;

            //Hvis ingen kompetance blev fundet, return til Page
            if (kompetanceModel == null) return Page();

            //Konverter fra KompetanceQueryResultDto til KompetanceIndexViewModel
            IndexViewModel = kompetanceModel.Select(k => new KompetanceIndexViewModel
                {
                    //Overfør data fra Dto til viewModel
                    Id = k.Id,
                    Description = k.Description,
                    RowVersion = k.RowVersion,

                    //Hvis den Ansatte indeholder kompetancen sæt enable til true
                    Enable = ansatModel.Kompetancer.Any(kmp => kmp.Id == k.Id),

            }).ToList();

            //HVis siden
            return Page();

        }
    }
}
