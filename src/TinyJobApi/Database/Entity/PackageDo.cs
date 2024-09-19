using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyJobApi.Database.Entity;

public class PackageDo
{
    public int Id { get; init; }
    public required string Name { get; set; }
    public required string Version { get; set; }
    public required string StorageAccount { get; set; }
    public required string RelativePath { get; set; }
    public int OwnerId { get; init; }
    public UserDo? Owner;
    public required string Description { get; set; }
    public DateTimeOffset CreateTime { get; init; }
    public DateTimeOffset UpdateTime { get; set; }
    public ICollection<SchedulerDo> Schedulers { get; } = new List<SchedulerDo>();
}
