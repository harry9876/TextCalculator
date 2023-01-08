using System.Text;
using TextCalculator.Expression;

namespace TextCalculator.Tests
{
    public class DecreaseExpressionTests
    {

        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void Ctor_Pre_CorrectPreSet()
        {
            var expression = new DecreaseExpression('i', Order.Pre);

            Assert.That(expression.Order, Is.EqualTo(Order.Pre));
        }

        [Test]
        public void Ctor_Pre_CorrectPostSet()
        {
            var expression = new DecreaseExpression('i', Order.Post);

            Assert.That(expression.Order, Is.EqualTo(Order.Post));
        }

        [Test]
        public void Ctor_CorrectRightSet()
        {
            var expression = new DecreaseExpression('i', Order.Post);

            var excepted = new OperationExpression(new VariableExpression('i'), new NumberExpression(1), '-');

            Assert.That(expression.GetSetter().Right.ToString(), Is.EqualTo(excepted.ToString()));
        }

        [Test]
        public void Ctor_CorrectLeftSet()
        {
            var expression = new DecreaseExpression('i', Order.Post);

            var excepted = new VariableExpression('i');

            Assert.That(expression.Left.ToString() , Is.EqualTo(excepted.ToString()));
        }

        [Test]
        public void Ctor_CorrectOperationSet()
        {
            var expression = new DecreaseExpression('i', Order.Post);

            Assert.That(expression.Opration, Is.EqualTo('-'));
        }

        [Test]
        public void Evaluate_CorrectValue()
        {
            var expression = new DecreaseExpression('i', Order.Pre);

            var setValue = expression.Evaluate((c) => 5);

            Assert.That(setValue, Is.EqualTo(5));
        }


    }
}