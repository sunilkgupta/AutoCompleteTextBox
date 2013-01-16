using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace AutoCompleteTextBox.Models
{
    public static class RegExLogic
    {
        public static bool validateISBN(string ISBNCode)
        {
            if (ISBNCode.Contains(SafeValue.Hyphen))
                ISBNCode = ISBNCode.Replace(SafeValue.Hyphen, SafeValue.None);
            return Regex.IsMatch(ISBNCode, SafeValue.patternISBN);
        }
        public static bool validateUPC(string UPCCode)
        {
            return Regex.IsMatch(UPCCode,SafeValue.patternUPC) && UPCCode.Length == 12;
        }
        public static bool validateLCCN(string LCCNCode)
        {
            return Regex.IsMatch(LCCNCode, SafeValue.patternLCCN);
        }
    }
}