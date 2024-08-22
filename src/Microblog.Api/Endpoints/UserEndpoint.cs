using System.Net;

using Microblog.Api.Dtos;
using Microblog.Api.Filters;
using Microblog.Api.Interfaces;

using Microsoft.AspNetCore.Http.HttpResults;

namespace Microblog.Api.Endpoints;

public static class UserEndpoint
{
    public static void RegisterUserEndpoint(this IEndpointRouteBuilder routes)
    {
        var userGroup = routes
            .MapGroup("/api/users")
            .WithOpenApi();


        userGroup
            .MapPost("/register", Register)
            .WithSummary("Cria uma nova conta.")
            .AllowAnonymous()
            .WithRequestValidation<UserRequest>();

        userGroup
            .MapPost("/login", Login)
            .WithSummary("Efetua o login retornando o token")
            .AllowAnonymous()
            .ProducesProblem(StatusCodes.Status401Unauthorized)
            .WithRequestValidation<UserLogin>();


        static async Task<Ok<UserResponse>> Register(
            IUserService userService,
            UserRequest request)
        {
            var userResponse = await userService.CreateAsync(request);

            return TypedResults.Ok(userResponse);
        }

        static async Task<Ok<UserResponse>> Login(
            IUserService userService,
            UserLogin request)
        {
            var userResponse = await userService.LoginAsync(request);

            return TypedResults.Ok(userResponse);
        }
    }
}