using Lynx.Core;
using Lynx.Core.Numbers;
using NUnit.Framework;

namespace Lynx.Tests.UnitTests.Core.Numbers
{
    [TestFixture]
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
    }
}