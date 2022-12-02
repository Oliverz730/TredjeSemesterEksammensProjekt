using TSEP.App.Infrastructure.Igangsættelse.Contract.Dto;

namespace TSEP.App.Infrastructure.Igangsættelse.Contract
{
    public interface IIgangsættelseService
    {
        Task CreateOpgaveType(OpgaveTypeCreateRequestDto opgaveTypeCreateRequestDto);

    }
}
