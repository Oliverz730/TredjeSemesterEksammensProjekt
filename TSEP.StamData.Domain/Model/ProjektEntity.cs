
namespace TSEP.StamData.Domain.Model
{
    public class ProjektEntity
    {
        public int Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string EstimatedTime { get; set; }
        public string ActualEstimated { get; set; }
        public ProjektEntity(int id, DateTime startDate, DateTime endDate, string estimatedTime, string actualEstimated)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            EstimatedTime = estimatedTime;
            ActualEstimated = actualEstimated;
        }
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
