namespace TSEP.App.Infrastructure.Contract.Dto
{
    public class ProjektQueryResultDto
    {
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EstimatedTime { get; set; }
        public string ActualEstimated { get; set; }
        public string SælgerUserId { get; set; }
        public string KundeUserId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
