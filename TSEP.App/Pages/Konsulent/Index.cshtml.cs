using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Kalender.Contract;

namespace TSEP.App.Pages.Konsulent
{
    public class IndexModel : PageModel
    {
        private readonly IKalenderService _kalenderService;

        public IndexModel(IKalenderService kalenderService)
        {
            _kalenderService = kalenderService;
        }


        [BindProperty]
        public List<KonsulentIndexViewModel> IndexViewModels { get; set; } = new();

        public async Task<ActionResult> OnGet()
        {
            if (User.Identity.Name == null) return NotFound();

            var businessModels = await _kalenderService.GetAllOpgaverByAnsat(User.Identity.Name);

            IndexViewModels = businessModels.Select(oDto => new KonsulentIndexViewModel
            {
                ProjektId = oDto.ProjektId,
                AnsatId = oDto.AnsatId,
                Status = oDto.Status,
                StartTid = oDto.StartTid,
                SlutTid = oDto.SlutTid,
                OpgaveTypeId = oDto.OpgaveTypeId,

            }).ToList();


            return Page();
        }
    }
}
