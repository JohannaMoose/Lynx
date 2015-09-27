using System;
using Lynx.Core;
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

        #endregion Constructor

        #region TestHelpers

        public string[] emptyStrings = {null, "", "   "};
        
        #endregion TestHelpers
    }
}