using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiJogame_EFC.Migrations
{
    public partial class AltertableJogos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "Jogos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "Jogadores",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "Jogadores");
        }
    }
}
