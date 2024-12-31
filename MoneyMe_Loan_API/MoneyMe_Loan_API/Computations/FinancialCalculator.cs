namespace MoneyMe_Loan_API.Computations
{
    public class FinancialCalculator
    {
        /// <summary>
        /// Calculates the payment for a loan based on constant payments and a constant interest rate.
        /// </summary>
        /// <param name="rate">The interest rate per period.</param>
        /// <param name="nper">The total number of payment periods.</param>
        /// <param name="pv">The present value, or the total amount that a series of future payments is worth now.</param>
        /// <param name="establishment_fee">The upfront fee added to the loan amount. Default is 0.</param>
        /// <param name="firstMonthsInterestFree">Number of months for which interest is waived. Default is 0.</param>
        /// <param name="fv">The future value, or a cash balance you want to attain after the last payment. Default is 0.</param>
        /// <param name="type">When payments are due: 0 for end of the period, 1 for beginning. Default is 0.</param>
        /// <returns>The payment amount for each period.</returns>
        public static decimal PMT(decimal rate, int nper, decimal pv, decimal establishment_fee = 0, int firstMonthsInterestFree = 0, decimal fv = 0, int type = 0)
        {
            decimal interestFreeAdjustment = 0;

            if (rate == 0) // Handle the special case where the interest rate is 0.
            {
                // Add establishment fee to the loan amount
                pv += establishment_fee;
                return (pv + fv) / nper;
            }
            else
            {
                if (firstMonthsInterestFree > 0)
                {
                    // Adjust the present value to account for interest-free months
                    interestFreeAdjustment = ((rate * pv) * firstMonthsInterestFree) / nper;
                }
            }

            decimal pvFactor = (decimal)Math.Pow((double)(1 + rate), nper);
            decimal pmt = rate * (pv * pvFactor + fv) / ((1 + rate * type) * (pvFactor - 1));
            
            decimal establishment_fee_pmt = establishment_fee / nper;

            return (pmt + establishment_fee_pmt) - interestFreeAdjustment;
        }
    }
}
