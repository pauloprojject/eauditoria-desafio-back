using Microsoft.EntityFrameworkCore.Migrations;

namespace eaudit.data.Migrations
{
    public partial class esquecidosmapeamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacaos_clientes_ClienteId",
                table: "Locacaos");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacaos_Filmes_FilmeId",
                table: "Locacaos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locacaos",
                table: "Locacaos");

            migrationBuilder.RenameTable(
                name: "Filmes",
                newName: "filmes");

            migrationBuilder.RenameTable(
                name: "Locacaos",
                newName: "locacao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "filmes",
                newName: "FilmesId");

            migrationBuilder.RenameColumn(
                name: "FilmeId",
                table: "locacao",
                newName: "Id_Filme");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "locacao",
                newName: "Id_Cliente");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "locacao",
                newName: "LocacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Locacaos_FilmeId",
                table: "locacao",
                newName: "IX_locacao_Id_Filme");

            migrationBuilder.RenameIndex(
                name: "IX_Locacaos_ClienteId",
                table: "locacao",
                newName: "IX_locacao_Id_Cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "filmes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_filmes",
                table: "filmes",
                column: "FilmesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_locacao",
                table: "locacao",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_filmes_Lancamento",
                table: "filmes",
                column: "Lancamento");

            migrationBuilder.CreateIndex(
                name: "IX_filmes_Titulo",
                table: "filmes",
                column: "Titulo");

            migrationBuilder.AddForeignKey(
                name: "FK_locacao_clientes_Id_Cliente",
                table: "locacao",
                column: "Id_Cliente",
                principalTable: "clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_locacao_filmes_Id_Filme",
                table: "locacao",
                column: "Id_Filme",
                principalTable: "filmes",
                principalColumn: "FilmesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locacao_clientes_Id_Cliente",
                table: "locacao");

            migrationBuilder.DropForeignKey(
                name: "FK_locacao_filmes_Id_Filme",
                table: "locacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_filmes",
                table: "filmes");

            migrationBuilder.DropIndex(
                name: "IX_filmes_Lancamento",
                table: "filmes");

            migrationBuilder.DropIndex(
                name: "IX_filmes_Titulo",
                table: "filmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_locacao",
                table: "locacao");

            migrationBuilder.RenameTable(
                name: "filmes",
                newName: "Filmes");

            migrationBuilder.RenameTable(
                name: "locacao",
                newName: "Locacaos");

            migrationBuilder.RenameColumn(
                name: "FilmesId",
                table: "Filmes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Id_Filme",
                table: "Locacaos",
                newName: "FilmeId");

            migrationBuilder.RenameColumn(
                name: "Id_Cliente",
                table: "Locacaos",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "LocacaoId",
                table: "Locacaos",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_locacao_Id_Filme",
                table: "Locacaos",
                newName: "IX_Locacaos_FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_locacao_Id_Cliente",
                table: "Locacaos",
                newName: "IX_Locacaos_ClienteId");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Filmes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locacaos",
                table: "Locacaos",
                column: "Id");

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
    }
}
