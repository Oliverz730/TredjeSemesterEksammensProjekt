using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TredjeSemesterEksammensProjekt.Infrastructure.Contract.Dto;
using TredjeSemesterEksammensProjekt.Infrastructure.Contract;
using System.Security.Claims;

namespace TredjeSemesterEksammensProjekt.Pages.Kompetance
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
        public List<KompetanceIndexViewModel> IndexViewModel { get; set; } = new();

        public async Task OnGet()
        {
            var businessModel = await _stamdataService.GetAllKompetance();
            var ansatModel = await _stamdataService.GetAnsat(User.Identity.Name);

            if (ansatModel == null) throw new Exception("Ansat findes ikke");

            UserName = ansatModel.Name;

            if (businessModel == null)
            {

            }
            else
            {
                IndexViewModel = businessModel.Select(k => new KompetanceIndexViewModel
                {
                    Desciption = k.Description,
                    Enable = ansatModel.Kompetancer.Contains(new AnsatKompetanceQueryResultDto { Description = k.Description })
                })
                    .ToList();
            }

        }
    }
}
