using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyToWords.Tests
{
    using CurrencyToWords.CurrencyPlaces;

    using NUnit.Framework;

    public class ValidatorTest
    {
        [Test]
        public void ShouldPassValidates()
        {
            var b = Validator.ValidateCentPlace(10);
            Assert.IsTrue(b);

            b = Validator.ValidateHundredPlace(100);
            Assert.IsTrue(b);

            b = Validator.ValidateMillionPlace(100000000);
            Assert.IsTrue(b);

            b = Validator.ValidateOnePlace(1);
            Assert.IsTrue(b);

            b = Validator.ValidateTenPlace(20);
            Assert.IsTrue(b);

            b = Validator.ValidateThousandPlace(1000);
            Assert.IsTrue(b);
        }

        [Test]
        public void ShouldFailValidates()
        {
            var b = Validator.ValidateCentPlace(200);
            Assert.IsFalse(b);

            b = Validator.ValidateHundredPlace(1000);
            Assert.IsFalse(b);

            b = Validator.ValidateMillionPlace(1000000000);
            Assert.IsFalse(b);

            b = Validator.ValidateOnePlace(100);
            Assert.IsFalse(b);

            b = Validator.ValidateTenPlace(200);
            Assert.IsFalse(b);

            b = Validator.ValidateThousandPlace(0);
            Assert.IsFalse(b);
        }
    }
}
