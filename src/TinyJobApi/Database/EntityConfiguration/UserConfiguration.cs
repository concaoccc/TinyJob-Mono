using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TinyJobApi.Database.Entity;

namespace TinyJobApi.Database.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserDo>
    {
        public void Configure(EntityTypeBuilder<UserDo> builder)
        {
            builder.ToTable("User");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.UserName).IsUnique();
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.UserName).HasColumnName("Username").HasMaxLength(30).IsRequired();
            builder.Property(e => e.Password).HasColumnName("Password").HasMaxLength(30).IsRequired();
            builder.Property(e => e.Email).HasColumnName("Email").HasMaxLength(30);
            builder.Property(e => e.CreateTime).HasColumnName("CreateTime").IsRequired();
            builder.Property(e => e.UpdateTime).HasColumnName("UpdateTime");
        }
    }
}