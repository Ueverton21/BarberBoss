namespace BarberBoss.Exception.ExceptionBase;

public class ValidationException : BarberBossException
{
    public ValidationException(List<string> errors)
    {
        this.Errors = errors;
    }
}
