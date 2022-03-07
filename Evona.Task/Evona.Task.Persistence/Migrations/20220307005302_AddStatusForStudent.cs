using Microsoft.EntityFrameworkCore.Migrations;

namespace Evona.Task.Persistence.Migrations
{
    public partial class AddStatusForStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackupStatus",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackupStatus",
                table: "StudentBackups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFromStudentTable",
                table: "StudentBackups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "BackupStatus",
                value: "Created");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "BackupStatus",
                value: "Created");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackupStatus",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BackupStatus",
                table: "StudentBackups");

            migrationBuilder.DropColumn(
                name: "IdFromStudentTable",
                table: "StudentBackups");
        }
    }
}
