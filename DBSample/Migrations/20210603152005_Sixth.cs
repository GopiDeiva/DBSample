using Microsoft.EntityFrameworkCore.Migrations;

namespace DBSample.Migrations
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Address", "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
