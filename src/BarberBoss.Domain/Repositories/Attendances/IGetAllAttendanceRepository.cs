using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Attendances;

public interface IGetAllAttendanceRepository
{
    Task<List<Attendance>> GetAll();
}
