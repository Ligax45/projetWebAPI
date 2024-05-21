using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetWebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Utilisateurid",
                table: "profil",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_profil_Utilisateurid",
                table: "profil",
                column: "Utilisateurid");

            migrationBuilder.AddForeignKey(
                name: "FK_profil_utilisateur_Utilisateurid",
                table: "profil",
                column: "Utilisateurid",
                principalTable: "utilisateur",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profil_utilisateur_Utilisateurid",
                table: "profil");

            migrationBuilder.DropIndex(
                name: "IX_profil_Utilisateurid",
                table: "profil");

            migrationBuilder.DropColumn(
                name: "Utilisateurid",
                table: "profil");
        }
    }
}
