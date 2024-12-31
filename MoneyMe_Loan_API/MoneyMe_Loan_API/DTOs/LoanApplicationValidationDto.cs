using MoneyMe_Loan_API.Shared;
using System.Globalization;

namespace MoneyMe_Loan_API.DTOs
{
    public class LoanApplicationValidationDto
    {
        public string Email { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public string Domain
        {
            get
            {
                return Utilities.GetDomainFromEmail(Email);
            }
        }
    }
}
