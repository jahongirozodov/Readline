using Readline.Domain.Configuration;
using Readline.Service.DTOs.Categories;
using Readline.Service.DTOs.Users;

namespace Readline.Service.Interfaces;

public interface ICategoryService
{
    Task<CategoryResultDto> AddAsync(CategoryCreationDto dto);
    Task<CategoryResultDto> ModifyAsync(CategoryUpdateDto dto);
    Task<bool> Remove(long id);
    Task<CategoryResultDto> GetAsync(long id);
    IEnumerable<CategoryResultDto> GetAll(PaginitionParams @params);
}
