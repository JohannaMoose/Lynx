using System.Collections.Generic;
using System.Linq;
using Lynx.Core;
using Lynx.Core.Numbers;
using NUnit.Framework;

namespace Lynx.Tests.UnitTests.Core.Numbers
{
    [TestFixture]
    public class RandomInteger_Specs
    {
        private RandomInteger SUT;

        [SetUp]
        public void Setup()
        {
            SUT = new RandomInteger(0,1);
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

        #region GetRealNumber

        [Test]
        public void getRealNumber_should_return_a_number_inside_bouderies()
        {
            // Given 
            SUT = new RandomInteger(1, 10);

            // When 
            var result = SUT.GetRealNumber().Value;

            // Then
            Assert.GreaterOrEqual(result, 1);
            Assert.Less(result, 10);
        }

        [Test]
        public void getRealNumber_should_return_the_same_value_each_time_called()
        {
            // Given 
            SUT = new RandomInteger(1, 10);

            // When 
            var results = new List<double>();
            for (int i = 0; i < 100; i++)
            {
                results.Add(SUT.GetRealNumber().Value);
            }

            // Then
            Assert.IsTrue(results.All(x => x == results[0]));
        }

        #endregion GetRealNumber

        #region Regenerate

        [Test]
        [Repeat(100)]
        public void regenerate_should_return_number_inside_bounderies()
        {
            // Given 
            SUT = new RandomInteger(1, 10);

            // When 
            SUT.Regenerate();

            // Then
            var result = SUT.GetRealNumber().Value;
            Assert.GreaterOrEqual(result, 1);
            Assert.Less(result, 10);
        }

        [Test]
        public void regenerate_should_generate_a_random_number()
        {
            // Given 
            SUT = new RandomInteger(1, 10);

            // When 
            var results = new List<double>();
            for (int i = 0; i < 100; i++)
            {
                SUT.Regenerate();
                results.Add(SUT.GetRealNumber().Value);
            }

            // Then
            for (int i = 1; i < 10; i++)
            {
                CollectionAssert.Contains(results, i);
            }
        }

        #endregion Regenerate
    }
}