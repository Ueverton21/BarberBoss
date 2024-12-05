
using BarberBoss.Domain.Repositories.Attendances;
using BarberBoss.Exception.ExceptionBase;

namespace BarberBoss.Application.UseCases.Attendances.Delete;

public class DeleteAttendanceUseCase : IDeleteAttendanceUseCase
{
    private IDeleteAttendanceRepository _repository;

    public DeleteAttendanceUseCase(IDeleteAttendanceRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Execute(int id)
    {
        if(await _repository.Delete(id))
        {
            return true;
        }
        throw new NotFoundException("Atendimento não encontrado");
    }
}
