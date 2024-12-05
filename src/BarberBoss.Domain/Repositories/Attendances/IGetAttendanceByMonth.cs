using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Attendances;

public interface IGetAttendanceByMonth
{
    Task<List<Attendance>?> GetByMonth(DateOnly month);
}
