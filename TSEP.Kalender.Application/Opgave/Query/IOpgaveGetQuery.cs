
namespace TSEP.Kalender.Application.Opgave.Query
{
    public interface IOpgaveGetQuery
    {
        public OpgaveQueryResultDto Get(int projektId, int opgaveTypeId, string ansatId);
    }
}
