using Microsoft.EntityFrameworkCore.Migrations;

namespace Evona.Task.Identity.Migrations
{
    public partial class AddUsersSecStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a1b43260-a972-4f08-a7c4-3cb92b0067c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e2170eb7-66bd-45f1-99cc-f689ef22c5f3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88301857-6026-411c-ad6e-c137664dece7", "AQAAAAEAACcQAAAAELWhtKm0CwdKqUhP6Az+hC/IK2daecxuyEhnG8w5J3j0cuOWWOEEF3i9Tr3S1bn/4g==", "452e9437-cd3b-4834-aa13-f49fb68348ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dcf5138-f8da-45a8-8593-2d39dae9df35", "AQAAAAEAACcQAAAAEFr/vUrisQVxEdZNjqBWpLpijm6hHfdHqZhoS0mvhreriqPmvUQnbhB8uluFICttDw==", "0574d8df-a799-467b-bda7-e6f238865e44" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c47f0577-351f-4c24-851f-f069ff8bf174");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "cbad1ee0-ae7b-481f-adc9-0ef48cd8b8f9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c3b02aa-d429-4d43-a64a-0b2a8d41b8f9", "AQAAAAEAACcQAAAAEKaS7K37fR6JKn4pwa/qkEST8ynoaRN+iCGCkWA6GR/YnAyBA0IzurJD+LV/TvQAAw==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0c931ed-fcef-4d80-8580-a3279e0f92ed", "AQAAAAEAACcQAAAAEGBvTXGD7k1pzWWDaUW8Jz37l1/CvfJn51L7hVOwNVstOWo4Cx1f3cDDZqdzcEol5w==", null });
        }
    }
}
