namespace MoneyMe_Loan_API.Shared
{
    public static class Utilities
    {
        public readonly static string DateParseFormat = "yyyy-MM-dd";

        public static string GetDomainFromEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));

            var atIndex = email.IndexOf('@');
            if (atIndex == -1 || atIndex == email.Length - 1)
                throw new ArgumentException("Invalid email format.", nameof(email));

            return email.Substring(atIndex + 1);
        }
    }
}
