using Microsoft.EntityFrameworkCore;
using YG.Server.ExceptionStorage.DataBase;
using YG.Server.ExceptionStorage.DataBase.Models;

namespace YG.Server.ExceptionStorage.Services.Runtime;

public class RootService(GeneralContext db) : IRootService
{
    public async Task<Root?> CreateAsync(Root root)
    {
        await db.AddAsync(root);
        await db.SaveChangesAsync();
        return root;
    }

    public async Task<IEnumerable<Root>> GetAllAsync()
    {
        return await db.Roots
            .ToListAsync();
    }

    public async Task<Root?> GetAsync(string id)
    {
        return await db.Roots
            .SingleOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<IEnumerable<Root>> GetRangeAsync(int offset, int count)
    {
        return await db.Roots
            .Skip(offset).Take(count).ToListAsync();
    }
}
