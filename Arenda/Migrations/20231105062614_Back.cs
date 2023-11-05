using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arenda.Migrations
{
    /// <inheritdoc />
    public partial class Back : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Streets_CityAreas_CityAreaId",
                table: "Streets");

            migrationBuilder.DropIndex(
                name: "IX_Streets_CityAreaId",
                table: "Streets");

            migrationBuilder.DropColumn(
                name: "CityAreaId",
                table: "Streets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityAreaId",
                table: "Streets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CityAreaId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CityAreaId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Streets_CityAreaId",
                table: "Streets",
                column: "CityAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Streets_CityAreas_CityAreaId",
                table: "Streets",
                column: "CityAreaId",
                principalTable: "CityAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
