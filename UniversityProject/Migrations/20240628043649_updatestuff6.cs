using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProject.Migrations
{
    public partial class updatestuff6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SocialMedias_UniversityId",
                table: "SocialMedias");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_UniversityId",
                table: "SocialMedias",
                column: "UniversityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SocialMedias_UniversityId",
                table: "SocialMedias");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_UniversityId",
                table: "SocialMedias",
                column: "UniversityId",
                unique: true,
                filter: "[UniversityId] IS NOT NULL");
        }
    }
}
