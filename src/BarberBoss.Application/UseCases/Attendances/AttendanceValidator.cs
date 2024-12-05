using BarberBoss.Communication.Requests;
using BarberBoss.Exception.Resources;
using FluentValidation;

namespace BarberBoss.Application.UseCases.Attendances;

public class AttendanceValidator : AbstractValidator<AttendanceRequestJson>
{
    public AttendanceValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage(ResourcesErrorsAttendanceJson.TITLE_NOT_EMPTY_ERROR);
        
        RuleFor(x => x.Date)
            .LessThan(DateTime.Now).WithMessage(ResourcesErrorsAttendanceJson.LESS_THAN_CURRENT_DATE_ERROR);
        
        RuleFor(x => x.Value)
            .GreaterThanOrEqualTo(0).WithMessage(ResourcesErrorsAttendanceJson.VALUE_GREATHER_THAN_ZERO_ERROR);
        
        RuleFor(x => x.PaymentType).IsInEnum().WithMessage(ResourcesErrorsAttendanceJson.PAYMENT_TYPE_INVALID_ERROR);
    }
}
