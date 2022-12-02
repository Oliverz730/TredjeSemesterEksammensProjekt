namespace TSEP.Igangsættelse.Application.OpgaveType.Commands
{
    public interface IOpgaveTypeCreateCommand
    {
        void CreateOpgaveType(OpgaveTypeCreateRequestDto opgaveTypeCreateRequestDto);
    }
}
