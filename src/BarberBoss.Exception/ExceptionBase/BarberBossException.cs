namespace BarberBoss.Exception.ExceptionBase;

public abstract class BarberBossException : System.Exception
{
    public List<string> Errors = [];
}
