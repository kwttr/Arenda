using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arenda.Migrations
{
    /// <inheritdoc />
    public partial class AddStreetToBuilding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StreetId",
                table: "Buildings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_StreetId",
                table: "Buildings",
                column: "StreetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Streets_StreetId",
                table: "Buildings",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Streets_StreetId",
                table: "Buildings");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_StreetId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "StreetId",
                table: "Buildings");
        }
    }
}
