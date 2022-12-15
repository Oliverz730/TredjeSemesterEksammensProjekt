
namespace TSEP.Igangsættelse.Application.OpgaveType.Commands
{
    public class OpgaveTypeEditRequestDto
    {
        public int Id { get; private set; }
        public string Beskrivelse { get; private set; }

        public int KompetanceId { get; private set; }
        public byte[] RowVersion { get; private set; }
    }
}
