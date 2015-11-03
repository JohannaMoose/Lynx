using System;
using Lynx.Core;
using Lynx.Core.Numbers;
using Lynx.Core.Operators;
using Moq;
using NUnit.Framework;

namespace Lynx.Tests.UnitTests.Core.Operators
{
    [TestFixture]
    [SetUICulture("en-US")]
    public class Multiplication_Specs
    {
        private Multiplication SUT;

        [SetUp]
        public void Setup()
        {
            SUT = new Multiplication(new Variable("a", new RealNumber(1)), new Variable("b", new RealNumber(1)));
        }

        [TearDown]
        public void Teardown()
        {
            SUT = null;
        }

        [Test]
        public void should_be_Operator()
        {
            Assert.IsInstanceOf<Operator>(SUT);
        }

        #region Constructor

        [Test]
        public void constructor_should_set_left_number()
        {
            // Given 
            var nbr = new Variable("a", new RealNumber(1));

            // When 
            SUT = new Multiplication(nbr, new Variable("b", new RealNumber(1)));

            // Then
            Assert.AreSame(nbr, SUT.LeftSide);
        }

        [Test]
        public void constructor_should_set_right_number()
        {
            // Given 
            var nbr = new Variable("a", new RealNumber(1));

            // When 
            SUT = new Multiplication(new Variable("b", new RealNumber(1)), nbr);

            // Then
            Assert.AreSame(nbr, SUT.RightSide);
        }

        [Test]
        public void constructor_should_throw_if_left_is_null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new Multiplication(null, new Variable("a", new RealNumber(1))));
            Assert.AreEqual("The left number can't be null\r\nParameter name: left", ex.Message);
        }

        [Test]
        public void constructor_should_throw_if_right_is_null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new Multiplication(new Variable("a", new RealNumber(1)), null));
            Assert.AreEqual("The right number can't be null\r\nParameter name: right", ex.Message);
        }

        #endregion Constructor

        #region Calculate

        [Test]
        public void calculate_should_return_real_number_with_multi_value()
        {
            // Given 
            SUT = new Multiplication(new RealNumber(2.0), new RealNumber(6.0));

            // When 
            var result = SUT.Calculate();

            // Then
            Assert.IsInstanceOf<RealNumber>(result);
        }

        [Test]
        public void calculate_should_return_number_that_is_the_multi()
        {
            // Given 
            SUT = new Multiplication(new RealNumber(2.0), new RealNumber(6.0));

            // When 
            var result = SUT.Calculate() as RealNumber;

            // Then
            Assert.AreEqual(12.0, result.Value);
        }

        #endregion Calculate

        #region GetRealNumber

        [Test]
        public void getRealNumber_should_return_number_that_is_the_multiplication()
        {
            // Given 
            SUT = new Multiplication(new RealNumber(2.0), new RealNumber(6.0));

            // When 
            var result = SUT.GetRealNumber();

            // Then
            Assert.AreEqual(12.0, result.Value);
        }

        #endregion GetRealNumber

        #region Regenerate

        [Test]
        public void regenerate_should_regenerate_left_number()
        {
            // Given 
            var nbr = new Mock<Number>();
            SUT = new Multiplication(nbr.Object, new RealNumber(1));

            // When 
            SUT.Regenerate();

            // Then
            nbr.Verify(x => x.Regenerate());
        }
        [Test]
        public void regenerate_should_regenerate_right_number()
        {
            // Given 
            var nbr = new Mock<Number>();
            SUT = new Multiplication(new RealNumber(1), nbr.Object);

            // When 
            SUT.Regenerate();

            // Then
            nbr.Verify(x => x.Regenerate());
        }

        #endregion Regenerate
    }
}