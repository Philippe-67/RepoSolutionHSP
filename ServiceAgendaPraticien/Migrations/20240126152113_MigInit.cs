using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceAgendaPraticien.Migrations
{
    public partial class MigInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Praticien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPraticien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrenomPraticien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialitePraticien = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Praticien", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Praticien");
        }
    }
}
