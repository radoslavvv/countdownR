using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace countdownR.API.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Countdowns",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DigitsColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TilesColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                BackgroundImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                BackgroundImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Countdowns", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Countdowns");
    }
}
