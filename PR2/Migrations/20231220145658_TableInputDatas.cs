using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PR2.Migrations
{
    public partial class TableInputDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InputDatas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    H = table.Column<double>(type: "REAL", nullable: false),
                    T_MAT = table.Column<double>(type: "REAL", nullable: false),
                    T_GAS = table.Column<double>(type: "REAL", nullable: false),
                    V_GAS = table.Column<double>(type: "REAL", nullable: false),
                    C_GAS = table.Column<double>(type: "REAL", nullable: false),
                    Rashod = table.Column<double>(type: "REAL", nullable: false),
                    C_MAT = table.Column<double>(type: "REAL", nullable: false),
                    koefficient = table.Column<double>(type: "REAL", nullable: false),
                    D_ap = table.Column<double>(type: "REAL", nullable: false),
                    DateAdd = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputDatas", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InputDatas");
        }
    }
}
