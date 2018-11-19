using System;
using System.Text.RegularExpressions;

namespace GH.Services
{
    public interface IUrlFilterToDynamicLinqParser
    {
        string Parse(string filter);
    }
    
    public class UrlFilterToDynamicLinqParser : IUrlFilterToDynamicLinqParser
    {
        public string Parse(string filter)
        {
            filter = filter ?? "";
            filter = Regex.Replace(filter, "(?<=\\(\\\").*?(?=\\\"\\))", m => m.Value.Replace("\"", ""));
            return filter
                //equal
                .Replace(" eq ", " = ", StringComparison.CurrentCultureIgnoreCase)
                //not equal
                .Replace(" ne ", " != ", StringComparison.CurrentCultureIgnoreCase)
                //greater than
                .Replace(" gt ", " > ", StringComparison.CurrentCultureIgnoreCase)
                //greater than or equal
                .Replace(" gte ", " >= ", StringComparison.CurrentCultureIgnoreCase)
                //less than
                .Replace(" lt ", " < ", StringComparison.CurrentCultureIgnoreCase)
                //less than or equal
                .Replace(" lte ", " <= ", StringComparison.CurrentCultureIgnoreCase)
                // like '%value%' or in (value, value2,...)
                .Replace(" contains", " .ToString().Contains", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}