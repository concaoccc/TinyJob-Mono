using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace TinyJobApi.Database.Entity;

[Index(nameof(Name), IsUnique = true)]
public class UserDo
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Pwd { get; set; }
    public string? Email { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
}
