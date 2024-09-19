using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TinyJobApi.Models.Vo;

namespace TinyJobApi.Database.Entity;

public class UserDo
{
    public int Id { get; init; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public string? Email { get; set; }
    public DateTimeOffset CreateTime { get; init; }
    public DateTimeOffset? UpdateTime { get; set; }
    public ICollection<PackageDo> Packages { get; } = new List<PackageDo>();
}
