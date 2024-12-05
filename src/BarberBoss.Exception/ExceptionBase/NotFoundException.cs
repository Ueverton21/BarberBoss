namespace BarberBoss.Exception.ExceptionBase;

public class NotFoundException : BarberBossException
{
    public NotFoundException(string error)
    {
        this.Errors = [];
        this.Errors.Add(error);
    }
}
