using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProject.Migrations
{
    public partial class updatestuff7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_Universities_UniversityId",
                table: "SocialMedias");

            migrationBuilder.DropIndex(
                name: "IX_SocialMedias_UniversityId",
                table: "SocialMedias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_UniversityId",
                table: "SocialMedias",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_Universities_UniversityId",
                table: "SocialMedias",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "UniversityId");
        }
    }
}
