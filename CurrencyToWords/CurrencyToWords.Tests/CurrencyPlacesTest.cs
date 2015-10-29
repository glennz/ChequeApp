namespace CurrencyToWords.Tests
{
    using System.Runtime.InteropServices;

    using CurrencyToWords.CurrencyPlaces;
    using CurrencyToWords.Exceptions;

    using NUnit.Framework;

    public class CurrencyPlacesTest
    {
        [Test]
        public void ShouldGetOneObject()
        {
            var one = new OnePlace(2);
            Assert.AreEqual(one.ToWord(), "Two");
        }

        [Test]
        public void ShouldNotGetOneObject()
        {
            Assert.Throws<InvalidNumberRangeException>(delegate { var one = new OnePlace(12); });
        }

        [Test]
        public void ShouldGetTenObject()
        {
            var ten = new TenPlace(12);
            Assert.AreEqual(ten.ToWord(), "Twelve");
        }

        [Test]
        public void ShouldNotGetTenObject()
        {
            Assert.Throws<InvalidNumberRangeException>(delegate { var ten = new TenPlace(120); });
        }

        [Test]
        public void ShouldGetTenWord80()
        {
            var ten = new TenPlace(80);
            var word = ten.ToWord();
            Assert.AreEqual(word, "Eighty");
        }

        [Test]
        public void ShouldGetTenWord36()
        {
            var ten = new TenPlace(36);
            var word = ten.ToWord();
            Assert.AreEqual(word, "Thirty Six");
        }

        [Test]
        public void ShouldGetTenWord91()
        {
            var ten = new TenPlace(92);
            var word = ten.ToWord();
            Assert.AreEqual(word, "Ninety Two");
        }

        [Test]
        public void ShouldGetHundredWord300()
        {
            var h = new HundredPlace(300);
            Assert.AreEqual(h.ToWord(), "Three Hundred");
        }

        [Test]
        public void ShouldNotGetHundredObjectLessThanHundred()
        {
            Assert.Throws<InvalidNumberRangeException>(delegate { var h = new HundredPlace(23); });
        }

        [Test]
        public void ShouldNotGetHundredObjectInThousand()
        {
            Assert.Throws<InvalidNumberRangeException>(delegate { var h = new HundredPlace(1000); });
        }

        [Test]
        public void ShouldGetThousand()
        {
            var t = new ThousandPlace(3000);
            Assert.AreEqual(t.ToWord(), "Three Thousand");
        }

        [Test]
        public void ShouldGetTenThousand()
        {
            var t = new ThousandPlace(30000);
            Assert.AreEqual(t.ToWord(), "Thirty Thousand");

            var t1 = new ThousandPlace(31000);
            Assert.AreEqual(t1.ToWord(), "Thirty One Thousand");

            var t2 = new ThousandPlace(99900);
            Assert.AreEqual(t2.ToWord(), "Ninety Nine Thousand");
        }

        [Test]
        public void ShouldGetHundredThousand()
        {
            var t = new ThousandPlace(300000);
            Assert.AreEqual(t.ToWord(), "Three Hundred Thousand");

            var t1 = new ThousandPlace(333000);
            Assert.AreEqual(t1.ToWord(), "Three Hundred and Thirty Three Thousand");
        }

        [Test]
        public void ShouldGetTenMillion()
        {
            var t = new MillionPlace(3000000);
            Assert.AreEqual(t.ToWord(), "Three Million");

            var t1 = new MillionPlace(31000000);
            Assert.AreEqual(t1.ToWord(), "Thirty One Million");

            var t2 = new MillionPlace(99999000);
            Assert.AreEqual(t2.ToWord(), "Ninety Nine Million");
        }

        [Test]
        public void ShouldGetHundredMillion()
        {
            var t = new MillionPlace(300000000);
            Assert.AreEqual(t.ToWord(), "Three Hundred Million");

            var t1 = new MillionPlace(301000000);
            Assert.AreEqual(t1.ToWord(), "Three Hundred and One Million");

            var t2 = new MillionPlace(321000000);
            Assert.AreEqual(t2.ToWord(), "Three Hundred and Twenty One Million");
        }

        [Test]
        public void ShouldGetDecimalWord()
        {
            var c = new CentPlace(1);
            Assert.AreEqual(c.ToWord(), "One Cent");

            c = new CentPlace(2);
            Assert.AreEqual(c.ToWord(), "Two Cents");

            c = new CentPlace(10);
            Assert.AreEqual(c.ToWord(), "Ten Cents");

            c = new CentPlace(37);
            Assert.AreEqual(c.ToWord(), "Thirty Seven Cents");
        }

        [Test]
        public void ShouldThowErrorWhenGetCents()
        {
            Assert.Throws<InvalidNumberRangeException>(delegate { var h = new CentPlace(0); });
        }
    }
}
