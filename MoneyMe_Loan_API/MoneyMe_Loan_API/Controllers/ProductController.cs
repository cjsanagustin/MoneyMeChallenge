using Microsoft.AspNetCore.Mvc;
using MoneyMe_Loan_API.DTOs;
using MoneyMe_Loan_API.Services;

namespace MoneyMe_Loan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            var data = await _productService.GetAll();
            return data.Select(x => new ProductDto
            {
                Id = x.Id,
                Description = x.Description,
            }).ToList();
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<ProductDto?>> GetById(int Id)
        {
            var data = await _productService.GetById(Id);
            if (data != null)
            {
                return new ProductDto
                {
                    Id = data.Id,
                    Description = data.Description,
                    IsInterestFree = data.IsInterestFree,
                    InterestRate = data.InterestRate,
                    FirstNoOfMonthsInterestFree = data.FirstNoOfMonthsInterestFree,
                    MinNoOfMonths = data.MinNoOfMonths,
                    MaxNoOfMonths = data.MaxNoOfMonths,
                };
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status204NoContent);
            }
        }

    }
}
