using System;
using System.Collections.Generic;
using Lynx.Core;
using Lynx.Core.Conditions;
using Lynx.Core.Numbers;
using Moq;
using NUnit.Framework;

namespace Lynx.Tests.UnitTests.Core
{
    [TestFixture]
    [SetUICulture("en-US")]
    public class Variable_Specs
    {
        private Variable SUT;

        [SetUp]
        public void Setup()
        {
            SUT = new Variable("a");
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

        #region Designation Constructor

        [Test]
        public void constructor_should_set_designation()
        {
            // When 
            SUT = new Variable("a");

            // Then
            Assert.AreEqual("a", SUT.Designation);
        }

        [Test]
        [TestCaseSource(nameof(EmptyStrings))]
        public void constructor_should_throw_if_designation_is_null_or_empty(string str)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new Variable(str));
            Assert.AreEqual("The designation was null, empty or just white space and that is not allowd\r\nParameter name: designation", ex.Message);
        }

        [Test]
        public void constructor_should_set_vaule()
        {
            // Given 
            var nbr = new RealNumber(5);

            // When 
            SUT = new Variable("a", nbr);

            // Then
            Assert.IsTrue(((RealNumber)SUT.Value).Equals(5));
        }

        [Test]
        public void constructor_should_leave_value_as_null_if_nothing_set()
        {
            // When 
            SUT = new Variable("a");

            // Then
            Assert.IsNull(SUT.Value);
        }

        #endregion Designation Constructor

        #region Full Constructor

        [Test]
        public void fullConstructor_should_set_designation()
        {
            // When 
            SUT = new Variable("a", new RealNumber(1), new List<Condition>());

            // Then
            Assert.AreEqual("a", SUT.Designation);
        }

        [Test]
        public void fullConstructor_should_set_the_number()
        {
            // Given 
            var nbr = new RealNumber(1);

            // When 
            SUT = new Variable("a", nbr, new List<Condition>());

            // Then
            Assert.AreSame(nbr, SUT.Value);
        }

        [Test]
        public void fullConstructor_should_set_conditions()
        {
            // Given 
            var list = new List<Condition>
            {
                new Equals(new RealNumber(1), new RealNumber(1))
            };

            // When 
            SUT = new Variable("a", new RealNumber(1), list);

            // Then
            CollectionAssert.AreEqual(list, SUT.Conditions);
        }

        [Test]
        public void fullConstructor_should_throw_if_designation_is_nnull()
        {
            // Given 

            // When 

            // Then
            var ex =
                Assert.Throws<ArgumentNullException>(
                    () => SUT = new Variable(null, new RealNumber(1), new List<Condition>()));
            Assert.AreEqual("The designation was null, empty or just white space and that is not allowd\r\nParameter name: designation", ex.Message);

        }

        [Test]
        public void fullConstructor_should_throw_if_value_is_null()
        {
            // Given 

            // When 

            // Then
            var ex = Assert.Throws<ArgumentNullException>(
             () => SUT = new Variable("a", null, new List<Condition>()));
            Assert.AreEqual("The value was null and that is not allowd\r\nParameter name: value", ex.Message);
        }

        [Test]
        public void fullConstructor_should_throw_if_conditions_is_null()
        {
            // Given 

            // When 

            // Then
            var ex = Assert.Throws<ArgumentNullException>(
             () => SUT = new Variable("a", new RealNumber(1), null));
            Assert.AreEqual("The condition was null and that is not allowd\r\nParameter name: condition", ex.Message);
        }

        [Test]
        public void fullConstructor_should_throw_if_value_cant_take_value_that_matches_conditions()
        {
            // Given 
            var rand = new RandomInteger(5, 10);
            var leq = new LessThan(rand, new RealNumber(2));

            // Then
            var ex =
                Assert.Throws<ArgumentOutOfRangeException>(
                    (() => SUT = new Variable("a", rand, new List<Condition> {leq})));
            Assert.AreEqual("Value can't take a number that is accepted by the conditions\r\nParameter name: value", ex.Message);
        }

        #endregion Full Constructor

        #region Regenerate

        [Test]
        public void regenerate_should_regenerate_value()
        {
            // Given 
            var nbr = new Mock<Number>();
            SUT = new Variable("a", nbr.Object, new List<Condition>());

            // When 
            SUT.Regenerate();

            // Then
            nbr.Verify(x => x.Regenerate(), Times.Once);
        }

        [Test]
        public void regenerate_should_do_nothing_if_no_value_is_set()
        {
            // Then
            Assert.DoesNotThrow((() => SUT.Regenerate()));
        }

        [Test]
        [Repeat(100)]
        public void regenerate_should_not_set_new_value_that_does_not_match_conditions()
        {
            // Given 
            var rand = new RandomInteger(1, 4);
            var leq = new LessThan(rand, new RealNumber(2));

            SUT = new Variable("a", rand, new List<Condition> {leq});

            // When 
            SUT.Regenerate();

            // Then
            Assert.LessOrEqual(SUT.GetRealNumber().Value, 2.0);
        }

        #endregion Regenerate

        #region TestHelpers

        public string[] EmptyStrings = {null, "", "   "};
        
        #endregion TestHelpers
    }
}