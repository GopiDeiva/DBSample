using Microsoft.EntityFrameworkCore.Migrations;

namespace DBSample.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Address", "Users");
            migrationBuilder.AddColumn<string>("Address", "Users", nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
