using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyJobApi.Database.Entity;

namespace TinyJobApi.Database.EntityConfiguration
{
    public class ExecutorConfiguration : IEntityTypeConfiguration<ExecutorDo>
    {
        public void Configure(EntityTypeBuilder<ExecutorDo> builder)
        {
            builder.ToTable("Executor");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(30).IsRequired();
            builder.Property(p => p.LastHeartbeat).HasColumnName("LastHeartbeat");
            builder.Property(p => p.Status).HasColumnName("Status")
                .HasConversion(v => v.ToString(), v=> (ExecutorStatus)Enum.Parse(typeof(ExecutorStatus), v))
                .IsRequired();
            builder.Property(p => p.CreateTime).HasColumnName("CreateTime").IsRequired();
            builder.Property(p => p.UpdateTime).HasColumnName("UpdateTime");
        }
    }
}