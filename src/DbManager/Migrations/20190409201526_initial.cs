using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbManager.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyMenus",
                columns: table => new
                {
                    DmId = table.Column<Guid>(nullable: false),
                    DmItems = table.Column<string>(nullable: true),
                    DmDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMenus", x => x.DmId);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Level = table.Column<string>(nullable: true),
                    Logger = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogId);
                });

            migrationBuilder.CreateTable(
                name: "FoodProduct",
                columns: table => new
                {
                    MiId = table.Column<Guid>(nullable: false),
                    MiCategory = table.Column<string>(nullable: true),
                    MiImage = table.Column<byte[]>(nullable: true),
                    MiName = table.Column<string>(nullable: true),
                    MiPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodProducts", x => x.MiId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyMenus");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "FoodProducts");
        }
    }
}
