using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class final2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DepartmentId", "FirstName", "LastName" },
                values: new object[] { 1, 1, "John", "Doe" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DepartmentId", "FirstName", "LastName" },
                values: new object[] { 2, 1, "Mira", "Doe" });

            migrationBuilder.InsertData(
                table: "Finals",
                columns: new[] { "Id", "CourseId", "Date", "Mark", "Name", "StudentId" },
                values: new object[] { 1, 1, new DateTime(2021, 6, 26, 17, 58, 33, 808, DateTimeKind.Local).AddTicks(388), 10, "Primer polaganja", 1 });

            migrationBuilder.InsertData(
                table: "Finals",
                columns: new[] { "Id", "CourseId", "Date", "Mark", "Name", "StudentId" },
                values: new object[] { 3, 3, new DateTime(2021, 6, 26, 17, 58, 33, 811, DateTimeKind.Local).AddTicks(9823), 10, "Primer polaganja", 1 });

            migrationBuilder.InsertData(
                table: "Finals",
                columns: new[] { "Id", "CourseId", "Date", "Mark", "Name", "StudentId" },
                values: new object[] { 2, 2, new DateTime(2021, 6, 26, 17, 58, 33, 811, DateTimeKind.Local).AddTicks(9735), 10, "Primer polaganja", 2 });
        }
    }
}
