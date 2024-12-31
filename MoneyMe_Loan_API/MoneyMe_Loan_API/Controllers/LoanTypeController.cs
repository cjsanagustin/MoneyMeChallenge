using Microsoft.AspNetCore.Mvc;
using MoneyMe_Loan_API.DTOs;
using MoneyMe_Loan_API.Services;

namespace MoneyMe_Loan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanTypeController : ControllerBase
    {
        private readonly ILoanTypeService _LoanTypeService;

        public LoanTypeController(ILoanTypeService LoanTypeService)
        {
            _LoanTypeService = LoanTypeService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<LoanTypeDto>>> GetAll()
        {
            var data = await _LoanTypeService.GetAll();
            return data.Select(x => new LoanTypeDto
            {
                Id = x.Id,
                Description = x.Description,
            }).ToList();
        }

    }
}
