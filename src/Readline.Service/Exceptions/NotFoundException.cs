namespace Readline.Service.Exceptions;

public class NotFoundException : Exception
{
    public int StatusCode = 404;
    public NotFoundException(string message):base(message)
    {}
    public NotFoundException(string message,Exception exception):base(message,exception)
    {}
}
