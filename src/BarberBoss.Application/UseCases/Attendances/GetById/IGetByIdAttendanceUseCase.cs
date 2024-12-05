using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Attendances.GetById;

public interface IGetByIdAttendanceUseCase
{
    Task<AttendanceResponseJson> Execute(int id);
}
