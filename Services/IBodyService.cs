using YG.Server.ExceptionStorage.DataBase.Models;

namespace YG.Server.ExceptionStorage.Services;

public interface IBodyService
{
    public Task<Body?> CreateAsync(Body error, string rootId);

    public Task<IEnumerable<Body>> GetRangeAsync(int offset, int count, string rootId);
    public Task<IEnumerable<Body>> GetAllAsync(string rootId);

    public Task<IEnumerable<Body>> GetRangeAsync(int offset, int count, string rootId, string type);
    public Task<IEnumerable<Body>> GetAllAsync(string rootId, string type);

    public Task<IEnumerable<Body>> GetRangeAsync(int offset, int count, string rootId, string type, string name);
    public Task<IEnumerable<Body>> GetAllAsync(string rootId, string type, string name);
}
