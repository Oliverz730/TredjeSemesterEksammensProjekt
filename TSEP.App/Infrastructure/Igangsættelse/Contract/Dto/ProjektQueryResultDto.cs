namespace TSEP.App.Infrastructure.Igangsættelse.Contract.Dto
{
    public class ProjektQueryResultDto
    {
        public int Id { get; set; }
        public string ProjektName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? EstimatedTime { get; set; }
        public string? ActualEstimated { get; set; }
        public string SælgerUserId { get; set; }
        public string KundeUserId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
