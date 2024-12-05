using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Attendances;

public interface IUpdateAttendanceRepository
{
    void Update(int id, Attendance attendance);
}
