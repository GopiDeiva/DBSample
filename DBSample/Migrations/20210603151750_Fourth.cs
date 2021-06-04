using Microsoft.EntityFrameworkCore.Migrations;

namespace DBSample.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           // migrationBuilder.AddColumn<string>("Address", "Users", nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Address", "Users");
        }
    }
}
