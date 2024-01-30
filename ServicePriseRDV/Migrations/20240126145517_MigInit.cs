using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicePriseRDV.Migrations
{
    public partial class MigInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RendezVous",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomDuPatient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JourHeureRDV = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendezVous", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RendezVous");
        }
    }
}
