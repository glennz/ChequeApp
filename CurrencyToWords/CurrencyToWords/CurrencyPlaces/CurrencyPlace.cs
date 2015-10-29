namespace CurrencyToWords.CurrencyPlaces
{
    public abstract class CurrencyPlace
    {
        protected CurrencyPlace(int n)
        {
        }

        public abstract  bool IsValidNumberRange(int n);

        public abstract string ToWord();
    }
}
