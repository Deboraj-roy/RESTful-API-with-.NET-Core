using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP_BasicAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedPersonDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Age", "CreatedDate", "Details", "Gender", "ImageUrl", "Name", "Occupation", "Salary", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 30, new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9106), "Software Engineer", "M", "https://example.com/john-doe.jpg", "John Doe", "Engineer", 75000.0, new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9114) },
                    { 2, 28, new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9117), "Data Scientist", "F", "https://example.com/jane-smith.jpg", "Jane Smith", "Data Scientist", 80000.0, new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9117) },
                    { 3, 35, new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9119), "Doctor", "M", "https://example.com/michael-johnson.jpg", "Michael Johnson", "Doctor", 120000.0, new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9119) },
                    { 4, 25, new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9121), "Teacher", "F", "https://example.com/emily-brown.jpg", "Emily Brown", "Teacher", 50000.0, new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9121) },
                    { 5, 40, new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9122), "Lawyer", "M", "https://example.com/david-wilson.jpg", "David Wilson", "Lawyer", 100000.0, new DateTime(2024, 2, 28, 20, 58, 46, 11, DateTimeKind.Local).AddTicks(9123) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
