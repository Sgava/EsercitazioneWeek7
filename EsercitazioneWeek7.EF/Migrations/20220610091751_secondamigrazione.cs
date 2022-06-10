using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsercitazioneWeek7.EF.Migrations
{
    public partial class secondamigrazione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Prezzo",
                table: "Piatto",
                type: "decimal(9,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Prezzo",
                table: "Piatto",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,2)");
        }
    }
}
