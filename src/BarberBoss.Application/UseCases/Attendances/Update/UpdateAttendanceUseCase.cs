using AutoMapper;
using BarberBoss.Communication.Requests;
using BarberBoss.Domain.Repositories.Attendances;
using BarberBoss.Exception.ExceptionBase;

namespace BarberBoss.Application.UseCases.Attendances.Update;

public class UpdateAttendanceUseCase : IUpdateAttendanceUseCase
{
    private IUpdateAttendanceRepository _repository;
    private IGetByIdAttendanceRepository _reposityById;
    private IMapper _mapper;

    public UpdateAttendanceUseCase(
        IUpdateAttendanceRepository repository, 
        IMapper mapper, 
        IGetByIdAttendanceRepository reposityById)
    {
        _repository = repository;
        _mapper = mapper;
        _reposityById = reposityById;
    }

    public async Task Execute(int id, AttendanceRequestJson request)
    {
        var validate = new AttendanceValidator();

        if (validate.Validate(request).IsValid is false)
        {
            var errors = validate.Validate(request).Errors.Select(x => x.ErrorMessage).ToList();

            throw new ValidationException(errors);
        }

        var att = await _reposityById.GetById(id);

        if(att is null)
        {
            throw new NotFoundException("Atendimento não encontrado.");
        }

        _mapper.Map(request,att);

        _repository.Update(id,att);
    }
}
