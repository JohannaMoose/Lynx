using System;
using Lynx.Core;
using Lynx.Core.Numbers;
using Lynx.Core.Operators;
using Moq;
using NUnit.Framework;

namespace Lynx.Tests.UnitTests.Core.Numbers
{
    [TestFixture]
    [SetUICulture("en-US")]
    public class AbsoluteNumber_Specs
    {
        private AbsoluteNumber SUT;

        [SetUp]
        public void Setup()
        {
            SUT = new AbsoluteNumber(new RealNumber(1));
        }

        [TearDown]
        public void Teardown()
        {
            SUT = null;
        }

        [Test]
        public void should_be_Number()
        {
            Assert.IsInstanceOf<Number>(SUT);
        }

        #region Constructor

        [Test]
        public void constructor_should_set_number()
        {
            // Given 
            var nbr = new Variable("a");

            // When 
            SUT = new AbsoluteNumber(nbr);

            // Then
            Assert.AreSame(nbr, SUT.InnerValue);
        }

        [Test]
        public void constructor_should_throw_if_left_is_null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>SUT= new AbsoluteNumber(null));
            Assert.AreEqual("The number can't be null\r\nParameter name: nbr", ex.Message);
        }

        #endregion Constructor

        #region GetRealNumber

        [Test]
        public void getRealNumber_should_return_the_absolute_number()
        {
            // Given 
            SUT = new AbsoluteNumber(new RealNumber(-2));

            // When 
            var result = SUT.GetRealNumber();

            // Then
            Assert.AreEqual(2, result.Value);
        }

        #endregion GetRealNumber

        #region Regenerate

        [Test]
        public void regenerate_should_regenerate_the_number()
        {
            // Given 
            var nbr = new Mock<Number>();
            SUT = new AbsoluteNumber(nbr.Object);

            // When 
            SUT.Regenerate();

            // Then
            nbr.Verify(x => x.Regenerate());
        }

        #endregion Regenerate
    }
}