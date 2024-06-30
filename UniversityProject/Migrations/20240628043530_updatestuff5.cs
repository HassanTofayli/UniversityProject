using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProject.Migrations
{
    public partial class updatestuff5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managements_Universities_UniversityId",
                table: "Managements");

            migrationBuilder.DropIndex(
                name: "IX_Managements_UniversityId",
                table: "Managements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Managements_UniversityId",
                table: "Managements",
                column: "UniversityId",
                unique: true,
                filter: "[UniversityId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Managements_Universities_UniversityId",
                table: "Managements",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "UniversityId");
        }
    }
}
