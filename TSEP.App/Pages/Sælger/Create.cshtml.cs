using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Contract;
using System.ComponentModel.DataAnnotations;
using TSEP.App.Infrastructure.Contract.Dto;

namespace TSEP.App.Pages.Sælger
{
    public class CreateModel : PageModel
    {
        private readonly IIgangsættelseService _igangsættelseService;
        public CreateModel(IIgangsættelseService igangsættelseService)
        {
            _igangsættelseService = igangsættelseService;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            [DataType(DataType.DateTime)]
            [Display(Name = "Start DateTime")]
            public DateTime StartDateTime { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var dto = new ProjektCreateRequestDto { 
                StartDate = Input.StartDateTime
            };
            await _igangsættelseService.CreateProjekt(dto);

            return RedirectToPage("/Kompetance/Index");
        }
        public void OnGet()
        {
        }
    }
}
//public DateTime StartDate { get; set; }
//public DateTime EndDate { get; set; }
//public string EstimatedTime { get; set; }
//public string ActualEstimated { get; set; }
//public string SælgerUserId { get; set; }
//public string KundeUserId { get; set; }
//public byte[] RowVersion { get; set; }