namespace CurrencyToWords.CurrencyPlaces
{
    using System;
    using System.Text;

    using CurrencyToWords.Exceptions;

    public class CentPlace : CurrencyPlace
    {
        private readonly int number;

        public CentPlace(int n) : base(n)
        {
            if (!IsValidNumberRange(n))
            {
                throw new InvalidNumberRangeException();
            }

            number = n;
        }

        public override bool IsValidNumberRange(int n)
        {
            return Validator.ValidateCentPlace(n);
        }

        public override string ToWord()
        {
            var sb = new StringBuilder();

            if (number < 10)
            {
                var one = new OnePlace(number);
                var word = one.ToWord();
                sb.Append(word == "One"
                              ? String.Format("{0} Cent", one.ToWord())
                              : String.Format("{0} Cents", one.ToWord()));
            }
            else
            {
                var ten = new TenPlace(number);
                sb.Append(String.Format("{0} Cents", ten.ToWord()));
            }

            return sb.ToString();
        }
    }
}
