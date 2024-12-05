using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories.Attendances;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infra.DataAccess.Repositories;

internal class AttendanceRepository : 
    ICreateAttendanceRepository, 
    IGetAllAttendanceRepository, 
    IGetByIdAttendanceRepository,
    IUpdateAttendanceRepository,
    IDeleteAttendanceRepository,
    IGetAttendanceByMonth
{
    private readonly BarberBossDbContext _context;
    public AttendanceRepository(BarberBossDbContext context)
    {
        _context = context;
    }
    public async Task Create(Attendance att)
    {
        await _context.Attendances.AddAsync(att);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Delete(int id)
    {
        var att = await _context.Attendances.FirstOrDefaultAsync(x => x.Id == id);
        if(att is not null)
        {
            _context.Attendances.Remove(att);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<List<Attendance>> GetAll()
    {
        return await _context.Attendances.AsNoTracking().ToListAsync();
    }

    public async Task<Attendance?> GetById(int id)
    {
        return await _context.Attendances.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Attendance>?> GetByMonth(DateOnly month)
    {
        var dateInitial = new DateTime(day: 1, month: month.Month, year: month.Year);

        var daysMonth = DateTime.DaysInMonth(year: month.Year, month: month.Month);
        var dateFinal = new DateTime(
            day: daysMonth, 
            month: month.Month, 
            year: month.Year,
            hour: 23,
            minute: 59,
            second: 59);

        var attendances = await _context.Attendances.Where(x => x.Date >= dateInitial &&
            x.Date <= dateFinal).ToListAsync();

        return attendances;
    }

    public void Update(int id, Attendance attendance)
    {
        var attendanceResult = _context.Attendances.FirstOrDefault(a => a.Id == attendance.Id);

        if(attendanceResult is not null)
        {
            _context.Attendances.Update(attendance);
            _context.SaveChanges();
        }
    }
}
