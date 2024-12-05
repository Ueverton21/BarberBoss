using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Attendances;

public interface IGetByIdAttendanceRepository
{
    Task<Attendance> GetById(int id);
}
