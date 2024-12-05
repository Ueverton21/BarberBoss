using BarberBoss.Communication.Requests;

namespace BarberBoss.Application.UseCases.Attendances.Update;

public interface IUpdateAttendanceUseCase
{
    Task Execute(int id, AttendanceRequestJson request);
}
