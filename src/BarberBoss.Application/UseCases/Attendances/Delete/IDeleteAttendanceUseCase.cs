namespace BarberBoss.Application.UseCases.Attendances.Delete;

public interface IDeleteAttendanceUseCase
{
    Task<bool> Execute(int id);
}
