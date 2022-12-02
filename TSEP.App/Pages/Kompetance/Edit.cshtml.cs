using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.StamData.Contract;
using TSEP.App.Infrastructure.StamData.Contract.Dto;


namespace TSEP.App.Pages.Kompetance
{
    public class EditModel : PageModel
    {
        private readonly IStamDataService _stamDataService;

        public EditModel(IStamDataService stamDataService)
        {
            _stamDataService = stamDataService;
        }

        [BindProperty] 
        public KompetanceEditViewModel KompetanceEditModel { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null) return NotFound();

            var dto = await _stamDataService.GetKompetance(id.Value);

            if (dto == null) return NotFound();

            KompetanceEditModel = new KompetanceEditViewModel
            {
                Description = dto.Description,
                Id = dto.Id,
                RowVersion = dto.RowVersion,
            };
            
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                await _stamDataService.EditKompetance(new KompetanceEditRequestDto
                {
                    Description = KompetanceEditModel.Description,
                    Id = KompetanceEditModel.Id,
                    RowVersion = KompetanceEditModel.RowVersion,
                });
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty,e.Message);
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
