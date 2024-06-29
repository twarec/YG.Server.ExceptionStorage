using YG.Server.ExceptionStorage.DataBase.Models;

namespace YG.Server.ExceptionStorage.Services;

public interface IBodyService
{
    public Task<Body?> CreateAsync(Body error, string rootId);
}
