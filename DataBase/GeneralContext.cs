using Microsoft.EntityFrameworkCore;
using YG.Server.ExceptionStorage.DataBase.Models;

namespace YG.Server.ExceptionStorage.DataBase;

public class GeneralContext : DbContext
{
    public DbSet<Root> Roots { get; set; }
    public DbSet<Body> Bodys { get; set; }
    public DbSet<Field> Fields { get; set; }

    public GeneralContext(DbContextOptions<GeneralContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
