using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Arenda.Migrations
{
    /// <inheritdoc />
    public partial class Initialize2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PremisesCount",
                table: "Buildings",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "NumberOfBuilding",
                table: "Buildings",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentAccount",
                table: "Arendators",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasportSerial",
                table: "Arendators",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasportNumber",
                table: "Arendators",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "INN",
                table: "Arendators",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Arendators",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasportNumber", "PasportSerial" },
                values: new object[] { "123", "123" });

            migrationBuilder.UpdateData(
                table: "Arendators",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "INN", "PaymentAccount" },
                values: new object[] { "123123", "1" });

            migrationBuilder.InsertData(
                table: "RentPurposes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Офис" },
                    { 2, "Киоск" },
                    { 3, "Склад" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RentPurposes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentPurposes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RentPurposes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "PremisesCount",
                table: "Buildings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfBuilding",
                table: "Buildings",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentAccount",
                table: "Arendators",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PasportSerial",
                table: "Arendators",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PasportNumber",
                table: "Arendators",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "INN",
                table: "Arendators",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Arendators",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasportNumber", "PasportSerial" },
                values: new object[] { 1, 123 });

            migrationBuilder.UpdateData(
                table: "Arendators",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "INN", "PaymentAccount" },
                values: new object[] { 123123, 1 });
        }
    }
}
