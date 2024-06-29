using System.ComponentModel.DataAnnotations;
using YG.Server.ExceptionStorage.DataBase.Models;

namespace YG.Server.ExceptionStorage.Controllers.Models;

public class BodyCreateData
{
    [Required, MinLength(1)]
    public string Type { get; set; } = string.Empty;
    [Required, MinLength(1)]
    public string Name { get; set; } = string.Empty;

    public List<FieldCreateData> Fields { get; set; } = [];

    public Body ToDataBase()
    {
        return new Body
        {
            Type = Type,
            Name = Name,
            Fields = Fields.Select(_ => _.ToDataBase()).ToList(),
        };
    }
}
