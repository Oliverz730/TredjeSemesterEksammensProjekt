using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Contract;
using TSEP.App.Infrastructure.Contract.Dto;

namespace TSEP.App.Pages.Kompetance
{
    public class CreateModel : PageModel
    {

        private readonly IStamDataService _stamdataService;

        public CreateModel(IStamDataService stamDataService)
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

            return RedirectToPage("/Kompetance/Index");
        }

        public void OnGet()
        {


        }
    }
}
