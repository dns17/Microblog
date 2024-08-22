using Microblog.Api.Dtos;

namespace Microblog.Api.Interfaces;

public interface IUserService
{
    Task<UserResponse> CreateAsync(UserRequest request);
    Task<UserResponse> LoginAsync(UserLogin login);
}