using MoneyMe_Loan_API.Shared;
using System.Globalization;

namespace MoneyMe_Loan_API.DTOs
{
    public class LoanApplicationApplyDto
    {
        public int CustomerId { get; set; }
        public string Title { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;

        public decimal Amount { get; set; }
        public int MonthlyTerm { get; set; }

        public int? ProductId { get; set; }
        public int? LoanTypeId { get; set; }


        public int FirstNoOfMonthsInterestFree { get; set; }
        public decimal InterestRate { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal EstablishmentFee { get; set; }
        public decimal TotalInterest { get; set; }


        public DateTime DateOfBirthFormatted
        {
            get
            {
                DateTime.TryParseExact(DateOfBirth ?? "", Utilities.DateParseFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);

                // Return 1900-01-01 when Dob is invalid to prevent errors on database for minimum date
                if (parsedDate == new DateTime(0001, 01, 01))
                {
                    return new DateTime(1900, 01, 01);
                }
                else
                {
                    return parsedDate.Date;
                }
            }
        }

    }
}
