using System.ComponentModel.DataAnnotations;

namespace TSEP.Igangsættelse.Domain.Model
{
    public class ProjektEntity
    {
        public int Id { get; private set; }
        public string ProjektName { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string? EstimatedTime { get; private set; }
        public string? ActualEstimated { get; private set; }
        public string SælgerUserId { get; private set; }
        public string KundeUserId { get; private set; }
        [Timestamp]
        public byte[] RowVersion { get; private set; }
        
        public ProjektEntity(DateTime startDate, string sælgerUserId, string kundeUserId, string projektName)
        {
            ProjektName = projektName;
            StartDate = startDate;
            SælgerUserId = sælgerUserId;
            KundeUserId = kundeUserId;
        }
        //EF
        internal ProjektEntity() { }
        public int Estimate(string boliger)
        {
            return 1;
        }
        public int GetDuration() 
        { 
            return 1; 
        }
        public void Edit(DateTime startDate, DateTime? endDate, string? estimatedTime, string? actualEstimated, string kundeUserId, string projektName, byte[] rowVersion)
        {
            ProjektName = projektName;
            StartDate = startDate;
            EndDate = endDate;
            EstimatedTime = estimatedTime;
            ActualEstimated = actualEstimated;
            KundeUserId = kundeUserId;
            RowVersion = rowVersion;
        }
    }
}
