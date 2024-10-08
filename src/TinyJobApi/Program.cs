using Microsoft.EntityFrameworkCore;
using Serilog;
using TinyJobApi.Database;
using TinyJobApi.Middleware;
using TinyJobApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Add router with lowercase urls
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IJobService, JobServiceImp>();
builder.Services.AddScoped<IPackageService, PackageServiceImp>();
builder.Services.AddScoped<ISchedulerService, SchedulerServiceImp>();

// Add logger
// log trace in console
// builder.Logging.ClearProviders();
// var logger = new LoggerConfiguration()
//     .MinimumLevel.Debug()
//     .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/log.txt"), rollingInterval: RollingInterval.Day, retainedFileCountLimit: 90)
//     .WriteTo.Console()
//     .CreateLogger();
// builder.Logging.AddSerilog(logger);

// Add database
var pgsqlConnectionString = builder.Configuration.GetConnectionString("PostgreSQL");
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(pgsqlConnectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.UseCorrelationId();

app.Run();
