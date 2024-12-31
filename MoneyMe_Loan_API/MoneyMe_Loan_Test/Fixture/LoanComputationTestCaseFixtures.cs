using MoneyMe_Loan_API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMe_Loan_Test.Fixture
{
    public class LoanComputationTestCaseFixtures
    {
        public string Name { get; set; } = null!;
        public LoanApplicationApplyDto Arrange { get; set; } = new LoanApplicationApplyDto();
        public decimal ExpectedResult { get; set; }
        public static object[][] TestData = new object[][]
        {
            new object[] {
                new LoanComputationTestCaseFixtures
                {
                    Name = "ProductA with establishment fee",
                    Arrange = new LoanApplicationApplyDto {
                        InterestRate = 0,
                        MonthlyTerm = 6,
                        Amount = 5000,
                        EstablishmentFee = 300,
                        FirstNoOfMonthsInterestFree = 0,
                    },
                    ExpectedResult = 883.33m,
                }
            },
            new object[] {
                new LoanComputationTestCaseFixtures
                {
                    Name = "ProductB with establishment fee",
                    Arrange = new LoanApplicationApplyDto {
                        InterestRate = 6.74m/100/12,
                        MonthlyTerm = 6,
                        Amount = 5000,
                        EstablishmentFee = 300,
                        FirstNoOfMonthsInterestFree = 2,
                    },
                    ExpectedResult = 890.43m,
                }
            },
            new object[] {
                new LoanComputationTestCaseFixtures
                {
                    Name = "ProductC with establishment fee",
                    Arrange = new LoanApplicationApplyDto {
                        InterestRate = 6.74m/100/12,
                        MonthlyTerm = 6,
                        Amount = 5000,
                        EstablishmentFee = 300,
                        FirstNoOfMonthsInterestFree = 0,
                    },
                    ExpectedResult = 899.79m,
                }
            },
            new object[] {
                new LoanComputationTestCaseFixtures
                {
                    Name = "ProductA without establishment fee",
                    Arrange = new LoanApplicationApplyDto {
                        InterestRate = 0,
                        MonthlyTerm = 6,
                        Amount = 5000,
                        EstablishmentFee = 0,
                        FirstNoOfMonthsInterestFree = 0,
                    },
                    ExpectedResult = 833.33m,
                }
            },
            new object[] {
                new LoanComputationTestCaseFixtures
                {
                    Name = "ProductB without establishment fee",
                    Arrange = new LoanApplicationApplyDto {
                        InterestRate = 6.74m/100/12,
                        MonthlyTerm = 6,
                        Amount = 5000,
                        EstablishmentFee = 0,
                        FirstNoOfMonthsInterestFree = 2,
                    },
                    ExpectedResult = 840.43m,
                }
            },
            new object[] {
                new LoanComputationTestCaseFixtures
                {
                    Name = "ProductC without establishment fee",
                    Arrange = new LoanApplicationApplyDto {
                        InterestRate = 6.74m/100/12,
                        MonthlyTerm = 6,
                        Amount = 5000,
                        EstablishmentFee = 0,
                        FirstNoOfMonthsInterestFree = 0,
                    },
                    ExpectedResult = 849.79m,
                }
            },
        };
    }
}
