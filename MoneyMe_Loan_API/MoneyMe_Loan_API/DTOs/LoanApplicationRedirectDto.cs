using MoneyMe_Loan_API.Shared;
using System.Globalization;

namespace MoneyMe_Loan_API.DTOs
{
    public class LoanApplicationRedirectDto
    {
        public string? AmountRequired { get; set; }
        public string? Term { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DateOfBirth { get; set; } // Format is yyyy-MM-dd
        public string? Mobile { get; set; }
        public string? Email { get; set; }

        public decimal AmountRequiredFormatted
        {
            get
            {
                decimal.TryParse(AmountRequired ?? "", out decimal parsedAmount);
                return parsedAmount;
            }
        }

        public int TermFormatted
        {
            get
            {
                int.TryParse(Term ?? "", out int parsedTerm);
                return parsedTerm;
            }
        }

        public DateTime DateOfBirthFormatted { 
            get {
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
