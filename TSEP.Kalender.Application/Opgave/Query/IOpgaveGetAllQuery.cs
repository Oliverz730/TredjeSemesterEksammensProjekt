
namespace TSEP.Kalender.Application.Opgave.Query
{
    public interface IOpgaveGetAllQuery
    {
        public IEnumerable<OpgaveQueryResultDto> GetAllByProjekt(int projektId);
        public IEnumerable<OpgaveQueryResultDto> GetAllByAnsat(string ansatId);
    }
}
