using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectCA.Migrations
{
    public partial class CalibrationRecordDto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41feab93-99d2-4155-a4e2-940fd34ea98f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f883a8a6-98b2-44f7-a5c5-7fc4aff77393");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46e7f883-8a49-4ad0-bb58-82deecbe15ee", "3f0b46f6-ce10-4528-8409-6791876af2fc", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5bd2f8a-786a-4434-b857-8edd70ce5f8f", "40a1962a-600e-4974-adb9-db69929f9ba0", "tech", "tech" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "41feab93-99d2-4155-a4e2-940fd34ea98f", "da821d54-b9da-4852-bf8b-b4a805decd7c", "tech", "tech" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f883a8a6-98b2-44f7-a5c5-7fc4aff77393", "518e4df1-69a9-46c0-b11d-373a8161b6a9", "admin", "admin" });
        }
    }
}
