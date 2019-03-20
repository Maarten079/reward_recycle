using Microsoft.EntityFrameworkCore.Migrations;

namespace RewardRecycle.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "99e111a6-0d1c-40c9-99fe-5727d543b6a2", "76a331b3-a029-490a-b973-45349d1afc91" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fcfb001d-cc9c-4fee-8d4f-c25a3cc871ad", "7e88600d-ed3d-4d88-8195-b0cc852e6880", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "fcfb001d-cc9c-4fee-8d4f-c25a3cc871ad", "7e88600d-ed3d-4d88-8195-b0cc852e6880" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99e111a6-0d1c-40c9-99fe-5727d543b6a2", "76a331b3-a029-490a-b973-45349d1afc91", "Admin", "ADMIN" });
        }
    }
}
