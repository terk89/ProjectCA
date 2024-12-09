using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectCA.Migrations
{
    public partial class EquipmentItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalibrationRecord_EquipmentItem_EquipmentID",
                table: "CalibrationRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_CalibrationRecord_IdentityUser_UserID",
                table: "CalibrationRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItem_IdentityUser_UserID",
                table: "EquipmentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItem_InstrumentType_InstrumentTypeID",
                table: "EquipmentItem");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItem_Manufacturer_ManufacturerID",
                table: "EquipmentItem");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturer",
                table: "Manufacturer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstrumentType",
                table: "InstrumentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentItem",
                table: "EquipmentItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalibrationRecord",
                table: "CalibrationRecord");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0b179dc-abb6-4eba-b4c6-4876de4d5cf3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fabb785f-8818-4d92-822b-a426ce7e3489");

            migrationBuilder.RenameTable(
                name: "Manufacturer",
                newName: "Manufacturers");

            migrationBuilder.RenameTable(
                name: "InstrumentType",
                newName: "InstrumentTypes");

            migrationBuilder.RenameTable(
                name: "EquipmentItem",
                newName: "EquipmentItems");

            migrationBuilder.RenameTable(
                name: "CalibrationRecord",
                newName: "CalibrationRecords");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItem_UserID",
                table: "EquipmentItems",
                newName: "IX_EquipmentItems_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItem_ManufacturerID",
                table: "EquipmentItems",
                newName: "IX_EquipmentItems_ManufacturerID");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItem_InstrumentTypeID",
                table: "EquipmentItems",
                newName: "IX_EquipmentItems_InstrumentTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_CalibrationRecord_UserID",
                table: "CalibrationRecords",
                newName: "IX_CalibrationRecords_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_CalibrationRecord_EquipmentID",
                table: "CalibrationRecords",
                newName: "IX_CalibrationRecords_EquipmentID");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers",
                column: "ManufacturerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstrumentTypes",
                table: "InstrumentTypes",
                column: "InstrumentTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentItems",
                table: "EquipmentItems",
                column: "EquipmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalibrationRecords",
                table: "CalibrationRecords",
                column: "CalibrationRecordID");

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
                name: "FK_CalibrationRecords_AspNetUsers_UserID",
                table: "CalibrationRecords",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CalibrationRecords_EquipmentItems_EquipmentID",
                table: "CalibrationRecords",
                column: "EquipmentID",
                principalTable: "EquipmentItems",
                principalColumn: "EquipmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_AspNetUsers_ApplicationUserId",
                table: "EquipmentItems",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_AspNetUsers_UserID",
                table: "EquipmentItems",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_InstrumentTypes_InstrumentTypeID",
                table: "EquipmentItems",
                column: "InstrumentTypeID",
                principalTable: "InstrumentTypes",
                principalColumn: "InstrumentTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItems_Manufacturers_ManufacturerID",
                table: "EquipmentItems",
                column: "ManufacturerID",
                principalTable: "Manufacturers",
                principalColumn: "ManufacturerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalibrationRecords_AspNetUsers_ApplicationUserId",
                table: "CalibrationRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CalibrationRecords_AspNetUsers_UserID",
                table: "CalibrationRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CalibrationRecords_EquipmentItems_EquipmentID",
                table: "CalibrationRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_AspNetUsers_ApplicationUserId",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_AspNetUsers_UserID",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_InstrumentTypes_InstrumentTypeID",
                table: "EquipmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentItems_Manufacturers_ManufacturerID",
                table: "EquipmentItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstrumentTypes",
                table: "InstrumentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentItems",
                table: "EquipmentItems");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentItems_ApplicationUserId",
                table: "EquipmentItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalibrationRecords",
                table: "CalibrationRecords");

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

            migrationBuilder.RenameTable(
                name: "Manufacturers",
                newName: "Manufacturer");

            migrationBuilder.RenameTable(
                name: "InstrumentTypes",
                newName: "InstrumentType");

            migrationBuilder.RenameTable(
                name: "EquipmentItems",
                newName: "EquipmentItem");

            migrationBuilder.RenameTable(
                name: "CalibrationRecords",
                newName: "CalibrationRecord");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItems_UserID",
                table: "EquipmentItem",
                newName: "IX_EquipmentItem_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItems_ManufacturerID",
                table: "EquipmentItem",
                newName: "IX_EquipmentItem_ManufacturerID");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentItems_InstrumentTypeID",
                table: "EquipmentItem",
                newName: "IX_EquipmentItem_InstrumentTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_CalibrationRecords_UserID",
                table: "CalibrationRecord",
                newName: "IX_CalibrationRecord_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_CalibrationRecords_EquipmentID",
                table: "CalibrationRecord",
                newName: "IX_CalibrationRecord_EquipmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturer",
                table: "Manufacturer",
                column: "ManufacturerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstrumentType",
                table: "InstrumentType",
                column: "InstrumentTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentItem",
                table: "EquipmentItem",
                column: "EquipmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalibrationRecord",
                table: "CalibrationRecord",
                column: "CalibrationRecordID");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0b179dc-abb6-4eba-b4c6-4876de4d5cf3", "2a06b725-6f72-4fea-9ebb-beaee10496ce", "tech", "tech" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fabb785f-8818-4d92-822b-a426ce7e3489", "61d8d81f-a445-4dba-9bfa-04a2783dfbbf", "admin", "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_CalibrationRecord_EquipmentItem_EquipmentID",
                table: "CalibrationRecord",
                column: "EquipmentID",
                principalTable: "EquipmentItem",
                principalColumn: "EquipmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CalibrationRecord_IdentityUser_UserID",
                table: "CalibrationRecord",
                column: "UserID",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItem_IdentityUser_UserID",
                table: "EquipmentItem",
                column: "UserID",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItem_InstrumentType_InstrumentTypeID",
                table: "EquipmentItem",
                column: "InstrumentTypeID",
                principalTable: "InstrumentType",
                principalColumn: "InstrumentTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentItem_Manufacturer_ManufacturerID",
                table: "EquipmentItem",
                column: "ManufacturerID",
                principalTable: "Manufacturer",
                principalColumn: "ManufacturerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
