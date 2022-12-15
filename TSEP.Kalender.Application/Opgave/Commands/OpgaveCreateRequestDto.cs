
namespace TSEP.Kalender.Application.Opgave.Commands
{
    public class OpgaveCreateRequestDto
    {
        public int ProjektId { get; set; }
        public int OpgaveTypeId { get; set; }
        public string AnsatId { get; set; }
        public string Status { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
        //Create har ikke en RowVersion, da det kun kræves på handlinger på eksisterende rækker i databasen
    }
}
