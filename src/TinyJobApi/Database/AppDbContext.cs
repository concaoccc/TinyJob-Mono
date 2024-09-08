using Microsoft.EntityFrameworkCore;
using System;
using TinyJobApi.Database.Entity;

namespace TinyJobApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<PackageDo> Packages { get; set; }
    public DbSet<UserDo> Users { get; set; }
    public DbSet<JobDo> Jobs { get; set; }
    public DbSet<SchedulerDo> Schedulers { get; set; }
}
