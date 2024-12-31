namespace MoneyMe_Loan_API.DTOs
{
    public class LoanApplicationPrePopulatedDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public string Email { get; set; } = null!;

        public decimal AmountRequired { get; set; }
        public int MonthlyTerm { get; set; }

    }
}
