using Microsoft.EntityFrameworkCore;
using MoneyMe_Loan_API.Models;

namespace MoneyMe_Loan_API.Services
{
    public interface ISystemConfigurationService
    {
        Task<IEnumerable<SystemConfiguration>> GetAll();
        Task<SystemConfiguration?> GetByCode(string Code);
    }

    public class SystemConfigurationService : ISystemConfigurationService
    {
        private readonly DatabaseContext _dbContext;

        public SystemConfigurationService(DatabaseContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SystemConfiguration>> GetAll()
        {
            return await _dbContext.SystemConfiguration.ToListAsync();
        }

        public async Task<SystemConfiguration?> GetByCode(string Code)
        {
            return await _dbContext.SystemConfiguration.FirstOrDefaultAsync(x => x.Code.Equals(Code));
        }
    }
}
