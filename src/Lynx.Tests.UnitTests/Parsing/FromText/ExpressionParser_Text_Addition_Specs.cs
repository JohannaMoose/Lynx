using System;
using Lynx.Core;
using Lynx.Core.Numbers;
using Lynx.Parsing;
using NUnit.Framework;

namespace Lynx.Tests.UnitTests.Parsing.FromText
{
    [TestFixture]
    public class ExpressionParser_Specs
    {
        #region FromText

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
        public void fromText_should_set_random_value_of_variable_with_constrictions()
        {
            // When 
            var result = ExpressionParser.FromText("a: [1,8] \n b: [1,8] && (a <=2 || b <= 2) \n a=b ");
           
            // Then
            for (var i = 0; i < 100; i++)
            {
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
        }

        /*
        [Test]
        public void fromText_should_create_a_basic_addition()
        {
            // When 
            var result = ExpressionParser.FromText("a+b=c");

            // Then
            Assert.IsInstanceOf<Addition>(result.LeftSide);
        }

        [Test]
        public void fromText_should_set_right_side()
        {
            // When 
            var result = ExpressionParser.FromText("a+b=c");

            // Then
            Assert.AreEqual(((Variable)result.RightSide).Designation, "c");
        }

        [Test]
        public void fromText_should_find_variables_of_leftHand_variable()
        {
            // When 
            var result = ExpressionParser.FromText("a+b=c");
            var addition = result.LeftSide as Addition;

            // Then
            Assert.AreEqual(((Variable)addition.LeftSide).Designation, "a");
            Assert.AreEqual(((Variable)addition.RightSide).Designation, "b");
        }*/

        #endregion FromText
    }
}