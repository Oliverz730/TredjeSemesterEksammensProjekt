
namespace TSEP.Igangsættelse.Application.OpgaveType.Query
{
    public class OpgaveTypeQueryResultDto
    {
        public int Id { get;  set; }
        public string Beskrivelse { get;  set; }
        public int KompetanceId { get;  set; }
        public byte[] RowVersion { get;  set; }
    }
}
