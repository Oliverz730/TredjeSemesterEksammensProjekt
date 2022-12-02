using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Igangsættelse.Contract;
using System.ComponentModel.DataAnnotations;
using TSEP.App.Infrastructure.Igangsættelse.Contract.Dto;

namespace TSEP.App.Pages.Projekt
{
    public class CreateModel : PageModel
    {
        private readonly IIgangsættelseService _igangsættelseService;
        public CreateModel(IIgangsættelseService igangsættelseService)
        {
            _igangsættelseService = igangsættelseService;
        }

        [BindProperty]
        public ProjektCreateViewModel Input { get; set; }

        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var dto = new ProjektCreateRequestDto
            {
                ProjektName = Input.ProjektName,
                KundeUserId= Input.KundeUserId,
                SælgerUserId= User.Identity.Name,
                EndDate= Input.EndDate,
                StartDate= Input.StartDate,
                ActualEstimated= Input.ActualEstimated,
                EstimatedTime= Input.EstimatedTime,
            };
            await _igangsættelseService.CreateProjekt(dto);

            return RedirectToPage("/Sælger/Index");
        }

        public void OnGet()
        {
        }
    }
}
