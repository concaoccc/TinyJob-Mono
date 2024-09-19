using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyJobApi.Database.Entity;

namespace TinyJobApi.Database.EntityConfiguration
{
    public class SchedulerConfiguration : IEntityTypeConfiguration<SchedulerDo>
    {
        public void Configure(EntityTypeBuilder<SchedulerDo> builder)
        {
            builder.ToTable("Scheduler");
            builder.HasKey(p => p.Id);
            builder.HasOne(e => e.Package).WithMany(e => e.Schedulers).HasForeignKey(p => p.PackageId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(30).IsRequired();
            builder.Property(p => p.Description).HasColumnName("Description").HasMaxLength(200).IsRequired();
            builder.Property(p => p.Namespace).HasColumnName("Namespace").HasMaxLength(50).IsRequired();
            builder.Property(p => p.AssemblyName).HasColumnName("AssemblyName").HasMaxLength(50).IsRequired();
            builder.Property(p => p.ClassName).HasColumnName("ClassName").HasMaxLength(50).IsRequired();
            builder.Property(p => p.ExecutionPlan).HasColumnName("ExecutionPlan").HasMaxLength(50).IsRequired();
            builder.Property(p => p.ExecutionParams).HasColumnName("ExecutionParams").HasMaxLength(50);
            builder.Property(p => p.NextExecutionTime).HasColumnName("NextExecutionTime");
            builder.Property(p => p.EndTime).HasColumnName("EndTime");
            builder.Property(p => p.PackageId).HasColumnName("PackageId").IsRequired();
            builder.Property(p => p.Type).HasColumnName("Type")
                .HasConversion(v => v.ToString(), v => (SchedulerType) Enum.Parse(typeof(SchedulerType), v))
                .IsRequired();
            builder.Property(p => p.CreateTime).HasColumnName("CreateTime").IsRequired();
            builder.Property(p => p.UpdateTime).HasColumnName("UpdateTime");
        }
    }
}