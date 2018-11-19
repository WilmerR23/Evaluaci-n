using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GH.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamenPregunta",
                table: "ExamenPregunta");

            migrationBuilder.DropIndex(
                name: "IX_ExamenPregunta_ExamenId",
                table: "ExamenPregunta");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ExamenPregunta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamenPregunta",
                table: "ExamenPregunta",
                columns: new[] { "ExamenId", "PreguntaId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamenPregunta",
                table: "ExamenPregunta");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ExamenPregunta",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamenPregunta",
                table: "ExamenPregunta",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenPregunta_ExamenId",
                table: "ExamenPregunta",
                column: "ExamenId");
        }
    }
}
