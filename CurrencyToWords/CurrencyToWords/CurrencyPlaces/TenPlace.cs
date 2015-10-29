namespace CurrencyToWords.CurrencyPlaces
{
    using System;

    using CurrencyToWords.Exceptions;
    using CurrencyToWords.Extension;

    public class TenPlace : CurrencyPlace
    {
        private readonly int number;
        public TenPlace(int n)
            : base(n)
        {
            if (!IsValidNumberRange(n))
                throw new InvalidNumberRangeException();

            number = n;
        }

        public override bool IsValidNumberRange(int n)
        {
            return Validator.ValidateTenPlace(n);
        }

        public override string ToWord()
        {
            var word = number.ToWord();
            
            //match
            if (!String.IsNullOrEmpty(word))
                return number.ToWord();

            //not match, recalculate
            word = (number / 10 * 10).ToWord() + " " + new OnePlace(number % 10).ToWord();

            return word;
        }
    }
}
