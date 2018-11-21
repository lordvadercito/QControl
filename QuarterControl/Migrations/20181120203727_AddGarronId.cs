using Microsoft.EntityFrameworkCore.Migrations;

namespace QuarterControl.Migrations
{
    public partial class AddGarronId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GarronID",
                table: "AngusInspect",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GarronID",
                table: "AngusInspect");
        }
    }
}
