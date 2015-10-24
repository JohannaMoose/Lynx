using System;
using Lynx.Core;
using Lynx.Core.Numbers;
using NUnit.Framework;

namespace Lynx.Tests.UnitTests.Core.Numbers
{
    [TestFixture][SetCulture("en-US")]
    public class RealNumber_Specs
    {
        private RealNumber SUT;

        [SetUp]
        public void Setup()
        {
            SUT = new RealNumber(0.0);
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

        [Test]
        public void should_be_IEquatable_double()
        {
            Assert.IsInstanceOf<IEquatable<double>>(SUT);
        }

        [Test]
        public void should_be_IEquatable_int()
        {
            Assert.IsInstanceOf<IEquatable<int>>(SUT);
        }

        #region Constructor

        [Test]
        public void constructor_should_set_number()
        {
            // When 
            SUT = new RealNumber(1.5);

            // Then
            Assert.AreEqual(1.5, SUT.Value);
        }

        #endregion Constructor

        #region GetRealNumber

        [Test]
        public void getRealNumber_should_return_itself()
        {
            // Given 
            SUT = new RealNumber(5.3);

            // When 
            var result = SUT.GetRealNumber();

            // Then
            Assert.AreSame(SUT, result);
        }

        #endregion GetRealNumber

        #region Regenerate

        [Test]
        public void regenerate_should_do_nothing()
        {
            // Given 

            // When 

            // Then
            Assert.DoesNotThrow(() => SUT.Regenerate());
        }

        #endregion Regenerate

        #region ToString

        [Test]
        public void toSTring_should_return_the_double_value()
        {
            // Given 
            SUT = new RealNumber(5.1);

            // When 
            var result = SUT.ToString();

            // Then
            Assert.AreEqual("5.1", result);
        }

        #endregion ToString

        #region equals double

        [Test]
        public void equalsDouble_should_return_true_if_same_value()
        {
            // Given 
            SUT = new RealNumber(5.1);

            // Then
            Assert.IsTrue(SUT.Equals(5.1));
        }

        [Test]
        public void equalsDouble_should_return_false_if_not_same_value()
        {
            // Given 
            SUT = new RealNumber(5.1);

            // Then
            Assert.IsFalse(SUT.Equals(1.1));
        }

        #endregion equals double

        #region Equals int

        [Test]
        public void equalsInt_should_return_true_if_same()
        {
            // Given 
            SUT = new RealNumber(5);

            // Then
            Assert.IsTrue(SUT.Equals(5));
        }

        [Test]
        public void equalInt_should_return_false_if_other_value()
        {
            // Given 
            SUT = new RealNumber(5);

            // Then
            Assert.IsFalse(SUT.Equals(1));
        }

        [Test]
        public void equalsInt_should_return_false_if_value_is_double()
        {
            // Given 
            SUT = new RealNumber(5.1);

            // Then
            Assert.IsFalse(SUT.Equals(5));
        }

        #endregion Equals int
    }
}