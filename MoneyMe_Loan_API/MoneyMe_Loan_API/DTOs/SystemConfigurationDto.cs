namespace MoneyMe_Loan_API.DTOs
{
    public class SystemConfigurationDto
    {
        public decimal InterestRate
        {
            get
            {
                decimal value = 0;
                if (!string.IsNullOrEmpty(InterestRateString))
                {
                    decimal.TryParse(InterestRateString, out value);
                }
                return value;
            }
        }
        public decimal EstablishmentFee
        {
            get
            {
                decimal value = 0;
                if (!string.IsNullOrEmpty(EstablishmentFeeString))
                {
                    decimal.TryParse(EstablishmentFeeString, out value);
                }
                return value;
            }
        }
        public decimal LoanAmountSliderMin
        {
            get
            {
                decimal value = 0;
                if (!string.IsNullOrEmpty(LoanAmountSliderMinString))
                {
                    decimal.TryParse(LoanAmountSliderMinString, out value);
                }
                return value;
            }
        }
        public decimal LoanAmountSliderMax
        {
            get
            {
                decimal value = 0;
                if (!string.IsNullOrEmpty(LoanAmountSliderMaxString))
                {
                    decimal.TryParse(LoanAmountSliderMaxString, out value);
                }
                return value;
            }
        }
        public int TermSliderMinMonths
        {
            get
            {
                int value = 0;
                if (!string.IsNullOrEmpty(TermSliderMinMonthsString))
                {
                    int.TryParse(TermSliderMinMonthsString, out value);
                }

                return value;
            }
        }
        public int TermSliderMaxMonths
        {
            get
            {
                int value = 0;
                if (!string.IsNullOrEmpty(TermSliderMaxMonthsString))
                {
                    int.TryParse(TermSliderMaxMonthsString, out value);
                }

                return value;
            }
        }

        public string? InterestRateString { get; set; }
        public string? EstablishmentFeeString { get; set; }
        public string? LoanAmountSliderMinString { get; set; }
        public string? LoanAmountSliderMaxString { get; set; }
        public string? TermSliderMinMonthsString { get; set; }
        public string? TermSliderMaxMonthsString { get; set; }
    }
}
