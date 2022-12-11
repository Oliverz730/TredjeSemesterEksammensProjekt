using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TSEP.App.Infrastructure.Igangs�ttelse.Contract;
using TSEP.App.Infrastructure.Kalender.Contract;
using TSEP.App.Infrastructure.StamData.Contract;

namespace TSEP.App.Pages.Projekt
{
    public class EditModel : PageModel
    {

        private readonly IIgangs�ttelseService _igangs�ttelseService;
        private readonly IKalenderService _kalenderService;
        private readonly IStamDataService _stamDataService;

        public EditModel(IIgangs�ttelseService igangs�ttelseService, IKalenderService kalenderService, IStamDataService stamDataService)
        {
            _igangs�ttelseService = igangs�ttelseService;
            _kalenderService = kalenderService;
            _stamDataService = stamDataService;

        }

        [BindProperty]
        public ProjektEditViewModel Input { get; set; }
        [BindProperty]
        public DateTime nextOpgaveStartTime { get; set; }
        [BindProperty]
        public List<OpgaveIndexViewModel> OpgaveIndexes { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("Booking/Create", new{ startDate = nextOpgaveStartTime, projektId = Input.Id});
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();
            var projekt = await _igangs�ttelseService.GetProjekt(id.Value,User.Identity.Name);

            if (projekt == null) return NotFound();
            Input = new ProjektEditViewModel
            {
                Id = projekt.Id,
                KundeUserId = projekt.KundeUserId,
                ProjektName = projekt.ProjektName,
                RowVersion = projekt.RowVersion,
                StartDate = projekt.StartDate
            };

            var opgaveDtoer = await _kalenderService.GetAllOpgaverByProjekt(projekt.Id);
            var ansatDtoer = await _stamDataService.GetAllAnsat();
            var opgaveTypeDtoer = await _igangs�ttelseService.GetAllOpgaveType();
            if(opgaveDtoer.Count() > 0) nextOpgaveStartTime = opgaveDtoer.MaxBy(o => o.SlutTid).SlutTid;
            else nextOpgaveStartTime = DateTime.Today;

            OpgaveIndexes = opgaveDtoer.Select(o =>
            
                new OpgaveIndexViewModel
                {
                    AnsatId = o.AnsatId,
                    OpgaveTypeId = o.OpgaveTypeId,
                    EndTime = o.SlutTid,
                    StartTime = o.StartTid,
                    Status = o.Status,
                    RowVersion = o.RowVersion,
                    AnsatName = ansatDtoer.First(a => a.UserId == o.AnsatId).Name,
                    OpgaveTypeName = opgaveTypeDtoer.First(oT => oT.Id == o.OpgaveTypeId).Beskrivelse
                }
            ).ToList();

            return Page();

        }
    }
}
