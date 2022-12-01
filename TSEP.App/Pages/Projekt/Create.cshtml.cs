using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Contract;
using TSEP.App.Infrastructure.Contract.Dto;
using System.ComponentModel.DataAnnotations;

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
            var dto = new ProjektCreateRequestDto
            {
                KundeUserId= Input.KundeUserId,
                SælgerUserId= Input.SælgerUserId,
                EndDate= Input.EndDate,
                StartDate= Input.StartDate,
                ActualEstimated= Input.ActualEstimated,
                EstimatedTime= Input.EstimatedTime,
            };
            await _igangsættelseService.CreateProjekt(dto);

            return RedirectToPage("Sælger/Index");
        }

        public void OnGet()
        {
        }
    }
}
