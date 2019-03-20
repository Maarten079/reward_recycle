using Microsoft.EntityFrameworkCore.Migrations;

namespace RewardRecycle.Migrations
{
    public partial class registrationtags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "71431282-15a4-4f1f-86a3-15214cbdd16a", "7674cdbf-b01d-4194-b519-e88f1356ad59" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ec1e431-4702-44fb-9cd0-37cd065f011d", "9b3988a8-23b1-410b-bf13-1b29a0f0912d", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "9ec1e431-4702-44fb-9cd0-37cd065f011d", "9b3988a8-23b1-410b-bf13-1b29a0f0912d" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71431282-15a4-4f1f-86a3-15214cbdd16a", "7674cdbf-b01d-4194-b519-e88f1356ad59", "Admin", "ADMIN" });
        }
    }
}
