using Microsoft.EntityFrameworkCore.Migrations;

namespace BalanceTest.Migrations
{
    public partial class AddDataFixationToAddBalanceDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateData",
                table: "AddBalance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdateData",
                table: "AddBalance",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateData",
                table: "AddBalance");

            migrationBuilder.DropColumn(
                name: "UpdateData",
                table: "AddBalance");
        }
    }
}
