using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anagrafiche.Api.Migrations;

/// <inheritdoc />
public partial class FirstMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Soggetti",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CodiceFiscale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                DataDiNascita = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Soggetti", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Recapiti",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IdSoggetto = table.Column<int>(type: "int", nullable: false),
                TipoIndirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                NumeroCivico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Cap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Localita = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Recapiti", x => x.Id);
                table.ForeignKey(
                    name: "FK_Recapiti_Soggetti_IdSoggetto",
                    column: x => x.IdSoggetto,
                    principalTable: "Soggetti",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Recapiti_IdSoggetto",
            table: "Recapiti",
            column: "IdSoggetto");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Recapiti");

        migrationBuilder.DropTable(
            name: "Soggetti");
    }
}
