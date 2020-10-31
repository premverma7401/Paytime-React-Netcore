using Microsoft.EntityFrameworkCore.Migrations;

namespace Paytime.Persistence.Migrations
{
    public partial class updatedFieldTS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Timesheets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Timesheets");
        }
    }
}
