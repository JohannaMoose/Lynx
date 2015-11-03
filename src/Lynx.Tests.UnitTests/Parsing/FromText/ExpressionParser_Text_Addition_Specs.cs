using System;
using Lynx.Core;
using Lynx.Core.Numbers;
using Lynx.Core.Operators;
using Lynx.Parsing;
using NUnit.Framework;

namespace Lynx.Tests.UnitTests.Parsing.FromText
{
    [TestFixture]
    public class ExpressionParser_Text_Addition_Specs
    {

        [Test]
        public void fromText_should_create_a_basic_addition()
        {
            // When 
            var result = ExpressionParser.FromText("a: [1,8] \n " +
                                                   "b: [1,8] && (a <=2 || b <= 2) \n " +
                                                   "c: a+b \n " +
                                                   "a+b=c");

            // Then
            Assert.IsInstanceOf<Addition>(result.LeftSide);
        }

        
        [Test]
        public void fromText_should_set_right_side()
        {
            // When 
            var result = ExpressionParser.FromText("a: [1,8] \n " +
                                                   "b: [1,8] && (a <=2 || b <= 2) \n " +
                                                   "c: a+b \n " +
                                                   "a+b=c");

            // Then
            Assert.AreEqual(((Variable)result.RightSide).Designation, "c");
        }

        [Test]
        public void fromText_should_find_variables_of_leftHand_variable()
        {
            // When 
            var result = ExpressionParser.FromText("a: [1,8] \n " +
                                                   "b: [1,8] && (a <=2 || b <= 2) \n " +
                                                   "c: a+b \n " +
                                                   "a+b=c");
            var addition = result.LeftSide as Addition;

            // Then
            Assert.AreEqual(((Variable)addition.LeftSide).Designation, "a");
            Assert.AreEqual(((Variable)addition.RightSide).Designation, "b");
        }

    }
}