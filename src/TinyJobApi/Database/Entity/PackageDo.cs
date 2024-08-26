using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyJobApi.Database.Entity;

[Index(nameof(OwnerId), nameof(Name), nameof(Version), IsUnique = true)]
public class PackageDo
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Version { get; set; }
    public required string StorageAccount { get; set; }
    public required string RelativePath { get; set; }
    [ForeignKey("User")]
    public long OwnerId { get; set; }
    public virtual required UserDo Owner { get; set; }
    public required string Description { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
}
