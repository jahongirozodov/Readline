namespace Readline.Service.Interfaces;

public interface IAuthService 
{
    Task<string> GenereteTokenAsync(string phone, string password);
}
