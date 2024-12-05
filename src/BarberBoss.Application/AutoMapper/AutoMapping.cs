using AutoMapper;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Entities;

namespace BarberBoss.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        //Request to entity
        CreateMap<AttendanceRequestJson, Attendance>();

        //Entity to response
        CreateMap<Attendance, AttendanceResponseJson>();
    }
}
