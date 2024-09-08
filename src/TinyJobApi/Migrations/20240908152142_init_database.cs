using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TinyJobApi.Migrations
{
    /// <inheritdoc />
    public partial class init_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SchedulerId = table.Column<long>(type: "bigint", nullable: false),
                    ExecutorId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ScheduledExecutionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActualExecutionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FinishTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Version = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    StorageAccount = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RelativePath = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scheduler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    PackageId = table.Column<long>(type: "bigint", nullable: false),
                    AssemblyName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Namespace = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ClassName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ExecutionPlan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ExecutionParams = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NextExecutionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scheduler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Pwd = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Package_OwnerId_Name_Version",
                table: "Package",
                columns: new[] { "OwnerId", "Name", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scheduler_PackageId_Name",
                table: "Scheduler",
                columns: new[] { "PackageId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Name",
                table: "User",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Scheduler");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
