using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RewardRecycle.Migrations
{
    public partial class datetimenullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "bfaccada-c534-43a6-81f1-9ec60163280e", "e9d4cca1-e0ec-44fe-94e6-1669aed89438" });

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastScanDate",
                table: "NfcCardModel",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71431282-15a4-4f1f-86a3-15214cbdd16a", "7674cdbf-b01d-4194-b519-e88f1356ad59", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "71431282-15a4-4f1f-86a3-15214cbdd16a", "7674cdbf-b01d-4194-b519-e88f1356ad59" });

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastScanDate",
                table: "NfcCardModel",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bfaccada-c534-43a6-81f1-9ec60163280e", "e9d4cca1-e0ec-44fe-94e6-1669aed89438", "Admin", "ADMIN" });
        }
    }
}
