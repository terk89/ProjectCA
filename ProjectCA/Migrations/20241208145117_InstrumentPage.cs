using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectCA.Migrations
{
    public partial class InstrumentPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalibrationRecords_AspNetUsers_ApplicationUserId",
                table: "CalibrationRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_AspNetUsers_ApplicationUserId",
                table: "EquipmentItems");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentItems_ApplicationUserId",
                table: "EquipmentItems");

            migrationBuilder.DropIndex(
                name: "IX_CalibrationRecords_ApplicationUserId",
                table: "CalibrationRecords");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86f132b0-04b3-47be-8910-71fae628859c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db34d5df-33b4-48da-ba99-58e6154aec66");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "EquipmentItems");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "CalibrationRecords");

            migrationBuilder.AlterColumn<string>(
                name: "TechnicalLevel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41feab93-99d2-4155-a4e2-940fd34ea98f", "da821d54-b9da-4852-bf8b-b4a805decd7c", "tech", "tech" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f883a8a6-98b2-44f7-a5c5-7fc4aff77393", "518e4df1-69a9-46c0-b11d-373a8161b6a9", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41feab93-99d2-4155-a4e2-940fd34ea98f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f883a8a6-98b2-44f7-a5c5-7fc4aff77393");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "EquipmentItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "CalibrationRecords",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TechnicalLevel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86f132b0-04b3-47be-8910-71fae628859c", "8a0bdcfe-f715-4821-9c7a-210e19090014", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db34d5df-33b4-48da-ba99-58e6154aec66", "27dc591b-923f-4f4a-b9da-c15d6cdf6270", "tech", "tech" });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItems_ApplicationUserId",
                table: "EquipmentItems",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CalibrationRecords_ApplicationUserId",
                table: "CalibrationRecords",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalibrationRecords_AspNetUsers_ApplicationUserId",
                table: "CalibrationRecords",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_AspNetUsers_ApplicationUserId",
                table: "EquipmentItems",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
