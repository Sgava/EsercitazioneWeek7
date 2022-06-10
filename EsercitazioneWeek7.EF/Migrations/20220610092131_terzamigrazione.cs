using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsercitazioneWeek7.EF.Migrations
{
    public partial class terzamigrazione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Piatto_Menu_MenuId",
                table: "Piatto");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Piatto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Piatto_Menu_MenuId",
                table: "Piatto",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Piatto_Menu_MenuId",
                table: "Piatto");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Piatto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Piatto_Menu_MenuId",
                table: "Piatto",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
