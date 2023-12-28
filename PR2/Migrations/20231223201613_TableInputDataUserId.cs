using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PR2.Migrations
{
    public partial class TableInputDataUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "InputDatas",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InputDatas");
        }
    }
}
