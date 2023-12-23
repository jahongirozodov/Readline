using AutoMapper;
using Readline.Data.IRepositories;
using Readline.Domain.Configuration;
using Readline.Domain.Entites.Categories;
using Readline.Service.DTOs.Categories;
using Readline.Service.Exceptions;
using Readline.Service.Exstensions;
using Readline.Service.Interfaces;

namespace Readline.Service.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> repository;
    private readonly IMapper mapper;

    public CategoryService(IMapper mapper, IRepository<Category> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<CategoryResultDto> AddAsync(CategoryCreationDto dto)
    {
        var existCategory = await this.repository.GetAsync(x => x.Name.ToLower().Equals(dto.Name.ToLower()));
        if(existCategory is not null)
            throw new AlreadyExistException("Category is already exist!");
        
        var mappedCategory = this.mapper.Map<Category>(dto);
        await this.repository.CreateAsync(mappedCategory);
        await this.repository.SaveAsync();

        return this.mapper.Map<CategoryResultDto>(mappedCategory);
    }   

    public async Task<CategoryResultDto> ModifyAsync(CategoryUpdateDto dto)
    {
        var category = await this.repository.GetAsync(x => x.Id.Equals(dto.Id))
                                 ?? throw new NotFoundException("This category is not found!");
        
        var mappedCategory = this.mapper.Map(dto,category);
        await this.repository.SaveAsync();

        return this.mapper.Map<CategoryResultDto>(mappedCategory);
    }

    public async Task<bool> Remove(long id)
    {
        var category = await this.repository.GetAsync(x => x.Id.Equals(id))
                                 ?? throw new NotFoundException("This category is not found!");
        
        this.repository.Delete(category);
        await this.repository.SaveAsync();
        
        return true;
    }

    public IEnumerable<CategoryResultDto> GetAll(PaginitionParams @params)
    {
        var categories = this.repository.GetAll().ToPaginate(@params);
        return this.mapper.Map<IEnumerable<CategoryResultDto>>(categories);
    }

    public async Task<CategoryResultDto> GetAsync(long id)
    {
        var category = await this.repository.GetAsync(x => x.Id.Equals(id))
                                 ?? throw new NotFoundException("This category is not found");
    
        return this.mapper.Map<CategoryResultDto>(category);
    }
}
