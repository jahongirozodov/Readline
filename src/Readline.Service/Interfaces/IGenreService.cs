using Readline.Domain.Configuration;
using Readline.Service.DTOs.Genres;

namespace Readline.Service.Interfaces;

public interface IGenreService
{
    Task<GenreResultDto> AddAsync(GenreCreationDto genre);
    Task<GenreResultDto> ModifyAsync(GenreUpdateDto genre);
    Task<bool> RemoveAsync(long genreId);
    Task<GenreResultDto> RetriveByIdAsync(long genreId);
    IEnumerable<GenreResultDto> RetriveAll(PaginitionParams @params);
}
