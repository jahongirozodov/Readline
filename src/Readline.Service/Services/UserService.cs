using AutoMapper;
using Readline.Service.Helpers;
using Readline.Data.IRepositories;
using Readline.Service.DTOs.Users;
using Readline.Service.Exceptions;
using Readline.Service.Interfaces;
using Readline.Service.Exstensions;
using Readline.Domain.Configuration;
using Readline.Domain.Entites.Users;

namespace Readline.Service.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> repository;
    private IMapper mapper;
    public UserService(IRepository<User> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<UserResultDto> RegisterAsync(UserRegisterDto dto)
    {
        var existUser = await this.repository.GetAsync(x => x.Phone.Equals(dto.Phone));
        if (existUser is not null)
            throw new AlreadyExistException("This user is already exist!");

        var mappedUser = this.mapper.Map<User>(dto);
        mappedUser.Password = PasswordHasher.Hash(dto.Password);

        await this.repository.CreateAsync(mappedUser);
        await this.repository.SaveAsync();

        return this.mapper.Map<UserResultDto>(mappedUser);
    }

    public async Task<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        var user = await this.repository.GetAsync(x => x.Id.Equals(dto.Id))
                             ?? throw new NotFoundException("This user is not found");

        var mappedUser = this.mapper.Map(dto, user);
        await this.repository.SaveAsync();

        return this.mapper.Map<UserResultDto
            >(dto);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await this.repository.GetAsync(x => x.Id.Equals(id))
                             ?? throw new NotFoundException("This user is not found");

        this.repository.Delete(user);
        await this.repository.SaveAsync();

        return true;
    }

    public IEnumerable<UserResultDto> RetrieveAllAsync(PaginitionParams @params)
    {
        var users = this.repository.GetAll().ToPaginate(@params);

        return this.mapper.Map<IEnumerable<UserResultDto>>(users);
    }

    public async Task<UserResultDto> RetrieveByIdAsync(long id)
    {
        var user = await this.repository.GetAsync(x => x.Id.Equals(id))
                             ?? throw new NotFoundException("This user is not found!");

        return this.mapper.Map<UserResultDto>(user);
    }
}
