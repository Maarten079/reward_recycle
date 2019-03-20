using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RewardRecycle.Migrations
{
    public partial class nfccards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "99e111a6-0d1c-40c9-99fe-5727d543b6a2", "76a331b3-a029-490a-b973-45349d1afc91" });

            migrationBuilder.CreateTable(
                name: "NfcCardModel",
                columns: table => new
                {
                    CardId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationUserModelId = table.Column<string>(nullable: true),
                    LastScanDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NfcCardModel", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_NfcCardModel_AspNetUsers_ApplicationUserModelId",
                        column: x => x.ApplicationUserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bfaccada-c534-43a6-81f1-9ec60163280e", "e9d4cca1-e0ec-44fe-94e6-1669aed89438", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_NfcCardModel_ApplicationUserModelId",
                table: "NfcCardModel",
                column: "ApplicationUserModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NfcCardModel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "bfaccada-c534-43a6-81f1-9ec60163280e", "e9d4cca1-e0ec-44fe-94e6-1669aed89438" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99e111a6-0d1c-40c9-99fe-5727d543b6a2", "76a331b3-a029-490a-b973-45349d1afc91", "Admin", "ADMIN" });
        }
    }
}
