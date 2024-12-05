using AutoMapper;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Repositories.Attendances;

namespace BarberBoss.Application.UseCases.Attendances.GetAll;

public class GetAllAttendanceUseCase : IGetAllAttendanceUseCase
{
    private IMapper _mapper;
    private IGetAllAttendanceRepository _repository;
    public GetAllAttendanceUseCase(IMapper mapper, IGetAllAttendanceRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<List<AttendanceResponseJson>> Execute()
    {
        var attendances = await _repository.GetAll();

        return _mapper.Map<List<AttendanceResponseJson>>(attendances);
    }
}
