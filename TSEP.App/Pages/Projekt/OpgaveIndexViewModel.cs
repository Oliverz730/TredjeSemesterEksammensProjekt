namespace TSEP.App.Pages.Projekt
{
    public class OpgaveIndexViewModel
    {
        public int OpgaveTypeId { get; set; }
        public string AnsatId { get; set; }
        public string OpgaveTypeName { get; set; }
        public string AnsatName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public byte[] RowVersion { get; set; }
        public string Status { get; set; }

    }
}
