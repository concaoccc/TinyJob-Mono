using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyJobApi.Database.Entity;

[Index(nameof(Name), IsUnique = true)]
[Table("User")]
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
    public DateTimeOffset CreateTime { get; init; }
    public DateTimeOffset? UpdateTime { get; set; }
}
