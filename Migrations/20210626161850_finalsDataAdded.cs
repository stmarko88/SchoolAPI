using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class finalsDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Finals",
                columns: new[] { "Id", "CourseId", "Date", "Mark", "Name", "StudentId" },
                values: new object[] { 1, 1, new DateTime(2021, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), 10, "Primer polaganja", 1 });

            migrationBuilder.InsertData(
                table: "Finals",
                columns: new[] { "Id", "CourseId", "Date", "Mark", "Name", "StudentId" },
                values: new object[] { 2, 1, new DateTime(2021, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), 10, "Primer polaganja", 2 });

            migrationBuilder.InsertData(
                table: "Finals",
                columns: new[] { "Id", "CourseId", "Date", "Mark", "Name", "StudentId" },
                values: new object[] { 3, 2, new DateTime(2021, 6, 26, 0, 0, 0, 0, DateTimeKind.Local), 10, "Primer polaganja", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Finals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Finals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Finals",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
