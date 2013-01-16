using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteTextBox.Models
{
    public static class SafeValue
    {
       public const string patternISBN = @"^(97(8|9))?\d{9}(\d|X)$";
       public const string patternUPC = @"^(0|1|6|7|8)?\d{11}$";
       public const string patternLCCN = @"^(0-9)?\d{8}$";
       public const string ISBN = "ISBN";
       public const string UPC = "UPC";
       public const string LCCN = "LCCN";
       public const string Nothing = "Nothing";
       public const string Hyphen = "-";
       public const string None = "";
    }
}