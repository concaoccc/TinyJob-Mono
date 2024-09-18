using Microsoft.EntityFrameworkCore;
using TinyJobApi.Database.Entity;

namespace TinyJobApi.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<PackageDo> Packages { get; set; }
    public DbSet<UserDo> Users { get; set; }
    public DbSet<JobDo> Jobs { get; set; }
    public DbSet<SchedulerDo> Schedulers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // new DateTimeOffset(2023,9,11) is a fake time
        var time = new DateTimeOffset(2023, 9, 11, 0, 0, 0, TimeSpan.Zero);

        var defaultUser = new UserDo
        {
            Id = 1,
            Name = "DefaultAccount",
            Pwd = "DefaultPassword",
            Email = "fake@localhost",
            CreateTime = time,
            UpdateTime = time
        };
        modelBuilder.Entity<UserDo>().HasData(defaultUser);

        var mockedExecutor = new ExecutorDo
        {
            Id = 1,
            Name = "MockedExecutor",
            LastHeartbeat = time,
            Status = ExecutorStatus.Online,
            CreateTime = time,
            UpdateTime = time
        };
        modelBuilder.Entity<ExecutorDo>().HasData(mockedExecutor);

        var defaultPackage = new PackageDo
        {
            Id = 1,
            Name = "HelloWorld",
            Version = "1.0.0",
            Description = "Echo helloworld",
            OwnerId = defaultUser.Id,
            StorageAccount = "MockedStorageAccount",
            RelativePath = "MockedRelativePath",
            CreateTime = time,
            UpdateTime = time
        };
        modelBuilder.Entity<PackageDo>().HasData(defaultPackage);

        var testScheduler = new SchedulerDo
        {
            Id = 1,
            Name = "TestScheduler",
            Description = "TestScheduler",
            Type = SchedulerType.Cron,
            PackageId = defaultPackage.Id,
            AssemblyName = "JobExample",
            Namespace = "JobExample",
            ClassName = "HelloWorldJob",
            ExecutionPlan = "0 0 12 0 0",
            NextExecutionTime = time,
            CreateTime = time,
            UpdateTime = time,
            EndTime = DateTime.MaxValue
        };
        modelBuilder.Entity<SchedulerDo>().HasData(testScheduler);

        var testJob = new JobDo
        {
            Id = 1,
            Name = "TestJob",
            SchedulerId = testScheduler.Id,
            Status = JobStatus.WaitForExecution,
            ScheduledExecutionTime = time,
            CreateTime = time,
            UpdateTime = time
        };
        modelBuilder.Entity<JobDo>().HasData(testJob);
    }
}