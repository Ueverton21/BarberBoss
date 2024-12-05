using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Attendances.GetAll;

public interface IGetAllAttendanceUseCase
{
    Task<List<AttendanceResponseJson>> Execute();
}
