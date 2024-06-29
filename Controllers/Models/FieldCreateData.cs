using System.ComponentModel.DataAnnotations;
using YG.Server.ExceptionStorage.DataBase.Models;

namespace YG.Server.ExceptionStorage.Controllers.Models;

public class FieldCreateData
{
    [Required, MinLength(1)]
    public string Key { get; set; } = string.Empty;
    [Required]
    public string Value { get; set; } = string.Empty;

    public Field ToDataBase()
    {
        return new Field
        {
            Key = Key,
            Value = Value,
        };
    }
}
