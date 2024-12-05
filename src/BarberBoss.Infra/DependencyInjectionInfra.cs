using BarberBoss.Domain.Repositories.Attendances;
using BarberBoss.Infra.DataAccess;
using BarberBoss.Infra.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BarberBoss.Infra;

public static class DependencyInjectionInfra
{
    public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services,configuration);
        AddRepositories(services);
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        string connection = configuration.GetConnectionString("Connection")!;

        services.AddDbContext<BarberBossDbContext>(options =>
            options.UseMySql(connection, new MySqlServerVersion(new Version(8, 4, 0)))
        );
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ICreateAttendanceRepository, AttendanceRepository>();
        services.AddScoped<IGetAllAttendanceRepository, AttendanceRepository>();
        services.AddScoped<IGetByIdAttendanceRepository, AttendanceRepository>();
        services.AddScoped<IUpdateAttendanceRepository, AttendanceRepository>();
        services.AddScoped<IDeleteAttendanceRepository, AttendanceRepository>();
        services.AddScoped<IGetAttendanceByMonth, AttendanceRepository>();
    }
}
