using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Arenda.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentFrequencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentFrequencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentPurposes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentPurposes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfFinishing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfFinishing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityAreaId = table.Column<int>(type: "INTEGER", nullable: false),
                    PremisesCount = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfBuilding = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_CityAreas_CityAreaId",
                        column: x => x.CityAreaId,
                        principalTable: "CityAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StreetId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Premises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeOfFinishingId = table.Column<int>(type: "INTEGER", nullable: false),
                    BuildingId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsableArea = table.Column<double>(type: "REAL", nullable: false),
                    Floor = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberExist = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Premises_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Premises_TypeOfFinishing_TypeOfFinishingId",
                        column: x => x.TypeOfFinishingId,
                        principalTable: "TypeOfFinishing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arendators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SecondName = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    StreetId = table.Column<int>(type: "INTEGER", nullable: true),
                    BuildingNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    PaymentAccount = table.Column<int>(type: "INTEGER", nullable: true),
                    INN = table.Column<int>(type: "INTEGER", nullable: true),
                    PasportSerial = table.Column<int>(type: "INTEGER", nullable: true),
                    PasportNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    IssuedByWhom = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arendators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arendators_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arendators_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arendators_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PaymentFrequencyId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArendatorId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartOfContract = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndOfContract = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Arendators_ArendatorId",
                        column: x => x.ArendatorId,
                        principalTable: "Arendators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_PaymentFrequencies_PaymentFrequencyId",
                        column: x => x.PaymentFrequencyId,
                        principalTable: "PaymentFrequencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Penalty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContractId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Penalty_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentedPremises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PremiseId = table.Column<int>(type: "INTEGER", nullable: false),
                    RentPurposeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContractId = table.Column<int>(type: "INTEGER", nullable: false),
                    RentCost = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentedPremises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentedPremises_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentedPremises_Premises_PremiseId",
                        column: x => x.PremiseId,
                        principalTable: "Premises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentedPremises_RentPurposes_RentPurposeId",
                        column: x => x.RentPurposeId,
                        principalTable: "RentPurposes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RentedPremiseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_RentedPremises_RentedPremiseId",
                        column: x => x.RentedPremiseId,
                        principalTable: "RentedPremises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CityAreas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Дзержинский район" },
                    { 2, "Железнодорожный район" },
                    { 3, "Заельцовский район" },
                    { 4, "Калининский район" },
                    { 5, "Кировский район" },
                    { 6, "Ленинский район" },
                    { 7, "Октябрьский район" },
                    { 8, "Первомайский район" },
                    { 9, "Советский район" },
                    { 10, "Центральный район" }
                });

            migrationBuilder.InsertData(
                table: "PaymentFrequencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ежемесячно" },
                    { 2, "Поквартально" },
                    { 3, "Ежегодно" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfFinishing",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Обычная" },
                    { 2, "Улучшенная" },
                    { 3, "Евроремонт" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arendators_BankId",
                table: "Arendators",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Arendators_CategoryId",
                table: "Arendators",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Arendators_StreetId",
                table: "Arendators",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_StreetId",
                table: "Banks",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CityAreaId",
                table: "Buildings",
                column: "CityAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ArendatorId",
                table: "Contracts",
                column: "ArendatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_PaymentFrequencyId",
                table: "Contracts",
                column: "PaymentFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RentedPremiseId",
                table: "Payments",
                column: "RentedPremiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_ContractId",
                table: "Penalty",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Premises_BuildingId",
                table: "Premises",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Premises_TypeOfFinishingId",
                table: "Premises",
                column: "TypeOfFinishingId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedPremises_ContractId",
                table: "RentedPremises",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedPremises_PremiseId",
                table: "RentedPremises",
                column: "PremiseId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedPremises_RentPurposeId",
                table: "RentedPremises",
                column: "RentPurposeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Penalty");

            migrationBuilder.DropTable(
                name: "RentedPremises");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Premises");

            migrationBuilder.DropTable(
                name: "RentPurposes");

            migrationBuilder.DropTable(
                name: "Arendators");

            migrationBuilder.DropTable(
                name: "PaymentFrequencies");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "TypeOfFinishing");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CityAreas");

            migrationBuilder.DropTable(
                name: "Streets");
        }
    }
}
