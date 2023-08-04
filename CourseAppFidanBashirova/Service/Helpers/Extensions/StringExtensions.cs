using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Service.Helpers.Extensions
{
	public static class StringExtensions
    {
		public static bool StringRegEx(this string text,string pattern)
		{
            bool isMatch = Regex.IsMatch(text, pattern);

			return isMatch;
        }


		
	}
}

