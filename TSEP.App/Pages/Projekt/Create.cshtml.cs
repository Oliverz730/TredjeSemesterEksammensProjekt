using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Igangs�ttelse.Contract;
using System.ComponentModel.DataAnnotations;
using TSEP.App.Infrastructure.Igangs�ttelse.Contract.Dto;

namespace TSEP.App.Pages.Projekt
{
    public class CreateModel : PageModel
    {
        private readonly IIgangs�ttelseService _igangs�ttelseService;
        public CreateModel(IIgangs�ttelseService igangs�ttelseService)
        {
            _igangs�ttelseService = igangs�ttelseService;
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
                S�lgerUserId= User.Identity.Name,
                EndDate= Input.EndDate,
                StartDate= Input.StartDate,
                ActualEstimated= Input.ActualEstimated,
                EstimatedTime= Input.EstimatedTime,
            };
            await _igangs�ttelseService.CreateProjekt(dto);

            return RedirectToPage("/S�lger/Index");
        }

        public void OnGet()
        {
        }
    }
}
