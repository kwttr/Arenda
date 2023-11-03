using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arenda.Migrations
{
    /// <inheritdoc />
    public partial class AddPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Arendators",
                columns: new[] { "Id", "Discriminator", "FirstName", "IssuedByWhom", "LastName", "PasportNumber", "PasportSerial", "PhoneNumber", "SecondName" },
                values: new object[] { 1, "PhysicalPerson", "test", "test", "test", 1, 123, "test", "test" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Arendators",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
