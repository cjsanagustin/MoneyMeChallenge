using MoneyMe_Loan_API.Shared;
using System.Globalization;

namespace MoneyMe_Loan_API.DTOs
{
    public class ValidationMessageDto
    {
        public bool IsValid { get; set; }
        public List<string>? ValidationMessages { get; set; }
    }
}
