using System.ComponentModel.DataAnnotations;
using YG.Server.ExceptionStorage.DataBase.Models;

namespace YG.Server.ExceptionStorage.Controllers.Models;

public class RootCreateData
{
    [Required, MinLength(1)]
    public string Id { get; set; } = string.Empty;

    public Root ToDataBase()
    {
        return new Root
        {
            Id = Id,
        };
    }
}
