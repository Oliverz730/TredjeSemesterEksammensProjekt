namespace TSEP.App.Pages.Konverter
{
    public class KonverterIndexViewModel
    {
        public int ProjektId { get; set; }
        public int OpgaveTypeId { get; set; }
        public string AnsatId { get; set; }
        public string Status { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
