using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Attendances;

public interface ICreateAttendanceRepository
{
    Task Create(Attendance att);
}
