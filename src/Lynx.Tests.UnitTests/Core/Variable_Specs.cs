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
            SUT = new Variable("a", new RealNumber(1));
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

        #region Full Constructor

        [Test]
        public void fullConstructor_should_set_designation()
        {
            // When 
            SUT = new Variable("a", new RealNumber(1));

            // Then
            Assert.AreEqual("a", SUT.Designation);
        }

        [Test]
        public void fullConstructor_should_set_the_number()
        {
            // Given 
            var nbr = new RealNumber(1);

            // When 
            SUT = new Variable("a", nbr);

            // Then
            Assert.AreSame(nbr, SUT.Value);
        }

        [Test]
        public void fullConstructor_should_throw_if_designation_is_nnull()
        {
            // Given 

            // When 

            // Then
            var ex =
                Assert.Throws<ArgumentNullException>(
                    () => SUT = new Variable(null, new RealNumber(1)));
            Assert.AreEqual("The designation was null, empty or just white space and that is not allowd\r\nParameter name: designation", ex.Message);

        }

        [Test]
        public void fullConstructor_should_throw_if_value_is_null()
        {
            // Given 

            // When 

            // Then
            var ex = Assert.Throws<ArgumentNullException>(
             () => SUT = new Variable("a", null));
            Assert.AreEqual("The value was null and that is not allowd\r\nParameter name: value", ex.Message);
        }

        #endregion Full Constructor

        #region Regenerate

        [Test]
        public void regenerate_should_regenerate_value()
        {
            // Given 
            var nbr = new Mock<Number>();
            SUT = new Variable("a", nbr.Object);

            // When 
            SUT.Regenerate();

            // Then
            nbr.Verify(x => x.Regenerate(), Times.Once);
        }

        [Test]
        [Repeat(100)]
        public void regenerate_should_not_set_new_value_that_does_not_match_conditions()
        {
            // Given 
            var rand = new RandomInteger(1, 4);
            var leq = new LessThan(rand, new RealNumber(2));

            SUT = new Variable("a", rand);
            SUT.SetConditions(leq);

            // When 
            SUT.Regenerate();

            // Then
            Assert.LessOrEqual(SUT.GetRealNumber().Value, 2.0);
        }

        #endregion Regenerate

        #region SetConditions

        [Test]
        public void setConditions_should_set_conditions()
        {
            // Given 
            var list = new List<Condition>
            {
                new LessThan(new RealNumber(1), new RealNumber(2))
            };

            // When 
            SUT.SetConditions(list.ToArray());

            // Then
            CollectionAssert.AreEqual(list, SUT.Conditions);
        }

        [Test]
        public void setConditions_should_return_true_when_set()
        {
            // Given 
            var list = new List<Condition>
            {
                new LessThan(new RealNumber(1), new RealNumber(2))
            };

            // When 
            var result =  SUT.SetConditions(list.ToArray());

            // Then
            Assert.IsTrue(result);
        }

        [Test]
        public void setConditions_should_not_update_if_already_set()
        {
            // Given 
            var list = new List<Condition>
            {
                new LessThan(new RealNumber(1), new RealNumber(2))
            };
            SUT.SetConditions(new LessThan(new RealNumber(4), new RealNumber(5)));

            // When 
            SUT.SetConditions(list.ToArray());

            // Then
            CollectionAssert.AreNotEqual(list, SUT.Conditions);
        }

        [Test]
        public void setConditions_should_return_false_when_not_updating()
        {
            // Given 
            var list = new List<Condition>
            {
                new LessThan(new RealNumber(1), new RealNumber(2))
            };
            SUT.SetConditions(new LessThan(new RealNumber(4), new RealNumber(5)));

            // When 
            var result = SUT.SetConditions(list.ToArray());

            // Then
            Assert.IsFalse(result);
        }

        [Test]
        public void setCondtions_should_throw_if_value_cant_match_conditions()
        {
            // Given
            SUT = new Variable("a", new RandomInteger(3, 5)); 

            // Then
            var ex =
                Assert.Throws<ArgumentException>(() => SUT.SetConditions(new LessThan(SUT.Value, new RealNumber(2))));
            Assert.AreEqual("Value can't take a number that is accepted by the conditions\r\nParameter name: conditions", ex.Message);
        }

        #endregion SetConditions

        #region TestHelpers

        public string[] EmptyStrings = {null, "", "   "};
        
        #endregion TestHelpers
    }
}