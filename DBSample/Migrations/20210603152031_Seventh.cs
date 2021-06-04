using Microsoft.EntityFrameworkCore.Migrations;

namespace DBSample.Migrations
{
    public partial class Seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>("Address", "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn("Address", "Users");
        }
    }
}
