using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Evona.Task.Persistence.Migrations
{
    public partial class Initv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BackupStatus", "BirthDate", "CreatedBy", "DateCreated", "FirstName", "JMBG", "LastModifiedBy", "LastModifiedDate", "LastName" },
                values: new object[,]
                {
                    { 1, "Created", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "1411955412829", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith" },
                    { 2, "Created", new DateTime(2000, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jennifer", "1507911427827", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Williams" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
