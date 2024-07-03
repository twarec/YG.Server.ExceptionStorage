using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using YG.Server.ExceptionStorage.DataBase;
using YG.Server.ExceptionStorage.DataBase.Models;

namespace YG.Server.ExceptionStorage.Services.Runtime;

public class BodyService(GeneralContext db) : IBodyService
{
    public async Task<Body?> CreateAsync(Body body, string rootId)
    {
        var root = await db.Roots.SingleOrDefaultAsync(_ => _.Id == rootId);
        if (root == null)
        {
            root = new Root
            {
                Id = rootId,
            };
            db.Roots.Add(root);
        }
        root.Messages.Add(body);
        await db.SaveChangesAsync();
        return body;
    }

    public async Task<IEnumerable<Body>> GetAllAsync(string rootId)
    {
        return await db.Bodys
            .Where(_ => _.RootId == rootId)
            .Include(_ => _.Fields)
            .ToListAsync();

    }

    public async Task<IEnumerable<Body>> GetAllAsync(string rootId, string type)
    {
        return await db.Bodys
            .Where(_ => _.RootId == rootId)
            .Where(_ => _.Type == type)
            .Include(_ => _.Fields)
            .ToListAsync();
    }

    public async Task<IEnumerable<Body>> GetAllAsync(string rootId, string type, string name)
    {
        return await db.Bodys
            .Where(_ => _.RootId == rootId)
            .Where(_ => _.Type == type)
            .Where(_ => _.Name == name)
            .Include(_ => _.Fields)
            .ToListAsync();
    }

    public async Task<IEnumerable<Body>> GetRangeAsync(int offset, int count, string rootId)
    {
        return await db.Bodys
            .Where(_ => _.RootId == rootId)
            .Skip(offset)
            .Take(count)
            .Include(_ => _.Fields)
            .ToListAsync();
    }

    public async Task<IEnumerable<Body>> GetRangeAsync(int offset, int count, string rootId, string type)
    {
        return await db.Bodys
            .Where(_ => _.RootId == rootId)
            .Where(_ => _.Type == type)
            .Skip(offset)
            .Take(count)
            .Include(_ => _.Fields)
            .ToListAsync();
    }

    public async Task<IEnumerable<Body>> GetRangeAsync(int offset, int count, string rootId, string type, string name)
    {
        return await db.Bodys
            .Where(_ => _.RootId == rootId)
            .Where(_ => _.Type == type)
            .Where(_ => _.Name == name)
            .Skip(offset)
            .Take(count)
            .Include(_ => _.Fields)
            .ToListAsync();
    }
}
