using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.StamData.Contract;
using TSEP.App.Infrastructure.StamData.Contract.Dto;

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
            //Hvis Input er invalid returner siden
            if (!ModelState.IsValid) return Page();

            //Opret KompetanceCreateRequestDto med input dataene
            var dto = new KompetanceCreateRequestDto { Description = Input.Description };

            //Send Create Request med de givne data
            await _stamdataService.CreateKompetance(dto);

            //Redirect til Kompetance index siden
            return RedirectToPage("/Kompetance/Index");
        }

        public void OnGet()
        { }
    }
}
