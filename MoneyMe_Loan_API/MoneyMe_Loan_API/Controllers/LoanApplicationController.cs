using Microsoft.AspNetCore.Mvc;
using MoneyMe_Loan_API.Computations;
using MoneyMe_Loan_API.DTOs;
using MoneyMe_Loan_API.Services;
using MoneyMe_Loan_API.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoneyMe_Loan_API.Controllers
{
    [Route("api/money-me-loan-application")]
    [ApiController]
    public class LoanApplicationController : ControllerBase
    {
        private readonly ILoanApplicationService _loanApplicationService;
        private readonly ICustomerService _customerService;
        private readonly IConfiguration _configuration;
        private readonly IBlacklistedService _blacklistedService;


        public LoanApplicationController(ILoanApplicationService loanApplicationService, ICustomerService customerService
            , IConfiguration configuration, IBlacklistedService blacklistedService)
        {
            _loanApplicationService = loanApplicationService;
            _customerService = customerService;
            _configuration = configuration;
            _blacklistedService = blacklistedService;
        }

        [HttpPost("redirect")]
        public async Task<ActionResult<string>> Redirect([FromBody] LoanApplicationRedirectDto obj)
        {
            string urlSafeGuid = "";

            // Check if Customer already exists
            var customer = await _customerService.GetByNameAndDateOfBirth(obj.LastName ?? "", obj.FirstName ?? "", obj.DateOfBirthFormatted);
            if (customer == null)
            {
                // Generate a new GUID and make it URL-safe
                urlSafeGuid = Guid.NewGuid().ToString("N"); // Removes the dashes

                await _customerService.Add(
                    new Models.Customer
                    {
                        URLGUID = urlSafeGuid,
                        FirstName = obj.FirstName ?? "",
                        LastName = obj.LastName ?? "",
                        DateOfBirth = obj.DateOfBirthFormatted,
                        Title = obj.Title ?? "",
                        MobileNumber = obj.Mobile ?? "",
                        Email = obj.Email ?? "",

                        PrePopulateAmountRequired = obj.AmountRequiredFormatted,
                        PrePopulateMonthlyTerm = obj.TermFormatted,

                        CreatedDate = DateTime.Now,
                    }
                );
            }
            else
            {
                urlSafeGuid = customer.URLGUID;

                customer.FirstName = obj.FirstName ?? "";
                customer.LastName = obj.LastName ?? "";
                customer.DateOfBirth = obj.DateOfBirthFormatted;
                customer.Title = obj.Title ?? "";
                customer.MobileNumber = obj.Mobile ?? "";
                customer.Email = obj.Email ?? "";
                customer.ModifiedDate = DateTime.Now;
                await _customerService.Update(customer);
            }

            string FrontEndURL = _configuration["FrontEndURL"] ?? "";

            return string.Concat(FrontEndURL,"/", urlSafeGuid);
        }

        [HttpGet("{guidurl}")]
        public async Task<ActionResult<LoanApplicationPrePopulatedDto?>> GetByURL(string guidurl)
        {
            var customer = await _customerService.GetByURLGUID(guidurl);

            if (customer != null)
            {
                return new LoanApplicationPrePopulatedDto
                {
                    CustomerId = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth.ToString(Utilities.DateParseFormat),
                    MobileNumber = customer.MobileNumber,
                    Email = customer.Email,
                    Title = customer.Title,

                    AmountRequired = customer.PrePopulateAmountRequired,
                    MonthlyTerm = customer.PrePopulateMonthlyTerm,

                };
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status204NoContent);
            }

        }

        [HttpPost("check-blacklisted")]
        public async Task<ActionResult<ValidationMessageDto>> CheckBlacklisted([FromBody] LoanApplicationValidationDto obj)
        {
            List<string> ValidationMessages = new List<string>();

            if (await _blacklistedService.IsMobileNumberBlacklisted(obj.MobileNumber))
            { 
                ValidationMessages.Add("mobile number"); 
            }
            if (await _blacklistedService.IsDomainBlacklisted(obj.Domain))
            { 
                ValidationMessages.Add("domain"); 
            }

            return new ValidationMessageDto 
            { 
                IsValid = ValidationMessages.Count == 0,
                ValidationMessages = ValidationMessages
            };
        }

        [HttpPost("calculate-interest")]
        public ActionResult<decimal> Calculate([FromBody] LoanApplicationApplyDto obj)
        {
            return FinancialCalculator.PMT((obj.InterestRate/100/12), obj.MonthlyTerm, obj.Amount, obj.EstablishmentFee, obj.FirstNoOfMonthsInterestFree);
        }

        [HttpPost("submit")]
        public async Task<ActionResult<bool>> Submit([FromBody] LoanApplicationApplyDto obj)
        {
            // Check if Customer already exists
            var customer = await _customerService.GetByNameAndDateOfBirth(obj.LastName ?? "", obj.FirstName ?? "", obj.DateOfBirthFormatted);
            if (customer != null)
            {
                customer.FirstName = obj.FirstName ?? "";
                customer.LastName = obj.LastName ?? "";
                customer.DateOfBirth = obj.DateOfBirthFormatted;
                customer.Title = obj.Title ?? "";
                customer.MobileNumber = obj.MobileNumber ?? "";
                customer.Email = obj.Email ?? "";
                customer.ModifiedDate = DateTime.Now;
                await _customerService.Update(customer);

                await _loanApplicationService.Add(
                    new Models.LoanApplication
                    {
                        CustomerId = customer.Id,
                        AmountRequired = obj.Amount,
                        MonthlyTerm = obj.MonthlyTerm,
                        InterestRate = obj.InterestRate,
                        MonthlyPayment = obj.MonthlyPayment,
                        ProductId = obj.ProductId ?? 0,
                        LoanTypeId = obj.LoanTypeId ?? 0,
                        CreatedDate = DateTime.Now,
                    }
                );
            }

            return true;
        }


    }
}
