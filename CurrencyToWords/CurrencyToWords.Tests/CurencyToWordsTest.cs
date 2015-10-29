namespace CurrencyToWords.Tests
{
    using CurrencyToWords.Exceptions;

    using NUnit.Framework;

    public class CurencyToWordsTest
    {
        [Test]
        public void ShouldGetCurrencyWord()
        {
            var c = new CurrencyWordService();
            var words = c.ConvertToWord((decimal)90.90);

            c = new CurrencyWordService();
            words = c.ConvertToWord((decimal)1.00);

            Assert.AreEqual(words, "One dollar only");

            c = new CurrencyWordService();
            words = c.ConvertToWord((decimal)0.00);

            Assert.AreEqual(words, "");

            c = new CurrencyWordService();
            words = c.ConvertToWord((decimal)0.10);

            Assert.AreEqual(words, "Ten cents only");

            c = new CurrencyWordService();
            words = c.ConvertToWord((decimal)0.21);

            Assert.AreEqual(words, "Twenty one cents only");

            c = new CurrencyWordService();
            words = c.ConvertToWord((decimal)100.90);

            Assert.AreEqual(words, "One hundred dollars and ninety cents only");

            c = new CurrencyWordService();
            words = c.ConvertToWord((decimal)102.90);

            Assert.AreEqual(words, "One hundred and two dollars and ninety cents only");


            c = new CurrencyWordService();
            words = c.ConvertToWord((decimal)1200.90);

            Assert.AreEqual(words, "One thousand and two hundred dollars and ninety cents only");

            c = new CurrencyWordService();
            words = c.ConvertToWord((decimal)1000200.09);

            Assert.AreEqual(words, "One million and two hundred dollars and nine cents only");
        }

        [Test]
        public void ShouldThrowInvalidNumberRange()
        {
            Assert.Throws<InvalidNumberRangeException>(delegate 
            { 
                var c = new CurrencyWordService(); 
                c.ConvertToWord((decimal)1000000000.00);
            });

            Assert.Throws<InvalidNumberRangeException>(delegate
            {
                var c = new CurrencyWordService();
                c.ConvertToWord((decimal)-1.00);
            });
        }
    }
}
