using Microblog.Api.Dtos;
using Microblog.Api.Entities;
using Microblog.Api.Exceptions;
using Microblog.Api.Interfaces;
using Microblog.Api.Persistences.Contexts;

using Microsoft.EntityFrameworkCore;

namespace Microblog.Api.Services;

public class PostService(AppDbContext context) : IPostService
{
    private readonly AppDbContext _context = context;

    public async Task<int> CreateAsync(PostRequest request)
    {
        var post = new Post(request.Titulo, request.Conteudo);
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();

        return post.Id;
    }

    public async Task UpdateAsync(int id, PostRequest request)
    {
        var post = _context.Posts.FirstOrDefault(x => x.Id == id);
        if (post is null)
        {
            throw new PostsNotFoundException($"Post com ID {id} não encontrado.");
        }

        post.Update(
            titulo: request.Titulo,
            conteudo: request.Conteudo);

        _context.Posts.Update(post);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var post = _context.Posts.FirstOrDefault(x => x.Id == id);
        if (post is null)
        {
            throw new PostsNotFoundException($"Post com ID {id} não encontrado.");
        }

        _context.Posts.Remove(post);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<PostResponse> GetById(int id)
    {
        await Task.CompletedTask;
        var post = _context.Posts.FirstOrDefault(x => x.Id == id);
        if (post is null)
        {
            throw new PostsNotFoundException($"Post com ID {id} não encontrado.");
        }

        return new PostResponse(
            post.Id,
            post.Titulo,
            post.Conteudo,
            post.DataCriacao,
            post.DataAtualizacao);
    }

    public async Task<IReadOnlyList<PostResponse>> GetListAsync()
    {
        return await
            _context.Posts
                .Select(x => new PostResponse(x.Id, x.Titulo, x.Conteudo, x.DataCriacao, x.DataAtualizacao))
                .ToListAsync()
    }

}
