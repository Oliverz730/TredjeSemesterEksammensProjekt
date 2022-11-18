namespace TredjeSemesterEksamensProjekt.StamData.Application.Commands
{
    public interface IKompetanceCreateCommand
    {
        void Create(KompetanceCreateRequestDto kompetanceCreateRequestDto);
    }
}
