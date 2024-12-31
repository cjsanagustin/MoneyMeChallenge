using Microsoft.EntityFrameworkCore;
using MoneyMe_Loan_API.Models;

namespace MoneyMe_Loan_API.Services
{
    public interface ILoanTypeService
    {
        Task<IEnumerable<LoanType>> GetAll();
    }

    public class LoanTypeService : ILoanTypeService
    {
        private readonly DatabaseContext _dbContext;

        public LoanTypeService(DatabaseContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<LoanType>> GetAll()
        {
            return await _dbContext.LoanType.ToListAsync();
        }
    }
}
