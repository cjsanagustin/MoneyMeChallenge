using Microsoft.EntityFrameworkCore;

namespace MoneyMe_Loan_API.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<BlacklistedDomain> BlacklistedDomain { get; set; }
        public DbSet<BlacklistedMobileNumber> BlacklistedMobileNumber { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<LoanApplication> LoanApplication { get; set; }
        public DbSet<SystemConfiguration> SystemConfiguration { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<LoanType> LoanType { get; set; }


#if DEBUG
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        /* Dev's Connection String, used for creating Migration Files */
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MoneyMeLoan;Trusted_Connection=True;TrustServerCertificate=True;");
#else
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

#endif

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Data Seed for SystemConfiguration
            modelBuilder.Entity<SystemConfiguration>().HasData(new SystemConfiguration { Id = 1, Code = "INTEREST_RATE", Value = "6.74", Description = "Interest Rate" });
            modelBuilder.Entity<SystemConfiguration>().HasData(new SystemConfiguration { Id = 2, Code = "TERM_SLIDER_MIN_MONTHS", Value = "1", Description = "Minimum number of months to be used on the Term Slider" });
            modelBuilder.Entity<SystemConfiguration>().HasData(new SystemConfiguration { Id = 3, Code = "TERM_SLIDER_MAX_MONTHS", Value = "60", Description = "Maximum number of months to be used on the Term Slider" });
            modelBuilder.Entity<SystemConfiguration>().HasData(new SystemConfiguration { Id = 4, Code = "ESTABLISHMENT_FEE", Value = "300", Description = "Establishment Fee" });
            modelBuilder.Entity<SystemConfiguration>().HasData(new SystemConfiguration { Id = 5, Code = "AMOUNT_SLIDER_MIN", Value = "2100", Description = "Minimum loan amount to be used on the Amount Slider" });
            modelBuilder.Entity<SystemConfiguration>().HasData(new SystemConfiguration { Id = 6, Code = "AMOUNT_SLIDER_MAX", Value = "15000", Description = "Maximum loan amount to be used on the Amount Slider" });
            #endregion

            #region Data Seed for BlacklistedDomain
            modelBuilder.Entity<BlacklistedDomain>().HasData(new BlacklistedDomain { Id = 1, Description = "hotmail.com" });
            modelBuilder.Entity<BlacklistedDomain>().HasData(new BlacklistedDomain { Id = 2, Description = "yahoo.com" });
            #endregion

            #region Data Seed for BlacklistedMobileNumber
            modelBuilder.Entity<BlacklistedMobileNumber>().HasData(new BlacklistedMobileNumber { Id = 1, Description = "1111111111" });
            modelBuilder.Entity<BlacklistedMobileNumber>().HasData(new BlacklistedMobileNumber { Id = 2, Description = "2222222222" });
            #endregion

            #region Data Seed for Product
            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Description = "ProductA", InterestRate = 0, IsInterestFree = true, MinNoOfMonths = 1, FirstNoOfMonthsInterestFree = 0 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 2, Description = "ProductB", InterestRate = 6.74m, IsInterestFree = false, MinNoOfMonths = 6, FirstNoOfMonthsInterestFree = 2 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 3, Description = "ProductC", InterestRate = 6.74m, IsInterestFree = false, MinNoOfMonths = 1, FirstNoOfMonthsInterestFree = 0 });
            #endregion

            #region Data Seed for LoanType
            modelBuilder.Entity<LoanType>().HasData(new LoanType { Id = 1, Description = "Pay off credit cards or loans" });
            modelBuilder.Entity<LoanType>().HasData(new LoanType { Id = 2, Description = "Buy or refinance a vehicle" });
            modelBuilder.Entity<LoanType>().HasData(new LoanType { Id = 3, Description = "Home improvement" });
            modelBuilder.Entity<LoanType>().HasData(new LoanType { Id = 4, Description = "Property acquisition costs" });
            modelBuilder.Entity<LoanType>().HasData(new LoanType { Id = 5, Description = "Medical expenses" });
            modelBuilder.Entity<LoanType>().HasData(new LoanType { Id = 6, Description = "Holiday" });
            modelBuilder.Entity<LoanType>().HasData(new LoanType { Id = 7, Description = "Education expenses" });
            modelBuilder.Entity<LoanType>().HasData(new LoanType { Id = 8, Description = "Wedding" });
            modelBuilder.Entity<LoanType>().HasData(new LoanType { Id = 9, Description = "Solar and renewable energy" });
            #endregion


            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
