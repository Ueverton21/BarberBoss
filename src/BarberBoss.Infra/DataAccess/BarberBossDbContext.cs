using BarberBoss.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infra.DataAccess;

internal class BarberBossDbContext : DbContext
{
    public BarberBossDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Attendance> Attendances { get; set; }
}
