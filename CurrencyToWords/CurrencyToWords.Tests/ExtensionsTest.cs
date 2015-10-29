namespace CurrencyToWords.Tests
{
    using System;
    using CurrencyToWords.Extension;

    using NUnit.Framework;

    public class ExtensionsTest
    {
        [Test]
        public void ShouldGetWordOne()
        {
            var word = 1.ToWord();
            Assert.AreEqual(word, "One");
        }

        [Test]
        public void ShouldGetWordTen()
        {
            var word = 10.ToWord();
            Assert.AreEqual(word, "Ten");
        }

        [Test]
        public void ShouldGetWordTwelve()
        {
            var word = 12.ToWord();
            Assert.AreEqual(word, "Twelve");
        }

        [Test]
        public void ShouldGetNullForNotMatch()
        {
            var word = 111.ToWord();
            Assert.AreEqual(word, String.Empty);
        }

        [Test]
        public void ShouldGetFirstLetterToUpperOnly()
        {
            string str = string.Empty;
            str = str.FirstLetterToUpperOnly();
            Assert.AreEqual(str, string.Empty);

            str = "one hundred Dollars Only";
            str = str.FirstLetterToUpperOnly();
            Assert.AreEqual(str, "One hundred dollars only");
        }
    }
}
