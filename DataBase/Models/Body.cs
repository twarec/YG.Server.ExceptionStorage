using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace YG.Server.ExceptionStorage.DataBase.Models;

[Index(nameof(Type))]
[Index(nameof(Name))]
public class Body
{
    [Key]
    public int Id { get; set; } = 0;
    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public DateTime DateCreate { get; set; } = DateTime.UtcNow;

    public string RootId { get; set; } = string.Empty;
    public List<Field> Fields { get; set; } = [];
}
