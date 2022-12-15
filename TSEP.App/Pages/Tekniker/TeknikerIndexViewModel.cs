namespace TSEP.App.Pages.Tekniker
{
    public class TeknikerIndexViewModel
    {
        public int ProjektId { get; set; }
        public string OpgaveTypeBeskrivelse { get; set; }
        public string AnsatId { get; set; }
        public string Status { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
