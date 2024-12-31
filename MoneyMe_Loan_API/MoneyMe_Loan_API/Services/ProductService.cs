using Microsoft.EntityFrameworkCore;
using MoneyMe_Loan_API.Models;

namespace MoneyMe_Loan_API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product?> GetById(int Id);
    }

    public class ProductService : IProductService
    {
        private readonly DatabaseContext _dbContext;

        public ProductService(DatabaseContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Product.ToListAsync();
        }
        
        public async Task<Product?> GetById(int Id)
        {
            return await _dbContext.Product.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
