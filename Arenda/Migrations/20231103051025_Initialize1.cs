using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arenda.Migrations
{
    /// <inheritdoc />
    public partial class Initialize1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arendators_Categories_CategoryId",
                table: "Arendators");

            migrationBuilder.DropIndex(
                name: "IX_Arendators_CategoryId",
                table: "Arendators");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Arendators");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Arendators",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Arendators_CategoryId",
                table: "Arendators",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Arendators_Categories_CategoryId",
                table: "Arendators",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
