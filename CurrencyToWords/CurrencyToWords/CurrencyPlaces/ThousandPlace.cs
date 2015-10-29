namespace CurrencyToWords.CurrencyPlaces
{
    using System;
    using System.Text;

    using CurrencyToWords.Exceptions;

    public class ThousandPlace : CurrencyPlace
    {
        private readonly int number;

        public ThousandPlace(int n) : base(n)
        {
            if (!IsValidNumberRange(n))
                throw new InvalidNumberRangeException();

            number = n;
        }

        public override bool IsValidNumberRange(int n)
        {
            return Validator.ValidateThousandPlace(n);
        }

        public override string ToWord()
        {
            var sb = new StringBuilder();

            var t = number / 1000;

            if (t < 10)
                sb.Append(String.Format("{0} Thousand", new OnePlace(t).ToWord()));
            else if (t > 9 && t < 100)
                sb.Append(String.Format("{0} Thousand", new TenPlace(t).ToWord()));
            else
            {
                sb.Append(GetHundreds(t));
            }

            return sb.ToString();
        }

        private static string GetHundreds(long t)
        {
            var sb = new StringBuilder();

            var t1 = t / 100;

            sb.Append(String.Format("{0}", new HundredPlace((int)t).ToWord()));

            var t2 = t - t1 * 100;
            if (t2 > 0 && t2 < 10)
            {
                if (sb.Length > 0)
                    sb.Append(" and ");

                sb.Append(String.Format("{0}", new OnePlace((int)t2).ToWord()));
            }
            else if (t2 > 10)
            {
                if (sb.Length > 0)
                    sb.Append(" and ");

                sb.Append(String.Format("{0}", new TenPlace((int)t2).ToWord()));
            }
            
            sb.Append(" Thousand");
            
            return sb.ToString();
        }
    }
}
