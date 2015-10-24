using System;
using Lynx.Core.Conditions;
using Lynx.Core.Numbers;
using NUnit.Framework;

namespace Lynx.Tests.UnitTests.Core.Conditions
{
    [TestFixture]
    [SetUICulture("en-US")]
    public class LessThan_Specs
    {
        private LessThan SUT;

        [SetUp]
        public void Setup()
        {
            SUT = new LessThan(new RealNumber(1), new RealNumber(2));
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
        public void constructor_should_set_evaluate_nbr()
        {
            // Given 
            var nbr = new RealNumber(1);

            // When 
            SUT = new LessThan(nbr, new RealNumber(5));

            // Then
            Assert.AreSame(nbr, SUT.ToEvaluate);
        }
        [Test]
        public void constructor_should_set_evaluateAgainst_nbr()
        {
            // Given 
            var nbr = new RealNumber(1);

            // When 
            SUT = new LessThan(new RealNumber(5), nbr);

            // Then
            Assert.AreSame(nbr, SUT.EvaluateAgainst);
        }

        [Test]
        public void constructor_should_set_equals_flag()
        {
            // When 
            SUT = new LessThan(new RealNumber(1),new RealNumber(4), true);

            // Then
            Assert.IsTrue(SUT.AllowEqual);
        }

        [Test]
        public void constructor_should_throw_if_evaluate_is_null()
        {
            // Then
            var ex = Assert.Throws<ArgumentNullException>(() => new LessThan(null, new RealNumber(1)));
            Assert.AreEqual("Numbers can't be null\r\nParameter name: toEvaluate", ex.Message);
        }

        [Test]
        public void constructor_should_throw_if_evaluateAgainst_is_null()
        {
            // Then
            var ex = Assert.Throws<ArgumentNullException>(() => new LessThan(new RealNumber(1), null));
            Assert.AreEqual("Numbers can't be null\r\nParameter name: evaulateAgainst", ex.Message);
        }

        #endregion Constructor

        #region ConditionMeet

        [Test]
        public void condidtionMeet_should_return_true_if_nbr_is_less()
        {
            // When 
            SUT = new LessThan(new RealNumber(1), new RealNumber(2));

            // Then
            Assert.IsTrue(SUT.ConditionMeet);
        }

        [Test]
        public void conditionMeet_should_return_false_if_number_is_greater()
        {
            // When 
            SUT = new LessThan(new RealNumber(3), new RealNumber(2));

            // Then
            Assert.IsFalse(SUT.ConditionMeet);
        }

        [Test]
        public void conditionMeet_should_return_true_if_same_for_allow_equal()
        {
            // When 
            SUT = new LessThan(new RealNumber(2), new RealNumber(2), true);

            // Then
            Assert.IsTrue(SUT.ConditionMeet);
        }

        [Test]
        public void conditionMeet_should_return_false_if_same_for_not_allow_equal()
        {
            // When 
            SUT = new LessThan(new RealNumber(2), new RealNumber(2));

            // Then
            Assert.IsFalse(SUT.ConditionMeet);
        }

        #endregion ConditionMeet
    }
}