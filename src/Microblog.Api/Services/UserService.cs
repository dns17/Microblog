
using Microblog.Api.Abstracts;
using Microblog.Api.Dtos;
using Microblog.Api.Entities;
using Microblog.Api.Exceptions;
using Microblog.Api.Interfaces;
using Microblog.Api.Persistences.Contexts;
using Microblog.Api.Security;

using Microsoft.EntityFrameworkCore;

namespace Microblog.Api.Services;

public class UserService(
    AppDbContext context,
    IPasswordHasher passwordHasher,
    TokenGenerator tokenGenerator) : IUserService
{
    private readonly AppDbContext _context = context;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly TokenGenerator _tokenGenerator = tokenGenerator;

    public async Task<UserResponse> CreateAsync(UserRequest request)
    {
        var hash = _passwordHasher.GeneratePassword(request.Password);

        var user = new User(request.UserName, hash);

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        var token = _tokenGenerator.Generate(user.Id, user.UserName);

        return new UserResponse
        {
            UserName = user.UserName,
            Token = token
        };
    }

    public async Task<UserResponse> LoginAsync(UserLogin login)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName.Equals(login.UserName));

        if (user is null || !_passwordHasher.VerifyPassword(login.Password, user.Senha))
        {
            throw new UserNotAuthorizedException("Usuário/Senha não encontrado!");
        }

        var token = _tokenGenerator.Generate(user.Id, user.UserName);

        return new UserResponse
        {
            UserName = user.UserName,
            Token = token
        };
    }
}
