using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Attendances.Create;

public interface ICreateAttendanceUseCase
{
    Task<AttendanceResponseJson> Execute(AttendanceRequestJson request);
}
