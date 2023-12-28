using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PR2.Migrations
{
    public partial class TableInputDataName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "InputDatas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "InputDatas");
        }
    }
}
