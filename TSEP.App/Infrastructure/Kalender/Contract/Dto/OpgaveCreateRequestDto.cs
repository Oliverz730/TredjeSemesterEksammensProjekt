namespace TSEP.App.Infrastructure.Kalender.Contract.Dto
{
    public class OpgaveCreateRequestDto
    {
        public int ProjektId { get; set; }
        public int OpgaveTypeId { get; set; }
        public string AnsatId { get; set; }
        public string Status { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
    }
}
