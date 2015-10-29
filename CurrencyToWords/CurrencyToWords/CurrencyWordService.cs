namespace CurrencyToWords
{
    using System;
    using System.Linq;
    using System.Text;

    using CurrencyToWords.CurrencyPlaces;
    using CurrencyToWords.Exceptions;
    using CurrencyToWords.Extension;

    /// <summary>
    /// Convert currency to word
    /// </summary>
    public class CurrencyWordService : ICurrencyWordService
    {
        private OnePlace one { get; set; }
        private TenPlace ten { get; set; }
        private HundredPlace hundred { get; set; }
        private ThousandPlace thousand { get; set; }
        private MillionPlace million { get; set; }
        private CentPlace cent { get; set; }

        private void Init(decimal number)
        {
            //maximum number 999 million.
            if (number < 0 || number > 999999999)
                throw new InvalidNumberRangeException();

            var n = (int)number;
            if (Validator.ValidateMillionPlace(n))
                million = new MillionPlace(n);

            var n1 = (n >= 1000000) ? n - (n / 1000000 * 1000000) : n;
            if (Validator.ValidateThousandPlace(n1))
                thousand = new ThousandPlace((int)n1);

            var n2 = (n1 >= 1000) ? n - (n / 1000 * 1000) : n1;
            if (Validator.ValidateHundredPlace(n2))
                hundred = new HundredPlace((int)n2);

            var n3 = (n2 >= 100) ? n - (n / 100 * 100) : n2;
            if (Validator.ValidateTenPlace(n3))
                ten = new TenPlace((int)n3);
            else
            {
                var n4 = (n3 >= 10) ? n - (n / 10 * 10) : n3;
                if (Validator.ValidateOnePlace(n4))
                    one = new OnePlace((int)n4);
            }

            var centStr = "";
            var centArray = number.ToString("0.00").Split(".".ToCharArray());
            if (centArray.Length == 2)
                centStr = centArray[1];
            var c = 0;
            if (int.TryParse(centStr, out c) && Validator.ValidateCentPlace(c))
            {
                cent = new CentPlace(c);
            }
        }

        public string ConvertToWord(decimal number)
        {
            Init(number);

            var sb = new StringBuilder();
            
            if (million != null)
                sb.Append(million.ToWord());

            if (thousand != null)
            {
                if (sb.Length > 0)
                    sb.Append(" and ");
                sb.Append(thousand.ToWord());
            }

            if (hundred != null)
            {
                if (sb.Length > 0)
                    sb.Append(" and ");
                sb.Append(hundred.ToWord());
            }

            if (ten != null)
            {
                if (sb.Length > 0)
                    sb.Append(" and ");
                sb.Append(ten.ToWord());
            }

            if (one != null)
            {
                if (sb.Length > 0)
                    sb.Append(" and ");
                sb.Append(one.ToWord());
            }

            if (sb.ToString() == "One")
                sb.Append(" dollar");
            else if (sb.Length > 0)
                sb.Append(" dollars");

            if (cent != null)
            {
                if (sb.Length > 0)
                    sb.Append(" and ");
                sb.Append(cent.ToWord());
            }

            if (sb.Length > 0)
                sb.Append(" Only");

            return sb.ToString().FirstLetterToUpperOnly();
        }
    }
}
