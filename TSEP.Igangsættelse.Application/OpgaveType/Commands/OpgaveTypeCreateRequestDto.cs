
namespace TSEP.Igangsættelse.Application.OpgaveType.Commands
{
    public class OpgaveTypeCreateRequestDto
    {
        public string Beskrivelse { get; set; }
        public int KompetanceId { get; set; }
        //Create har ikke en RowVersion, da det kun kræves på handlinger på eksisterende rækker i databasen
    }
}
