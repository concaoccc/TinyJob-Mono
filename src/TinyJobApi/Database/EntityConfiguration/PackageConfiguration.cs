using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyJobApi.Database.Entity;

namespace TinyJobApi.Database.EntityConfiguration
{
    public class PackageConfiguration : IEntityTypeConfiguration<PackageDo>
    {
        public void Configure(EntityTypeBuilder<PackageDo> builder)
        {
            builder.ToTable("Package");
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Owner).WithMany(e => e.Packages).HasForeignKey(x => x.OwnerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(e => new {e.Name, e.OwnerId, e.Version}).IsUnique();
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Name).HasColumnName("Name").HasMaxLength(30).IsRequired();
            builder.Property(e => e.Version).HasColumnName("Version").HasMaxLength(30).IsRequired();
            builder.Property(e => e.StorageAccount).HasColumnName("StorageAccount").HasMaxLength(100).IsRequired();
            builder.Property(e => e.RelativePath).HasColumnName("RelativePath").HasMaxLength(100).IsRequired();
            builder.Property(e => e.OwnerId).HasColumnName("OwnerId");
            builder.Property(e => e.Description).HasColumnName("Description").HasMaxLength(200).IsRequired();
            builder.Property(e => e.CreateTime).HasColumnName("CreateTime").IsRequired();
            builder.Property(e => e.UpdateTime).HasColumnName("UpdateTime");
        }
    }
}