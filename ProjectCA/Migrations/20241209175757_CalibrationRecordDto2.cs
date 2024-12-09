using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectCA.Migrations
{
    public partial class CalibrationRecordDto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46e7f883-8a49-4ad0-bb58-82deecbe15ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5bd2f8a-786a-4434-b857-8edd70ce5f8f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5346e156-ff88-42a1-a9f7-8c5cd8db90aa", "6c71d2d4-f469-4a8d-aa02-ddac479bb499", "tech", "tech" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf6fade0-af60-45bf-ba1d-5fd2cde4de12", "f265c66f-c62e-4195-91c8-64e5c4a17053", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5346e156-ff88-42a1-a9f7-8c5cd8db90aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf6fade0-af60-45bf-ba1d-5fd2cde4de12");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46e7f883-8a49-4ad0-bb58-82deecbe15ee", "3f0b46f6-ce10-4528-8409-6791876af2fc", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5bd2f8a-786a-4434-b857-8edd70ce5f8f", "40a1962a-600e-4974-adb9-db69929f9ba0", "tech", "tech" });
        }
    }
}
