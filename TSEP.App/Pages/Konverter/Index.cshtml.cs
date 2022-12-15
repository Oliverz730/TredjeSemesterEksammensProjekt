using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Kalender.Contract;
using TSEP.App.Infrastructure.Igangs�ttelse.Contract;

namespace TSEP.App.Pages.Konverter
{
    public class IndexModel : PageModel
    {
        private readonly IKalenderService _kalenderService;
        private readonly IIgangs�ttelseService _igangs�ttelseService;

        public IndexModel(IKalenderService kalenderService, IIgangs�ttelseService igangs�ttelseService)
        {
            _kalenderService = kalenderService;
            _igangs�ttelseService = igangs�ttelseService;
        }


        [BindProperty]
        public List<KonverterIndexViewModel> IndexViewModels { get; set; } = new();

        public async Task<ActionResult> OnGet()
        {
            if (User.Identity.Name == null) return NotFound();

            var businessModels = await _kalenderService.GetAllOpgaverByAnsat(User.Identity.Name);

            var opgavetyper = await _igangs�ttelseService.GetAllOpgaveType();

            IndexViewModels = businessModels.Select(oDto => new KonverterIndexViewModel
            {
                ProjektId = oDto.ProjektId,
                AnsatId = oDto.AnsatId,
                Status = oDto.Status,
                StartTid = oDto.StartTid,
                SlutTid = oDto.SlutTid,
                OpgaveTypeBeskrivelse = opgavetyper.First(o => o.Id == oDto.OpgaveTypeId).Beskrivelse

            }).ToList();


            return Page();
        }
    }
}
