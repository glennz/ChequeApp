namespace CurrencyToWords.CurrencyPlaces
{
    using System;
    using System.Text;

    using CurrencyToWords.Exceptions;

    public class HundredPlace : CurrencyPlace
    {
        private readonly int number;

        public HundredPlace(int n) : base(n)
        {
            if (!IsValidNumberRange(n))
                throw new InvalidNumberRangeException();

            number = n;
        }

        public override bool IsValidNumberRange(int n)
        {
            return Validator.ValidateHundredPlace(n);
        }

        /// <summary>
        /// Get Hundred word
        /// </summary>
        /// <returns>n Hundred</returns>
        public override string ToWord()
        {
            return String.Format("{0} Hundred", new OnePlace(number / 100).ToWord());
        }

        private static string GetHundreds(int t)
        {
            var sb = new StringBuilder();

            var t1 = t / 100;

            sb.Append(String.Format("{0}", new HundredPlace(t).ToWord()));

            var t2 = t - t1 * 100;
            if (t2 > 0 && t2 < 10)
            {
                if (sb.Length > 0)
                    sb.Append(" and ");

                sb.Append(String.Format("{0}", new OnePlace(t2).ToWord()));
            }
            else if (t2 > 10)
            {
                if (sb.Length > 0)
                    sb.Append(" and ");

                sb.Append(String.Format("{0}", new TenPlace(t2).ToWord()));
            }

            sb.Append(" Thousand");

            return sb.ToString();
        }
    }
}
