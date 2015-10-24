using System;
using Lynx.Core;
using Lynx.Core.Numbers;
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

        #region Constructor

        [Test]
        public void constructor_should_set_designation()
        {
            // When 
            SUT = new Variable("a");

            // Then
            Assert.AreEqual("a", SUT.Designation);
        }

        [Test]
        [TestCaseSource(nameof(emptyStrings))]
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

        #endregion Constructor

        #region SetValue

        [Test]
        public void setValue_should_set_to_the_value()
        {
            // Given 
            var nbr = new RealNumber(5);

            // When 
            SUT.SetValue(nbr);

            // Then
            Assert.AreEqual(5.0, SUT.GetRealNumber().Value);
        }

        [Test]
        public void setValue_should_not_update_already_set_value()
        {
            // Given 
            var nbr = new RealNumber(5);
            SUT.SetValue(nbr);
            var nbr2 = new RealNumber(7);

            // When 
            SUT.SetValue(nbr2);

            // Then
            Assert.AreEqual(5.0, SUT.GetRealNumber().Value);
        }

        #endregion SetValue

        #region TestHelpers

        public string[] emptyStrings = {null, "", "   "};
        
        #endregion TestHelpers
    }
}