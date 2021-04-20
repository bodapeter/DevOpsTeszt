using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloWord.Dal.Migrations
{
    public partial class AddSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Greetings",
                columns: new[] { "Id", "Name", "TimeStamp" },
                values: new object[] { 1, "Peti", new DateTime(2020, 11, 20, 15, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Greetings",
                columns: new[] { "Id", "Name", "TimeStamp" },
                values: new object[] { 2, "Tomi", new DateTime(2020, 11, 20, 15, 30, 10, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Greetings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Greetings",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
