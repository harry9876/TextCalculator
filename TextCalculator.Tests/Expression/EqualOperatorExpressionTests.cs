using System.Text;
using TextCalculator.Expression;

namespace TextCalculator.Tests
{
    public class EqualOperatorExpressionTests
    {



        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Ctor_InitCorrectLeft()
        {
            var expression = new EqualOperationExpression('i', new NumberExpression(9), '+');

            Assert.That('i', Is.EqualTo(expression.Variable));

        }

        [Test]
        public void Ctor_InitCorrectRight()
        {
            var expression = new EqualOperationExpression('i', new NumberExpression(9), '+');

            var excepted = new OperationExpression(new VariableExpression('i'), new NumberExpression(9), '+');

            Assert.That(expression.Right.ToString(), Is.EqualTo(excepted.ToString()));

        }

        [Test]
        public void Ctor_InitCorrectOperator()
        {
            var expression = new EqualOperationExpression('i', new NumberExpression(9), '+');

            var excepted = new OperationExpression(new VariableExpression('i'), new NumberExpression(9), '+');

            Assert.That((expression.Right as OperationExpression).Opration, Is.EqualTo('+'));

        }


        [Test]
        public void Evulate_CorrectValue()
        {
            var expression = new EqualOperationExpression('i', new NumberExpression(9), '+');

            Assert.That(expression.Evulate(x => 5), Is.EqualTo(14));

        }




    }
}