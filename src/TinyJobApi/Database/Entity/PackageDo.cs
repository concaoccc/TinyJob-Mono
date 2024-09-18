using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyJobApi.Database.Entity;

[Index(nameof(OwnerId), nameof(Name), nameof(Version), IsUnique = true)]
[Table("Package")]
public class PackageDo
{
    [Key]
    public int Id { get; init; }
    [MaxLength(30)]
    public required string Name { get; set; }
    [MaxLength(30)]
    public required string Version { get; set; }
    [MaxLength(100)]
    public required string StorageAccount { get; set; }
    [MaxLength(100)]
    public required string RelativePath { get; set; }
    [ForeignKey("User")]
    public long OwnerId { get; init; }
    [MaxLength(200)]
    public required string Description { get; set; }
    public DateTimeOffset CreateTime { get; init; }
    public DateTimeOffset UpdateTime { get; set; }
}
