using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TinyJobApi.Database.Entity;

[Index(nameof(Name), IsUnique = true)]
public class UserDo
{
    [Key]
    public int Id { get; init; }
    [MaxLength(30)]
    public required string Name { get; set; }
    [MaxLength(30)]
    public required string Pwd { get; set; }
    [MaxLength(30)]
    public string? Email { get; set; }
    public DateTime CreateTime { get; init; }
    public DateTime? UpdateTime { get; set; }
}
