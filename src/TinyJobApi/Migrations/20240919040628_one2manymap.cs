using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyJobApi.Migrations
{
    /// <inheritdoc />
    public partial class one2manymap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Name",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Scheduler_PackageId_Name",
                table: "Scheduler");

            migrationBuilder.DropIndex(
                name: "IX_Package_OwnerId_Name_Version",
                table: "Package");

            migrationBuilder.RenameColumn(
                name: "Pwd",
                table: "User",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "Password");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Scheduler",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PackageId",
                table: "Scheduler",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Package",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Job",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "SchedulerId",
                table: "Job",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Job",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ExecutorId",
                table: "Job",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Executor",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Executor",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Executor",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Online");

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ExecutorId", "SchedulerId", "Status" },
                values: new object[] { null, 1, "WaitForExecution" });

            migrationBuilder.UpdateData(
                table: "Package",
                keyColumn: "Id",
                keyValue: 1,
                column: "OwnerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scheduler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PackageId", "Type" },
                values: new object[] { 1, "Cron" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Username" },
                values: new object[] { "DefaultPassword", "DefaultAccount" });

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scheduler_PackageId",
                table: "Scheduler",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_Name_OwnerId_Version",
                table: "Package",
                columns: new[] { "Name", "OwnerId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Package_OwnerId",
                table: "Package",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_ExecutorId",
                table: "Job",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_SchedulerId",
                table: "Job",
                column: "SchedulerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Executor_ExecutorId",
                table: "Job",
                column: "ExecutorId",
                principalTable: "Executor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Scheduler_SchedulerId",
                table: "Job",
                column: "SchedulerId",
                principalTable: "Scheduler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Package_User_OwnerId",
                table: "Package",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduler_Package_PackageId",
                table: "Scheduler",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Executor_ExecutorId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Scheduler_SchedulerId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_User_OwnerId",
                table: "Package");

            migrationBuilder.DropForeignKey(
                name: "FK_Scheduler_Package_PackageId",
                table: "Scheduler");

            migrationBuilder.DropIndex(
                name: "IX_User_Username",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Scheduler_PackageId",
                table: "Scheduler");

            migrationBuilder.DropIndex(
                name: "IX_Package_Name_OwnerId_Version",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_Package_OwnerId",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_Job_ExecutorId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_SchedulerId",
                table: "Job");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "Pwd");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Scheduler",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "PackageId",
                table: "Scheduler",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "OwnerId",
                table: "Package",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Job",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "SchedulerId",
                table: "Job",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Job",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<long>(
                name: "ExecutorId",
                table: "Job",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Executor",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Executor",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.UpdateData(
                table: "Executor",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Job",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ExecutorId", "SchedulerId", "Status" },
                values: new object[] { null, 1L, 3 });

            migrationBuilder.UpdateData(
                table: "Package",
                keyColumn: "Id",
                keyValue: 1,
                column: "OwnerId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Scheduler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PackageId", "Type" },
                values: new object[] { 1L, 2 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Pwd" },
                values: new object[] { "DefaultAccount", "DefaultPassword" });

            migrationBuilder.CreateIndex(
                name: "IX_User_Name",
                table: "User",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scheduler_PackageId_Name",
                table: "Scheduler",
                columns: new[] { "PackageId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Package_OwnerId_Name_Version",
                table: "Package",
                columns: new[] { "OwnerId", "Name", "Version" },
                unique: true);
        }
    }
}
