using Readline.Domain.Configuration;
using Readline.Service.DTOs.Books;

namespace Readline.Service.Interfaces;

public interface IBookService
{
    Task<BookResultDto> AddAsync(BookCreationDto dto);
    Task<BookResultDto> ModifyAsync(BookUpdateDto dto);
    Task<bool> RemoveAsync(long bookId);
    Task<BookResultDto> RetrieveById(long bookId);
    IEnumerable<BookResultDto> RetreiveAll(PaginitionParams @params);

}
