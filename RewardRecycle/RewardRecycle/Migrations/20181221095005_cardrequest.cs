using Microsoft.EntityFrameworkCore.Migrations;

namespace RewardRecycle.Migrations
{
    public partial class cardrequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c360244b-11a8-462a-9479-c01fd0dc5d5e", "edea1d61-c733-44b6-bf9f-38370e507870" });

            migrationBuilder.RenameColumn(
                name: "CustomTag",
                table: "AspNetUsers",
                newName: "PostalCode");

            migrationBuilder.AddColumn<int>(
                name: "HouseNumber",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99e111a6-0d1c-40c9-99fe-5727d543b6a2", "76a331b3-a029-490a-b973-45349d1afc91", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "99e111a6-0d1c-40c9-99fe-5727d543b6a2", "76a331b3-a029-490a-b973-45349d1afc91" });

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "AspNetUsers",
                newName: "CustomTag");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c360244b-11a8-462a-9479-c01fd0dc5d5e", "edea1d61-c733-44b6-bf9f-38370e507870", "Admin", "ADMIN" });
        }
    }
}
