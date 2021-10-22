using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Persistence.Migrations
{
    public partial class TirMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_StatusId",
                table: "Alunos",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Status_StatusId",
                table: "Alunos",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Status_StatusId",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_StatusId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Alunos");
        }
    }
}
