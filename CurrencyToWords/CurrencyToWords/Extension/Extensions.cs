namespace CurrencyToWords.Extension
{
    using System;

    using CurrencyToWords.StaticContent;

    public static class Extensions
    {
        /// <summary>
        /// Get word for a number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToWord(this int number)
        {
            if (!Enum.IsDefined(typeof(EnglishNumbers), number))
                return string.Empty;

            var n = (EnglishNumbers)number;
            return n.ToString();
        }

        public static string ToWord(this long number)
        {
            if (!Enum.IsDefined(typeof(EnglishNumbers), number))
                return string.Empty;

            var n = (EnglishNumbers)number;
            return n.ToString();
        }

        public static string FirstLetterToUpperOnly(this string str)
        {
            if (String.IsNullOrEmpty(str))
                return str;

            return String.Format("{0}{1}", str.Substring(0, 1).ToUpper(), str.Substring(1, str.Length-1).ToLower());
        }
    }
}
