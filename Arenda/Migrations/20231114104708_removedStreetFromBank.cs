using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arenda.Migrations
{
    /// <inheritdoc />
    public partial class removedStreetFromBank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banks_Streets_StreetId",
                table: "Banks");

            migrationBuilder.DropIndex(
                name: "IX_Banks_StreetId",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "StreetId",
                table: "Banks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StreetId",
                table: "Banks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1,
                column: "StreetId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Banks_StreetId",
                table: "Banks",
                column: "StreetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banks_Streets_StreetId",
                table: "Banks",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
