using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetWebApi.Migrations
{
    /// <inheritdoc />
    public partial class upUtilisateur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "utilisateur");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "utilisateur",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
