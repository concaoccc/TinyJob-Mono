using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyJobApi.Database.Entity;

namespace TinyJobApi.Database.EntityConfiguration
{
    public class JobConfiguration : IEntityTypeConfiguration<JobDo>
    {
        public void Configure(EntityTypeBuilder<JobDo> builder)
        {
            builder.ToTable("Job");
            builder.HasKey(p => p.Id);
            builder.HasOne(e => e.Executor).WithMany(e => e.Jobs).HasForeignKey(p => p.ExecutorId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Scheduler).WithMany(e => e.Jobs).HasForeignKey(p => p.SchedulerId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(30).IsRequired();
            builder.Property(p => p.ExecutorId);
            builder.Property(p => p.SchedulerId).IsRequired();
            builder.Property(p => p.Status).HasColumnName("Status")
                .HasConversion(v => v.ToString(), v => (JobStatus) Enum.Parse(typeof(JobStatus), v))
                .IsRequired();
            builder.Property(p => p.CreateTime).HasColumnName("CreateTime").IsRequired();
            builder.Property(p => p.UpdateTime).HasColumnName("UpdateTime");
            builder.Property(p => p.FinishTime).HasColumnName("FinishTime");
        }
    }
}