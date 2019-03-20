using Microsoft.EntityFrameworkCore.Migrations;

namespace RewardRecycle.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ccc65e6d-6ca5-4c4c-b7ab-3c996faf4ff4", "e793bacf-792a-4315-8101-c301129d4228" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c360244b-11a8-462a-9479-c01fd0dc5d5e", "edea1d61-c733-44b6-bf9f-38370e507870", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c360244b-11a8-462a-9479-c01fd0dc5d5e", "edea1d61-c733-44b6-bf9f-38370e507870" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ccc65e6d-6ca5-4c4c-b7ab-3c996faf4ff4", "e793bacf-792a-4315-8101-c301129d4228", "Admin", "ADMIN" });
        }
    }
}
