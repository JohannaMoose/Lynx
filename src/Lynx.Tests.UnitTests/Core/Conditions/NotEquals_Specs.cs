using System;
using Lynx.Core.Conditions;
using Lynx.Core.Numbers;
using NUnit.Framework;

namespace Lynx.Tests.UnitTests.Core.Conditions
{
    [TestFixture] [SetUICulture("en-US")]
    public class NotEquals_Specs
    {
        private NotEquals SUT;

        [SetUp]
        public void Setup()
        {
            SUT = new NotEquals(new RealNumber(1), new RealNumber(2));
        }

        [TearDown]
        public void Teardown()
        {
            SUT = null;
        }

        [Test]
        public void should_be_Condition()
        {
            Assert.IsInstanceOf<Condition>(SUT);
        }

        #region Constructor

        [Test]
        public void contructor_should_set_left_number()
        {
            // Given 
            var nbr = new RealNumber(1);

            // When 
            SUT = new NotEquals(nbr, new RealNumber(2));

            // Then
            Assert.AreSame(nbr, SUT.Left);
        }

        [Test]
        public void contructor_should_set_right_number()
        {
            // Given 
            var nbr = new RealNumber(1);

            // When 
            SUT = new NotEquals(new RealNumber(2), nbr);

            // Then
            Assert.AreSame(nbr, SUT.Right);
        }

        [Test]
        public void constructor_should_throw_if_left_number_is_null()
        {
            // Given 

            // When 

            // Then
            var ex = Assert.Throws<ArgumentNullException>(() => SUT = new NotEquals(null, new RealNumber(1)));
            Assert.AreEqual("The left number can't be null\r\nParameter name: left", ex.Message);
        }

        [Test]
        public void constructor_should_throw_if_right_number_is_null()
        {
            // Given 

            // When 

            // Then
            var ex = Assert.Throws<ArgumentNullException>(() => SUT = new NotEquals(new RealNumber(1), null));
            Assert.AreEqual("The right number can't be null\r\nParameter name: right", ex.Message);
        }

        #endregion Constructor

        #region ConditionMeet

        [Test]
        public void conditionMeet_should_return_false_if_both_numbers_have_same_value()
        {
            // Given 
            SUT = new NotEquals(new RealNumber(1), new RealNumber(1));

            // Then
            Assert.IsFalse(SUT.ConditionMeet);
        }

        [Test]
        public void conditionMeet_should_return_true_if_both_numbers_dont_have_same_value()
        {
            // Given 
            SUT = new NotEquals(new RealNumber(1), new RealNumber(2));

            // Then
            Assert.IsTrue(SUT.ConditionMeet);
        }

        #endregion ConditionMeet
    }
}