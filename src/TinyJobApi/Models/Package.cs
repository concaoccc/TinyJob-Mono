using System;

namespace TinyJobApi.Models;

public class Package
{
        public required string Name { get; set; }
        public required string Version { get; set; }
        public required string StorageAccount { get; set; }
        public required string RelativePath { get; set; }
        public required string Description { get; set; }
}
