using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMe_Loan_API.Migrations
{
    /// <inheritdoc />
    public partial class _Product__InterestRate__UpdateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "InterestRate",
                value: 6.74m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "InterestRate",
                value: 6.74m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "InterestRate",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "InterestRate",
                value: 0m);
        }
    }
}
