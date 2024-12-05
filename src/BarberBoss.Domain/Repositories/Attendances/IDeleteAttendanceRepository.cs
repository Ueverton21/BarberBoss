using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Attendances;

public interface IDeleteAttendanceRepository
{
    Task<bool> Delete(int id);
}
