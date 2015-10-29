namespace CurrencyToWords.CurrencyPlaces
{
    using CurrencyToWords.Exceptions;
    using CurrencyToWords.Extension;

    public class OnePlace : CurrencyPlace
    {
        private readonly int number;

        public OnePlace(int n) : base(n)
        {
            if (!IsValidNumberRange(n))
                throw new InvalidNumberRangeException();

            number = n;
        }

        public override bool IsValidNumberRange(int n)
        {
            return Validator.ValidateOnePlace(n);
        }

        public override string ToWord()
        {
            return number.ToWord();
        }
    }
}
