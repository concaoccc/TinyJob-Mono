using System;

namespace TinyJobApi.Models.Vo;

public class PackageVo
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Version { get; set; }
    public required string StorageAccount { get; set; }
    public required string RelativePath { get; set; }
    public required string Description { get; set; }
    public DateTime? CreateTime { get; set; }
    public DateTime? UpdateTime { get; set; }
}
