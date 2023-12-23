using AutoMapper;
using Readline.Data.IRepositories;
using Readline.Service.DTOs.Books;
using Readline.Service.Exceptions;
using Readline.Service.Interfaces;
using Readline.Domain.Configuration;
using Readline.Domain.Entites.Books;

namespace Readline.Service.Services;

public class BookService : IBookService
{
    private readonly IMapper mapper;

    private readonly IRepository<Book> repository;
    public BookService(IMapper mapper, IRepository<Book> repository)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<BookResultDto> AddAsync(BookCreationDto dto)
    {
        var book = this.repository.GetAsync(book => book.Title.Equals(dto.Title));
        if (book is not null)
            throw new AlreadyExistException("This book is already exception");

        var mappedBook = this.mapper.Map<Book>(dto);
        await this.repository.CreateAsync(mappedBook);
        await this.repository.SaveAsync();

        return this.mapper.Map<BookResultDto>(mappedBook);
    }

    public async Task<BookResultDto> ModifyAsync(BookUpdateDto dto)
    {
        var book = await this.repository.GetAsync(x => x.Id.Equals(dto.Id))
                    ?? throw new NotFoundException("This book is not found!");

        var mappedBook = this.mapper.Map(dto,book);
        await this.repository.SaveAsync();

        return this.mapper.Map<BookResultDto>(mappedBook);
    }

    public async Task<bool> RemoveAsync(long bookId)
    {
        var book = await this.repository.GetAsync(x=> x.Id.Equals(bookId))
                   ?? throw new NotFoundException("This book is not found!");

        this.repository.Delete(book);
        await this.repository.SaveAsync();

        return true;
    }

    public IEnumerable<BookResultDto> RetreiveAll(PaginitionParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<BookResultDto> RetrieveById(long bookId)
    {
        var book = await this.repository.GetAsync(book => book.Id.Equals(bookId), new[]{"Attachment","Genre"})
                            ?? throw new NotFoundException("This book is not found!");

        return this.mapper.Map<BookResultDto>(book);
    }
}
