using System;

namespace TinyJobApi.Models.Vo;

public class PackageCreationVo
{
    public required string Name { get; set; }
    public required string Version { get; set; }
    public required string StorageAccount { get; set; }
    public required string RelativePath { get; set; }
    public required string Description { get; set; }
}
