using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace AutoCompleteTextBox.Models
{
    public static class RegExLogic
    {
        public static string LCCNValue = string.Empty;
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
            if (LCCNCode.Contains(SafeValue.Hyphen))
                LCCNCode = LCCNCode.Replace(SafeValue.Hyphen, SafeValue.None);
            if (LCCNCode.Length < SafeValue.LoopLength)
            {
                for (int i = SafeValue.LoopInit; i < SafeValue.LoopLength; i++)
                {
                    if (i >= SafeValue.StartIndex && i < SafeValue.LoopLength)
                    {
                        LCCNCode = LCCNCode.Insert(SafeValue.StartIndex, SafeValue.InsertValue);
                        if (LCCNCode.Length >= SafeValue.LoopLength)
                        {
                            break;
                        }
                    }
                }
            }
            LCCNValue = LCCNCode;
            return Regex.IsMatch(LCCNCode, SafeValue.patternLCCN);
        }
    }
}