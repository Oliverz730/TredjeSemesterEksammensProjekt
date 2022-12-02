namespace TSEP.App.Pages.Projekt
{
    public class ProjektCreateViewModel
    {
        public string ProjektName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EstimatedTime { get; set; }
        public string ActualEstimated { get; set; }
        public string KundeUserId { get; set; }
    }
}
