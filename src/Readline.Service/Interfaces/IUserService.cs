using Readline.Domain.Configuration;
using Readline.Service.DTOs.Users;

namespace Readline.Service.Interfaces;
public interface IUserService
{
    Task<UserResultDto> RegisterAsync(UserRegisterDto dto);
    Task<UserResultDto> ModifyAsync(UserUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<UserResultDto> RetrieveByIdAsync(long id);
    IEnumerable<UserResultDto> RetrieveAllAsync(PaginitionParams @params);
}
