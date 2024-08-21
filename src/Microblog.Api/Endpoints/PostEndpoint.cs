using Microblog.Api.Dtos;
using Microblog.Api.Filters;
using Microblog.Api.Interfaces;

using Microsoft.AspNetCore.Http.HttpResults;

namespace Microblog.Api.Endpoints;

public static class PostEndpoint
{
    public static void RegisterPostEndpoint(this IEndpointRouteBuilder routes)
    {
        var postGroup = routes
            .MapGroup("/api/posts")
            .WithOpenApi();

        postGroup
            .MapPost("/", Post)
            .WithSummary("Criar um novo Post.")
            .WithRequestValidation<PostRequest>();

        postGroup
            .MapPut("/{id:int}", Put)
            .WithSummary("Atualizar o Post.")
            .WithRequestValidation<PostRequest>();

        postGroup
            .MapDelete("/{id:int}", Delete)
            .WithSummary("Deletar o Post.");

        postGroup
            .MapGet("/{id:int}", GetById)
            .WithSummary("Obter um Post via Id.");

        postGroup
            .MapGet("/", GetList)
            .WithSummary("Obter a lista de Posts.");
    }

    static async Task<Ok<int>> Post(
        IPostService postService,
        PostRequest request)
    {
        var id = await postService.CreateAsync(request);
        return TypedResults.Ok(id);
    }

    static async Task<NoContent> Put(
        IPostService postService,
        int id,
        PostRequest request)
    {
        await postService.UpdateAsync(id, request);

        return TypedResults.NoContent();
    }

    static async Task<Results<NoContent, BadRequest>> Delete(
        IPostService postService,
        int id)
    {
        var deleted = await postService.DeleteAsync(id);

        return deleted ? TypedResults.NoContent() : TypedResults.BadRequest();
    }

    static async Task<Ok<PostResponse>> GetById(
        IPostService postService,
        int id)
    {
        var post = await postService.GetByIdAsync(id);

        return TypedResults.Ok(post);
    }

    static async Task<Ok<IReadOnlyList<PostResponse>>> GetList(IPostService postService)
    {
        return TypedResults.Ok(
            await postService.GetListAsync());
    }
}