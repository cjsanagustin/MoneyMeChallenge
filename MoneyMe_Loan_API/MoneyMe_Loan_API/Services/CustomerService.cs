using Microsoft.EntityFrameworkCore;
using MoneyMe_Loan_API.Models;

namespace MoneyMe_Loan_API.Services
{
    public interface ICustomerService
    {
        Task<Customer?> GetByNameAndDateOfBirth(string LastName, string FirstName, DateTime DateOfBirth);
        Task<Customer?> GetByURLGUID(string URLGUID);
        Task Add(Customer obj);
        Task Update(Customer obj);
    }

    public class CustomerService : ICustomerService
    {
        private readonly DatabaseContext _dbContext;

        public CustomerService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer?> GetByNameAndDateOfBirth(string LastName, string FirstName, DateTime DateOfBirth)
        {
            return await _dbContext.Customer.FirstOrDefaultAsync(x =>
                x.LastName.Equals(LastName)
                && x.FirstName.Equals(FirstName)
                && x.DateOfBirth == DateOfBirth
            );
        }

        public async Task<Customer?> GetByURLGUID(string URLGUID)
        {
            return await _dbContext.Customer.FirstOrDefaultAsync(x => x.URLGUID.Equals(URLGUID));
        }

        public async Task Add(Customer obj)
        {
            await _dbContext.Customer.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Customer obj)
        {
            await _dbContext.Customer.Where(x => x.Id == obj.Id)
                .ExecuteUpdateAsync(x => x
                .SetProperty(x => x.LastName, obj.LastName)
                .SetProperty(x => x.FirstName, obj.FirstName)
                .SetProperty(x => x.Title, obj.Title)
                .SetProperty(x => x.MobileNumber, obj.MobileNumber)
                .SetProperty(x => x.Email, obj.Email)
                .SetProperty(x => x.ModifiedDate, obj.ModifiedDate)
                );
        }
    }
}
