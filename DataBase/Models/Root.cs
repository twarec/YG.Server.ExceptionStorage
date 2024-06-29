using System.ComponentModel.DataAnnotations;

namespace YG.Server.ExceptionStorage.DataBase.Models;

public class Root
{
    [Key]
    public string Id { get; set; } = string.Empty;

    public DateTime DateCreate { get; set; } = DateTime.UtcNow;

    public List<Body> Messages { get; set; } = [];
}
