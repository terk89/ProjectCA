using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectCA.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "1ed26c5c-9f4b-4a8d-9b00-e55c74406e16", "294650a1-d1df-4ae7-8758-ab73988be07c", "tech", "tech" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ced664e6-5e15-43ae-9ceb-4eae99701533", "b53fe69f-6b5f-4904-adaf-290e761a537e", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ed26c5c-9f4b-4a8d-9b00-e55c74406e16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ced664e6-5e15-43ae-9ceb-4eae99701533");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5346e156-ff88-42a1-a9f7-8c5cd8db90aa", "6c71d2d4-f469-4a8d-aa02-ddac479bb499", "tech", "tech" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf6fade0-af60-45bf-ba1d-5fd2cde4de12", "f265c66f-c62e-4195-91c8-64e5c4a17053", "admin", "admin" });
        }
    }
}
