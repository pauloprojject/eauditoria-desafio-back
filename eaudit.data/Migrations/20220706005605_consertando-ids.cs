using Microsoft.EntityFrameworkCore.Migrations;

namespace eaudit.data.Migrations
{
    public partial class consertandoids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacaos_clientes_ClienteId",
                table: "Locacaos");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacaos_Filmes_FilmeId",
                table: "Locacaos");

            migrationBuilder.DropColumn(
                name: "Id_Cliente",
                table: "Locacaos");

            migrationBuilder.DropColumn(
                name: "Id_Filme",
                table: "Locacaos");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Locacaos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Locacaos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacaos_clientes_ClienteId",
                table: "Locacaos",
                column: "ClienteId",
                principalTable: "clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacaos_Filmes_FilmeId",
                table: "Locacaos",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacaos_clientes_ClienteId",
                table: "Locacaos");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacaos_Filmes_FilmeId",
                table: "Locacaos");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "Locacaos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Locacaos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id_Cliente",
                table: "Locacaos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Filme",
                table: "Locacaos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacaos_clientes_ClienteId",
                table: "Locacaos",
                column: "ClienteId",
                principalTable: "clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacaos_Filmes_FilmeId",
                table: "Locacaos",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
