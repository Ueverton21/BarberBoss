using AutoMapper;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Repositories.Attendances;
using BarberBoss.Exception.ExceptionBase;

namespace BarberBoss.Application.UseCases.Attendances.GetById;

public class GetByIdAttendanceUseCase : IGetByIdAttendanceUseCase
{
    private IMapper _mapper;
    private IGetByIdAttendanceRepository _repository;
    public GetByIdAttendanceUseCase(IMapper mapper, IGetByIdAttendanceRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<AttendanceResponseJson> Execute(int id)
    {
        var att = await _repository.GetById(id);

        if(att is null)
        {
            throw new NotFoundException("Atendimento não encontrado.");
        }

        return _mapper.Map<AttendanceResponseJson>(att);
    }
}
