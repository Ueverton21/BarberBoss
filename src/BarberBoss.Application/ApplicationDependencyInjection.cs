using BarberBoss.Application.AutoMapper;
using BarberBoss.Application.UseCases.Attendances.Create;
using BarberBoss.Application.UseCases.Attendances.Delete;
using BarberBoss.Application.UseCases.Attendances.GetAll;
using BarberBoss.Application.UseCases.Attendances.GetById;
using BarberBoss.Application.UseCases.Attendances.Update;
using BarberBoss.Application.UseCases.Reports.Excel;
using Microsoft.Extensions.DependencyInjection;

namespace BarberBoss.Application;

public static class ApplicationDependencyInjection
{
    public static void AddAplication(this IServiceCollection services)
    {
        InjectionUseCases(services);
        services.AddAutoMapper(typeof(AutoMapping));
    }
    private static void InjectionUseCases(IServiceCollection services)
    {
        //Attendances
        services.AddScoped<ICreateAttendanceUseCase, CreateAttendanceUseCase>();
        services.AddScoped<IGetAllAttendanceUseCase, GetAllAttendanceUseCase>();
        services.AddScoped<IGetByIdAttendanceUseCase, GetByIdAttendanceUseCase>();
        services.AddScoped<IUpdateAttendanceUseCase, UpdateAttendanceUseCase>();
        services.AddScoped<IDeleteAttendanceUseCase, DeleteAttendanceUseCase>();
        //Reports
        services.AddScoped<IGenerateExpenseReportExcelUseCase, GenerateReportExcelUseCase>();
    }
}
