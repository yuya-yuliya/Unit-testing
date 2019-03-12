using NUnit.Framework;
using System;
using System.Linq;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
        }

        [Test]
        public void AddTest_NullParameter_Throws()
        {

            TestDelegate calcDelegate = () => this.calculator.Add(null);

            Assert.Throws<ArgumentNullException>(calcDelegate);
        }

        [Test]
        public void AddTest_EmptyString_ZeroResult()
        { 
            var result = this.calculator.Add("");

            Assert.AreEqual(0, result);
        }

        [TestCase("1", ExpectedResult = 1)]
        public int AddTest_OneNumber_ValidResult(string number)
        {
            return this.calculator.Add(number);
        }

        [TestCase("1,2", ExpectedResult = 3)]
        public int AddTest_TwoNumbers_ValidResult(string numbers)
        {
            return this.calculator.Add(numbers);
        }

        [TestCase("1,2,3", ExpectedResult = 6)]
        [TestCase("1,2,3,4", ExpectedResult = 10)]
        [TestCase("1,2,3,1,1,1,1,1", ExpectedResult = 11)]
        public int AddTest_DifferentAmount_ValidResult(string numbers)
        {
            return this.calculator.Add(numbers);
        }

        [TestCase("1,2\n3", ExpectedResult = 6)]
        public int AddTest_NewLineDelimiter_ValidResult(string numbers)
        {
            return this.calculator.Add(numbers);
        }

        [TestCase("1,3,\n")]
        public void AddTest_ExtraSeparators_Throws(string numbers)
        {
            TestDelegate testDelegate = () => this.calculator.Add(numbers);

            Assert.Throws<ArgumentException>(testDelegate);
        }

        [TestCase("\\;\n1;2;3", ExpectedResult = 6)]
        [TestCase("\\^\n1^2^3", ExpectedResult = 6)]
        [TestCase("\\.\n1.2.3", ExpectedResult = 6)]
        public int AddTest_DifferentDelimiter_ValidResult(string numbers)
        {
            return this.calculator.Add(numbers);
        }

        [TestCase("-11,2,3")]
        public void AddTest_NegativeNotAllowed_Throws(string numbers)
        {
            TestDelegate testDelegate = () => this.calculator.Add(numbers);

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }

        [Test]
        public void AddTest_NegativeNotAllowed_ErrorMessageHasAllNegativeNumbers()
        {
            var numbers = "-1,10,4,-5,23";
            string[] negatives = { "-1", "-5" };

            string exceptionMessage = "";
            try
            {
                this.calculator.Add(numbers);
            }
            catch (Exception e)
            {
                exceptionMessage = e.Message;
            }

            bool containsNegative = negatives.All((negative) => exceptionMessage.Contains(negative));
            Assert.True(containsNegative);
        }
    }
}
