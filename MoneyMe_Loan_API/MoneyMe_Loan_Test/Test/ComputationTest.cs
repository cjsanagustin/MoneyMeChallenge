using MoneyMe_Loan_API.Computations;
using MoneyMe_Loan_Test.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMe_Loan_Test.Test
{
    public class ComputationTest
    {
        [Theory, MemberData(nameof(LoanComputationTestCaseFixtures.TestData), MemberType = typeof(LoanComputationTestCaseFixtures))]
        public void LoanComputationTest(LoanComputationTestCaseFixtures fixture)
        {   
            //Act
            decimal Actual = FinancialCalculator.PMT(
                    fixture.Arrange.InterestRate, fixture.Arrange.MonthlyTerm, fixture.Arrange.Amount
                    , fixture.Arrange.EstablishmentFee, fixture.Arrange.FirstNoOfMonthsInterestFree
                );

            //Assert
            Assert.Equal(fixture.ExpectedResult, Actual, 2);
        }
    }
}
