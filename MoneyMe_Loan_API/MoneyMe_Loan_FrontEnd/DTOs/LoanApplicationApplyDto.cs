using FluentValidation;

namespace MoneyMe_Loan_FrontEnd.DTOs
{
    public class LoanApplicationApplyDto
    {
        public int CustomerId { get; set; }
        public string Title { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
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
        
        public decimal TotalRepayments
        {
            get
            {
                return MonthlyPayment * MonthlyTerm;
            }
        }
        
        public decimal TotalInterest
        {
            get
            {
                return TotalRepayments - EstablishmentFee - Amount;
            }
        }

    }

    public class LoanApplicationApplyDtoValidator : AbstractValidator<LoanApplicationApplyDto>
    {
        public LoanApplicationApplyDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithName("First Name").Length(1, 300);
            RuleFor(x => x.LastName).NotEmpty().WithName("Last Name").Length(1, 300);
            RuleFor(x => x.Title).NotEmpty().WithName("Title").Length(1, 5);
            RuleFor(x => x.DateOfBirth).NotEmpty().WithName("Date of Birth").LessThanOrEqualTo(x => DateTime.Now.Date.AddYears(-18))
            .WithMessage("The applicant must be at least 18 years old");




            RuleFor(x => x.MobileNumber).NotEmpty().WithName("Mobile number").Length(1, 300)
                .Matches(@"^\d+$")
                .WithMessage("Mobile number must contain numbers only"); ;
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithName("Email").Length(1, 320);
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<LoanApplicationApplyDto>
                .CreateWithOptions((LoanApplicationApplyDto)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
