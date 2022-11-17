using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TredjeSemesterEksammensProjekt.Infrastructure.Contract.Dto;
using TredjeSemesterEksammensProjekt.Infrastructure.Contract;

namespace TredjeSemesterEksammensProjekt.Pages.Create.Kompetance
{
    public class IndexModel : PageModel
    {

        private readonly IStamDataService _stamdataService;

        public IndexModel(IStamDataService stamDataService)
        {
            _stamdataService = stamDataService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Kompetance Beskrivelse")]
            public string Description { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var dto = new KompetanceCreateRequestDto { Description = Input.Description };
            await _stamdataService.CreateKompetance(dto);

            return RedirectToPage("/Index");
        }

        public void OnGet()
        {


        }
    }
}
