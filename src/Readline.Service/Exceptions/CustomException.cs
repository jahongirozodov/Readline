namespace Readline.Service.Exceptions;

public class CustomException : Exception
{
    public int StatusCode {get;set; } 
    public CustomException(int StatusCode, string message) : base(message)
    {
        this.StatusCode = StatusCode;
    }
    public CustomException(int StatusCode,string message,Exception exception) : base(message,exception)
    {
        this.StatusCode = StatusCode;
    }
}
