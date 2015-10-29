namespace CurrencyToWords.CurrencyPlaces
{
    public static class Validator
    {
        public static bool ValidateCentPlace(int n)
        {
            return n > 0 && n < 100;
        }

        public static bool ValidateHundredPlace(int n)
        {
            return n >= 100 && n < 1000;
        }

        public static bool ValidateMillionPlace(int n)
        {
            return n >= 1000000 && n <= 999999999;
        }

        public static bool ValidateOnePlace(int n)
        {
            return n > 0 && n < 10;
        }

        public static bool ValidateTenPlace(int n)
        {
            return n >= 10 && n < 100;
        }

        public static bool ValidateThousandPlace(int n)
        {
            return n >= 1000 && n <= 999999;
        }
    }
}
