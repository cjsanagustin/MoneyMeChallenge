namespace MoneyMe_Loan_API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public bool IsInterestFree { get; set; }

        public decimal InterestRate { get; set; }

        public int FirstNoOfMonthsInterestFree { get; set; }
        public int MinNoOfMonths { get; set; }
        public int MaxNoOfMonths { get; set; }
    }
}
