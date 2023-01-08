using System.Text;
using System.Text.RegularExpressions;
using TextCalculator.Expression;

namespace TextCalculator.Tests
{
    public class RegularExpressionTests
    {

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void PRE_INCREASE_CHECK_POSITIVE()
        {
            const string input = "++i";

            var match = Regex.Match(input, RegularExpression.PRE_SET_CHECK);

            Assert.IsTrue(match.Success);

        }

        [Test]
        public void POST_INCREASE_CHECK_POSITIVE()
        {
            const string input = "i++";

            var match = Regex.Match(input, RegularExpression.POST_SET_CHECK);

            Assert.IsTrue(match.Success);
        }

        public void PRE_DECREASE_CHECK_POSITIVE()
        {
            const string input = "--i";

            var match = Regex.Match(input, RegularExpression.PRE_SET_CHECK);

            Assert.IsTrue(match.Success);

        }

        [Test]
        public void POST_DECREASE_CHECK_POSITIVE()
        {
            const string input = "i--";

            var match = Regex.Match(input, RegularExpression.POST_SET_CHECK);

            Assert.IsTrue(match.Success);
        }

        [Test]
        public void SIMPLE_SET_CHECK_POSITIVE()
        {
            var match = Regex.Match("i=6", RegularExpression.SIMPLE_SET_CHECK);

            Assert.IsTrue(match.Success);
        }

        [Test]
        public void BRACKET_CHECK_POSITIVE()
        {
            var match = Regex.Match("(1+2)*6", RegularExpression.BRACKET_CHECK);

            Assert.IsTrue(match.Success);
        }

        [Test]
        public void BRACKET_CHECK_NEGATIVE()
        {
            var match = Regex.Match("(1+2*6", RegularExpression.BRACKET_CHECK);

            Assert.IsFalse(match.Success);
        }

        [Test]
        public void SET_REST_CHECK_POSITIVE()
        {
            var match = Regex.Match("i=7", RegularExpression.SET_REST_CHECK);

            const string excepted = "i=";

            Assert.That(match.Groups[0].Value, Is.EqualTo(excepted));
        }

        [Test]

        public void EXPRESSION_REST_CHECK_POSITIVE()
        {
            var match = Regex.Match("*6", RegularExpression.EXPRESSION_REST_CHECK);

            Assert.IsTrue(match.Success);
        }

        [Test]
        public void EXPRESSION_REST_CHECK_NoNumber_Negative()
        {
            var match = Regex.Match("+", RegularExpression.EXPRESSION_REST_CHECK);

            Assert.IsFalse(match.Success);
        }

       [Test]
        public void EQUAL_OPERATION_CHECK_TwoVariables_Positive()
         {
            var match = Regex.Match("i+=j", RegularExpression.EQUAL_OPERATION_CHECK);

            Assert.IsTrue(match.Success);
        }

        [Test]
        public void EQUAL_OPERATION_CHECK_NumberAndVariable_Negative()
        {
            var match = Regex.Match("6+=j", RegularExpression.EQUAL_OPERATION_CHECK);

            Assert.IsFalse(match.Success);
        }

        [Test]
        public void EQUAL_OPERATION_CHECK_VariableAndNumber_Negative()
        {
            var match = Regex.Match("i+=8", RegularExpression.EQUAL_OPERATION_CHECK);

            Assert.IsTrue(match.Success);
        }


    }
}