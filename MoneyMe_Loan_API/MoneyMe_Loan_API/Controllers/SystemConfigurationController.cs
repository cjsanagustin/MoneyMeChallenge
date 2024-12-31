using Microsoft.AspNetCore.Mvc;
using MoneyMe_Loan_API.DTOs;
using MoneyMe_Loan_API.Services;

namespace MoneyMe_Loan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemConfigurationController : ControllerBase
    {
        private readonly ISystemConfigurationService _SystemConfigurationService;

        public SystemConfigurationController(ISystemConfigurationService SystemConfigurationService)
        {
            _SystemConfigurationService = SystemConfigurationService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<SystemConfigurationDto>> GetAll()
        {
            var data = await _SystemConfigurationService.GetAll();
            return new SystemConfigurationDto
            {
                InterestRateString = data.First(x => x.Code.Equals("INTEREST_RATE")).Value,
                LoanAmountSliderMinString = data.First(x => x.Code.Equals("AMOUNT_SLIDER_MIN")).Value,
                LoanAmountSliderMaxString = data.First(x => x.Code.Equals("AMOUNT_SLIDER_MAX")).Value,
                TermSliderMinMonthsString = data.First(x => x.Code.Equals("TERM_SLIDER_MIN_MONTHS")).Value,
                TermSliderMaxMonthsString = data.First(x => x.Code.Equals("TERM_SLIDER_MAX_MONTHS")).Value,
                EstablishmentFeeString = data.First(x => x.Code.Equals("ESTABLISHMENT_FEE")).Value,
            };
        }

    }
}
