using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Readline.Data.IRepositories;
using Readline.Domain.Entites.Users;
using Readline.Service.Exceptions;
using Readline.Service.Helpers;
using Readline.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Readline.Service.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration configuration;
    private readonly IRepository<User> repository;
    public AuthService(IConfiguration configuration, IRepository<User> repository)
    {
        this.configuration = configuration;
        this.repository = repository;
    }

    public async Task<string> GenereteTokenAsync(string phone, string password)
    {
        var user = await this.repository.GetAsync(x=> x.Phone.Equals(phone))
                             ?? throw new NotFoundException("This user is not found!");
    
        bool verifiedPassword = PasswordHasher.Verify(password,user.Password);
        if (!verifiedPassword)
			throw new CustomException(400, "Phone or password is invalid");


        var tokenHandler = new JwtSecurityTokenHandler();
		var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new Claim[]
			{
				 new Claim("Phone", user.Phone),
				 new Claim("Id", user.Id.ToString()),
				 new Claim(ClaimTypes.Role, user.Role.ToString())
		    }),
			Expires = DateTime.UtcNow.AddHours(1),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
		};
		var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
