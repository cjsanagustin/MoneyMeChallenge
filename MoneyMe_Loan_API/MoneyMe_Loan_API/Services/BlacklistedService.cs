using Microsoft.EntityFrameworkCore;
using MoneyMe_Loan_API.Models;

namespace MoneyMe_Loan_API.Services
{
    public interface IBlacklistedService
    {
        Task<bool> IsMobileNumberBlacklisted(string MobileNumber);
        Task<bool> IsDomainBlacklisted(string Domain);
    }

    public class BlacklistedService : IBlacklistedService
    {
        private readonly DatabaseContext _dbContext;

        public BlacklistedService(DatabaseContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public async Task<bool> IsMobileNumberBlacklisted(string MobileNumber)
        {
            return await _dbContext.BlacklistedMobileNumber.AnyAsync(x => x.Description.Equals(MobileNumber));
        }

        public async Task<bool> IsDomainBlacklisted(string Domain)
        {
            return await _dbContext.BlacklistedDomain.AnyAsync(x => x.Description.Equals(Domain));
        }
    }
}
