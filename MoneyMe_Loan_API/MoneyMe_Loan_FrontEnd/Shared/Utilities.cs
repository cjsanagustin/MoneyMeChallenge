using System.Globalization;

namespace MoneyMe_Loan_FrontEnd.Shared
{
    public static class Utilities
    {
        public readonly static string DateParseFormat = "yyyy-MM-dd";

        public static string GetDecimalFormat(decimal amount, int decimalPlaces = 0)
        {
            string format = $"N{decimalPlaces}";
            return $"${amount.ToString(format)}";
        }

    }
}
