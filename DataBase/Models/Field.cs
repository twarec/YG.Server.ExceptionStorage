using Microsoft.EntityFrameworkCore;

namespace YG.Server.ExceptionStorage.DataBase.Models;

[Index(nameof(Key))]
[Index(nameof(Key), nameof(BodyId), IsUnique = true)]
public class Field
{
    public int Id { get; set; } = 0;
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;

    public DateTime DateCreate { get; set; } = DateTime.UtcNow;

    public int BodyId { get; set; } = 0;
}
