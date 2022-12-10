namespace TSEP.App.Pages.Projekt
{
    public class ProjektEditViewModel
    {
        public int Id { get; set; }
        public string ProjektName { get; set; }
        public DateTime StartDate { get; set; }
        public string KundeUserId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
