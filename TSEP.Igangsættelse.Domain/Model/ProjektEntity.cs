using System.ComponentModel.DataAnnotations;

namespace TSEP.Igangsættelse.Domain.Model
{
    public class ProjektEntity
    {
        public int Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string EstimatedTime { get; private set; }
        public string ActualEstimated { get; private set; }
        public string SælgerUserId { get; private set; }
        public string KundeUserId { get; private set; }
        [Timestamp]
        public byte[] RowVersion { get; private set; }
        public ProjektEntity(int id, DateTime startDate, DateTime endDate, string estimatedTime, string actualEstimated, string sælgerUserId, string kundeUserId, byte[] rowVersion)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            EstimatedTime = estimatedTime;
            ActualEstimated = actualEstimated;
            SælgerUserId = sælgerUserId;
            KundeUserId = kundeUserId;
            RowVersion = rowVersion;
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
    }
}
