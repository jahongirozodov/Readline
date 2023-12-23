using AutoMapper;
using Readline.Data.IRepositories;
using Readline.Service.Exceptions;
using Readline.Service.Interfaces;
using Readline.Service.DTOs.Genres;
using Readline.Service.Exstensions;
using Readline.Domain.Configuration;
using Readline.Domain.Entites.Books;

namespace Readline.Service.Services;
public class GenreService : IGenreService
{
    private readonly IMapper mapper;
    private readonly IRepository<Genre> repository;
    public GenreService(IRepository<Genre> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<GenreResultDto> AddAsync(GenreCreationDto dto)
    {
        var genre = this.mapper.Map<Genre>(dto);

        await this.repository.CreateAsync(genre);
        await this.repository.SaveAsync();

        return this.mapper.Map<GenreResultDto>(genre);
    }

    public async Task<GenreResultDto> ModifyAsync(GenreUpdateDto dto)
    {
        var genre = await this.repository.GetAsync(genre => genre.Id.Equals(dto.Id))
                ?? throw new NotFoundException("This genre is not found!");

        var mappedGenre = this.mapper.Map(dto, genre);

        await this.repository.SaveAsync();

        return this.mapper.Map<GenreResultDto>(mappedGenre);
    }

    public async Task<bool> RemoveAsync(long genreId)
    {
        var genre = await this.repository.GetAsync(genre => genre.Id.Equals(genreId))
                ?? throw new NotFoundException("This genre is not found!");

        this.repository.Delete(genre);
        await this.repository.SaveAsync();

        return true;
    }

    public IEnumerable<GenreResultDto> RetriveAll(PaginitionParams @params)
    {
        var genres = this.repository.GetAll().ToPaginate(@params);

        return this.mapper.Map<IEnumerable<GenreResultDto>>(genres);
    }

    public async Task<GenreResultDto> RetriveByIdAsync(long genreId)
    {
        var genre = await this.repository.GetAsync(genre => genre.Id.Equals(genreId))
                ?? throw new NotFoundException("This genre is not found!");

        return this.mapper.Map<GenreResultDto>(genre);
    }
}
