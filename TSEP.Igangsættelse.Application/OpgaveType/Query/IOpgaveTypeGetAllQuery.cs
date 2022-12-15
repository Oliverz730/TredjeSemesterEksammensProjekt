
namespace TSEP.Igangsættelse.Application.OpgaveType.Query
{
    public interface IOpgaveTypeGetAllQuery
    {
        IEnumerable<OpgaveTypeQueryResultDto> GetAll();
    }
}
