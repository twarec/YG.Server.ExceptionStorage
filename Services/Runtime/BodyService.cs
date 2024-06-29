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
}
