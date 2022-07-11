using Microsoft.EntityFrameworkCore.Migrations;

namespace eaudit.data.Migrations
{
    public partial class indexeserelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Locacaos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmeId",
                table: "Locacaos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locacaos_ClienteId",
                table: "Locacaos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacaos_FilmeId",
                table: "Locacaos",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_Cpf",
                table: "clientes",
                column: "Cpf");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_Nome",
                table: "clientes",
                column: "Nome");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacaos_clientes_ClienteId",
                table: "Locacaos");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacaos_Filmes_FilmeId",
                table: "Locacaos");

            migrationBuilder.DropIndex(
                name: "IX_Locacaos_ClienteId",
                table: "Locacaos");

            migrationBuilder.DropIndex(
                name: "IX_Locacaos_FilmeId",
                table: "Locacaos");

            migrationBuilder.DropIndex(
                name: "IX_clientes_Cpf",
                table: "clientes");

            migrationBuilder.DropIndex(
                name: "IX_clientes_Nome",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Locacaos");

            migrationBuilder.DropColumn(
                name: "FilmeId",
                table: "Locacaos");
        }
    }
}
