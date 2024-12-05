using AutoMapper;
using BarberBoss.Communication.Enums;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories.Attendances;
using BarberBoss.Exception.ExceptionBase;

namespace BarberBoss.Application.UseCases.Attendances.Create;

public class CreateAttendanceUseCase : ICreateAttendanceUseCase
{
    private IMapper _mapper;
    private ICreateAttendanceRepository _attendanceCreate;

    public CreateAttendanceUseCase(IMapper mapper, ICreateAttendanceRepository attendanceCreate)
    {
        _mapper = mapper;
        _attendanceCreate = attendanceCreate;
    }
    public async Task<AttendanceResponseJson> Execute(AttendanceRequestJson request) {

        AttendanceValidator validationRules = new AttendanceValidator();

        var result = validationRules.Validate(request);

        if (result.IsValid is false) {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ValidationException(errors);
        }
        var attendance = _mapper.Map<Attendance>(request);

        await _attendanceCreate.Create(attendance);

        return _mapper.Map<AttendanceResponseJson>(attendance);
    }
}
