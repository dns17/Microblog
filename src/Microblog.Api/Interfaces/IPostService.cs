using Microblog.Api.Dtos;

namespace Microblog.Api.Interfaces;

public interface IPostService
{
    Task<int> CreateAsync(PostRequest request);
    Task UpdateAsync(int id, PostRequest request);
    Task<bool> DeleteAsync(int id);
    Task<PostResponse> GetById(int id);
    Task<IReadOnlyList<PostResponse>> GetListAsync();
}