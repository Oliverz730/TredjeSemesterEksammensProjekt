using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Contract;
using TSEP.App.Infrastructure.Contract.Dto;

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
            var kompetanceDtoer = IndexViewModel.FindAll(k => KompetanceIder.Contains(k.Id)).Select(k => new AnsatKompetanceEditRequestDto { Id = k.Id, RowVersion = k.RowVersion}).ToList();
            var dto = new AnsatEditRequestDto { Name = UserName,UserId = UserId,Kompetancer = kompetanceDtoer, RowVersion = RowVersion};

            await _stamdataService.EditAnsat(dto);

            return RedirectToPage("/Kompetance/Index");
        }

        public async Task<ActionResult> OnGet()
        {

            if (User.Identity.Name == null) return NotFound();
            var businessModel = await _stamdataService.GetAllKompetance();
            var ansatModel = await _stamdataService.GetAnsat(User.Identity.Name);

            if (ansatModel == null) throw new Exception("Ansat findes ikke");

            UserName = ansatModel.Name;
            UserId = ansatModel.UserId;
            RowVersion = ansatModel.RowVersion;

            if (businessModel == null)
            {

            }
            else
            {
                IndexViewModel = businessModel.Select(k => new KompetanceIndexViewModel
                {
                    Id = k.Id,
                    Desciption = k.Description,
                    Enable = ansatModel.Kompetancer.Any(kmp => kmp.Id == k.Id),
                    RowVersion = k.RowVersion
                })
                    .ToList();
            }

            return Page();

        }
    }
}
