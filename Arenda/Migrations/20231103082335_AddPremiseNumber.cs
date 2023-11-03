using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arenda.Migrations
{
    /// <inheritdoc />
    public partial class AddPremiseNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PremiseNumber",
                table: "Premises",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PremiseNumber",
                table: "Premises");
        }
    }
}
