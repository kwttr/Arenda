using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arenda.Migrations
{
    /// <inheritdoc />
    public partial class PenaltyChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentedPremises_Contracts_ContractId",
                table: "RentedPremises");

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "RentedPremises",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Penalty",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_RentedPremises_Contracts_ContractId",
                table: "RentedPremises",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentedPremises_Contracts_ContractId",
                table: "RentedPremises");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Penalty");

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "RentedPremises",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_RentedPremises_Contracts_ContractId",
                table: "RentedPremises",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");
        }
    }
}
