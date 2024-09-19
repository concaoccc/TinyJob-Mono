using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TinyJobApi.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Executor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastHeartbeat = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Executor", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Executor",
                columns: new[] { "Id", "CreateTime", "LastHeartbeat", "Name", "Status", "UpdateTime" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MockedExecutor", 1, new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Job",
                columns: new[] { "Id", "ActualExecutionTime", "CreateTime", "ExecutorId", "FinishTime", "Name", "ScheduledExecutionTime", "SchedulerId", "Status", "UpdateTime" },
                values: new object[] { 1L, null, new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "TestJob", new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1L, 3, new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Package",
                columns: new[] { "Id", "CreateTime", "Description", "Name", "OwnerId", "RelativePath", "StorageAccount", "UpdateTime", "Version" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Echo helloworld", "HelloWorld", 1L, "MockedRelativePath", "MockedStorageAccount", new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "1.0.0" });

            migrationBuilder.InsertData(
                table: "Scheduler",
                columns: new[] { "Id", "AssemblyName", "ClassName", "CreateTime", "Description", "EndTime", "ExecutionParams", "ExecutionPlan", "Name", "Namespace", "NextExecutionTime", "PackageId", "Type", "UpdateTime" },
                values: new object[] { 1, "JobExample", "HelloWorldJob", new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "TestScheduler", new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 8, 0, 0, 0)), null, "0 0 12 0 0", "TestScheduler", "JobExample", new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1L, 2, new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateTime", "Email", "Name", "Pwd", "UpdateTime" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "fake@localhost", "DefaultAccount", "DefaultPassword", new DateTimeOffset(new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Executor");

            migrationBuilder.DeleteData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Package",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scheduler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
