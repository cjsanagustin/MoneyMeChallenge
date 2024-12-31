using Microsoft.EntityFrameworkCore;
using MoneyMe_Loan_API.Models;

namespace MoneyMe_Loan_API.Services
{
    public interface ILoanApplicationService
    {
        Task Add(LoanApplication obj);
        Task Update(LoanApplication obj);
    }

    public class LoanApplicationService : ILoanApplicationService
    {
        private readonly DatabaseContext _dbContext;

        public LoanApplicationService(DatabaseContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public async Task Add(LoanApplication obj)
        {
            await _dbContext.LoanApplication.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(LoanApplication obj)
        {
            await _dbContext.LoanApplication.Where(x => x.Id == obj.Id)
                .ExecuteUpdateAsync(x => x
                .SetProperty(x => x.AmountRequired, obj.AmountRequired)
                .SetProperty(x => x.MonthlyTerm, obj.MonthlyTerm)
                .SetProperty(x => x.InterestRate, obj.InterestRate)
                .SetProperty(x => x.MonthlyTerm, obj.MonthlyTerm)
                .SetProperty(x => x.ModifiedDate, obj.ModifiedDate)
                );
        }
    }
}
