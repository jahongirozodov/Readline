namespace Readline.Service.Exceptions;

public class AlreadyExistException : Exception
{
    public int StatusCode = 401;

    public AlreadyExistException(string message): base(message)
    {}
    public AlreadyExistException(string message,Exception exception): base(message,exception)
    {}
}
