using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoneyMe_Loan_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlacklistedDomain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlacklistedDomain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlacklistedMobileNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlacklistedMobileNumber", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URLGUID = table.Column<string>(type: "varchar(32)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(300)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(300)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Title = table.Column<string>(type: "varchar(5)", nullable: false),
                    MobileNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    Email = table.Column<string>(type: "varchar(320)", nullable: false),
                    PrePopulateAmountRequired = table.Column<decimal>(type: "decimal(14,4)", nullable: false),
                    PrePopulateMonthlyTerm = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AmountRequired = table.Column<decimal>(type: "decimal(14,4)", nullable: false),
                    MonthlyTerm = table.Column<int>(type: "int", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(14,4)", nullable: false),
                    MonthlyPayment = table.Column<decimal>(type: "decimal(14,4)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", nullable: false),
                    IsInterestFree = table.Column<bool>(type: "bit", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(14,4)", nullable: false),
                    FirstNoOfMonthsInterestFree = table.Column<int>(type: "int", nullable: false),
                    MinNoOfMonths = table.Column<int>(type: "int", nullable: false),
                    MaxNoOfMonths = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(100)", nullable: false),
                    Value = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemConfiguration", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BlacklistedDomain",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "hotmail.com" },
                    { 2, "yahoo.com" }
                });

            migrationBuilder.InsertData(
                table: "BlacklistedMobileNumber",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "1111111111" },
                    { 2, "2222222222" }
                });

            migrationBuilder.InsertData(
                table: "LoanType",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Pay off credit cards or loans" },
                    { 2, "Buy or refinance a vehicle" },
                    { 3, "Home improvement" },
                    { 4, "Property acquisition costs" },
                    { 5, "Medical expenses" },
                    { 6, "Holiday" },
                    { 7, "Education expenses" },
                    { 8, "Wedding" },
                    { 9, "Solar and renewable energy" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "FirstNoOfMonthsInterestFree", "InterestRate", "IsInterestFree", "MaxNoOfMonths", "MinNoOfMonths" },
                values: new object[,]
                {
                    { 1, "ProductA", 0, 0m, true, 0, 1 },
                    { 2, "ProductB", 2, 0m, false, 0, 6 },
                    { 3, "ProductC", 0, 0m, false, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "SystemConfiguration",
                columns: new[] { "Id", "Code", "Description", "Value" },
                values: new object[,]
                {
                    { 1, "INTEREST_RATE", "Interest Rate", "6.74" },
                    { 2, "TERM_SLIDER_MIN_MONTHS", "Minimum number of months to be used on the Term Slider", "1" },
                    { 3, "TERM_SLIDER_MAX_MONTHS", "Maximum number of months to be used on the Term Slider", "60" },
                    { 4, "ESTABLISHMENT_FEE", "Establishment Fee", "300" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlacklistedDomain_Description",
                table: "BlacklistedDomain",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlacklistedMobileNumber_Description",
                table: "BlacklistedMobileNumber",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_FirstName_LastName_DateOfBirth",
                table: "Customer",
                columns: new[] { "FirstName", "LastName", "DateOfBirth" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemConfiguration_Code_Value",
                table: "SystemConfiguration",
                columns: new[] { "Code", "Value" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlacklistedDomain");

            migrationBuilder.DropTable(
                name: "BlacklistedMobileNumber");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "LoanApplication");

            migrationBuilder.DropTable(
                name: "LoanType");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "SystemConfiguration");
        }
    }
}
