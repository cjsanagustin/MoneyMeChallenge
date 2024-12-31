using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMe_Loan_API.Migrations
{
    /// <inheritdoc />
    public partial class _LoanApplication__ProductId_LoanTypeId__NewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoanTypeId",
                table: "LoanApplication",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "LoanApplication",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanTypeId",
                table: "LoanApplication");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "LoanApplication");
        }
    }
}
