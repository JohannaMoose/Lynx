using System;
using Lynx.Core;
using Lynx.Core.Numbers;
using Lynx.Parsing;
using NUnit.Framework;

namespace Lynx.Tests.UnitTests.Parsing.FromText
{
    [TestFixture]
    public class ExpressionParser_Text_Variables_Specs
    {
        [Test]
        public void fromText_should_set_random_value_of_variable()
        {
            // When 
            var result = ExpressionParser.FromText("a: [1,8] \n a=a ");
            var a = result.LeftSide as Variable;

            // Then
            Assert.IsInstanceOf<RandomInteger>(a.Value);
        }

        [Test]
        [Repeat(10)]
        public void fromText_should_set_random_value_of_variable_with_lessThan_constrictions()
        {
            // When 
            var result = ExpressionParser.FromText("a: [1,8] \n b: [1,8] && (a <=2 || b <= 2) \n a=b ");

            // Then
            var a = result.LeftSide as Variable;
            var b = result.RightSide as Variable;

            a.Regenerate();
            b.Regenerate();

            Assert.LessOrEqual(
                a.GetRealNumber().Value < b.GetRealNumber().Value
                    ? a.GetRealNumber().Value
                    : b.GetRealNumber().Value, 2,
                "Values were {0} and {1}", a.GetRealNumber().Value, b.GetRealNumber().Value);
        }

        [Test]
        [Repeat(100)]
        public void fromText_should_set_condition_that_is_leq_of_absolut_number()
        {
            // When 
            var result = ExpressionParser.FromText("a: [1,3] \n b: [1,9] && (|a-b|<=2) \n a=b ");

            // Then
            var a = result.LeftSide as Variable;
            var b = result.RightSide as Variable;

            a.Regenerate();
            b.Regenerate();

            Assert.LessOrEqual(Math.Abs(a.GetRealNumber().Value - b.GetRealNumber().Value), 2);
        }

        [Test]
        [Repeat(100)]
        public void fromText_should_set_condition_that_is_equal_for_the_condition()
        {
            // When 
            var result = ExpressionParser.FromText("a: [1,3] \n b: [1,9] && (a=b) \n a=b ");

            // Then
            var a = result.LeftSide as Variable;
            var b = result.RightSide as Variable;

            a.Regenerate();
            b.Regenerate();

            Assert.AreEqual(a.GetRealNumber().Value, b.GetRealNumber().Value);
        }

        [Test]
        [Repeat(100)]
        public void fromText_should_set_condition_that_is_equal_to_multiple_of_other()
        {
            // When 
            var result = ExpressionParser.FromText("a: [1,3] \n b: [1,9] && (b=a*2) \n a=b ");

            // Then
            var a = result.LeftSide as Variable;
            var b = result.RightSide as Variable;

            a.Regenerate();
            b.Regenerate();

            Assert.AreEqual(a.GetRealNumber().Value*2, b.GetRealNumber().Value);
        }

        [Test]
        [Repeat(100)]
        public void fromText_should_set_condition_that_is_not_equal_for_the_condition()
        {
            // When 
            var result = ExpressionParser.FromText("a: [1,3] \n b: [1,4] && (a!=b) \n a=b ");

            // Then
            var a = result.LeftSide as Variable;
            var b = result.RightSide as Variable;

            a.Regenerate();
            b.Regenerate();

            Assert.AreNotEqual(a.GetRealNumber().Value, b.GetRealNumber().Value);
        }
    }
}