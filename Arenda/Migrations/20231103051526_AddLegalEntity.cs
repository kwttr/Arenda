using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Arenda.Migrations
{
    /// <inheritdoc />
    public partial class AddLegalEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Streets",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Красный проспект" },
                    { 2, "Улица Ленина" }
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "Name", "StreetId" },
                values: new object[] { 1, "Сбербанк", 1 });

            migrationBuilder.InsertData(
                table: "Arendators",
                columns: new[] { "Id", "BankId", "BuildingNumber", "Discriminator", "FirstName", "INN", "LastName", "PaymentAccount", "PhoneNumber", "SecondName", "StreetId" },
                values: new object[] { 2, 1, 1, "LegalEntity", "test", 123123, "test", 1, "test", "test", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Arendators",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
