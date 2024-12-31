using System.Text.RegularExpressions;

namespace MoneyMe_Loan_FrontEnd.Shared
{
    public class RegexRouteConstraint : IRouteConstraint
    {
        private readonly Regex _regex;

        public RegexRouteConstraint(string pattern)
        {
            _regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.TryGetValue(routeKey, out var value) || value == null)
            {
                return false;
            }

            var stringValue = Convert.ToString(value);
            return stringValue != null && _regex.IsMatch(stringValue);
        }
    }
}
