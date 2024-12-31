using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoneyMe_Loan_API.Migrations
{
    /// <inheritdoc />
    public partial class _SystemConfiguration__Data__Add_AMOUNT_SLIDER_MIN__and__AMOUNT_SLIDER_MAX : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SystemConfiguration",
                columns: new[] { "Id", "Code", "Description", "Value" },
                values: new object[,]
                {
                    { 5, "AMOUNT_SLIDER_MIN", "Minimum loan amount to be used on the Amount Slider", "2100" },
                    { 6, "AMOUNT_SLIDER_MAX", "Maximum loan amount to be used on the Amount Slider", "15000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemConfiguration",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SystemConfiguration",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
