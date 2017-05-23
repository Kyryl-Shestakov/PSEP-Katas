using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorLibrary;

namespace TestDrivenDevelopmentDemo
{
    [TestClass]
    public class FinalStringCalculatorUnitTest
    {
        [TestMethod]
        public void Add1WithEmptyArgumentTestMethod()
        {
            const string numbers = "";
            const int expected = 0;

            int actual = StringCalculator.Add9(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add1WithSingleNumberArgumentTestMethod()
        {
            const string numbers = "64";
            const int expected = 64;

            int actual = StringCalculator.Add9(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add1WithTwoNumbersArgumentTestMethod()
        {
            const string numbers = "62,800";
            const int expected = 862;

            int actual = StringCalculator.Add9(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add2TestMethod()
        {
            const string numbers = "3,9,4,89,23,12,0";
            const int expected = 140;

            int actual = StringCalculator.Add9(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add3TestMethod()
        {
            const string numbers = "3,9,4,89\n23,12\n0";
            const int expected = 140;

            int actual = StringCalculator.Add9(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add4TestMethod()
        {
            const string numbers = "//;\n3;9;4;89;23;12;0";
            const int expected = 140;

            int actual = StringCalculator.Add9(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add4WithNoNumbersInArgumentTestMethod()
        {
            const string numbers = "//;\n";
            const int expected = 0;

            int actual = StringCalculator.Add9(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add5WithNegativeNumbersInArgumentAndExpectingExceptionTestMethod()
        {
            const string numbers = "//;\n3;-9;4;89;-23;12;0";
            const int expected = 76; //kind of but not really since we expect an exception

            int actual = StringCalculator.Add9(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add5WithNegativeNumbersInArgumentTestMethod()
        {
            const string numbers = "//;\n3;-9;4;89;-23;12;0";
            string expected = "Negative numbers are not allowed: -9, -23\r\nParameter name: numbers";

            try
            {
                // ReSharper disable once UnusedVariable
                var result = StringCalculator.Add9(numbers);
            }
            catch (ArgumentException e)
            {
                string actual = e.Message;

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Add5WithNoNumbersInArgumentTestMethod()
        {
            const string numbers = "//;\n";
            const int expected = 0;

            int actual = StringCalculator.Add9(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add6WithLargeNumbersInArgumentTestMethod()
        {
            const string numbers = "//;\n3;9;4;1500;1000;89;23;12;0";
            const int expected = 1140;

            int actual = StringCalculator.Add9(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add7WithLongDelimiterTestMethod()
        {
            const string numbers = "//[;;;]\n3;;;9;;;4;;;1500;;;1000;;;89;;;23;;;12;;;0";
            const int expected = 1140;

            int actual = StringCalculator.Add9(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add7WithSingleDelimiterInBracketsTestMethod()
        {
            const string numbers = "//[;]\n3;9;4;1500;1000;89;23;12;0";
            const int expected = 1140;

            int actual = StringCalculator.Add9(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add8TestMethod()
        {
            const string numbers = "//[;][%]\n3;9;4;1500;1000;89%23;12;0";
            const int expected = 1140;

            int actual = StringCalculator.Add9(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add9TestMethod()
        {
            const string numbers = "//[;][%][***]\n3***9;4;1500;1000;89%23;12;0";
            const int expected = 1140;

            int actual = StringCalculator.Add9(numbers);

            Assert.AreEqual(expected, actual);
        }
    }
}
