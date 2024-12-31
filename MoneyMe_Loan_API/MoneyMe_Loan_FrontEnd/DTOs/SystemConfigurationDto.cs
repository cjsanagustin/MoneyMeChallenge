namespace MoneyMe_Loan_FrontEnd.DTOs
{
    public class SystemConfigurationDto
    {
        public decimal InterestRate { get; set; }
        public decimal LoanAmountSliderMin { get; set; }
        public decimal LoanAmountSliderMax { get; set; }
        public int TermSliderMinMonths { get; set; }
        public int TermSliderMaxMonths { get; set; }
        public decimal EstablishmentFee { get; set; }
    }
}
