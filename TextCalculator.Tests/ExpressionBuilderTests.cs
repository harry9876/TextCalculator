using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Text;
using TextCalculator.Expression;

namespace TextCalculator.Tests
{
    public class ExpressionBuilderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Build_SimpleSetInput_CreateSetExpression()
        {

            var expression = ExpressionBuilder.Build(new string[] { "i=0" });

            var excepted = new SetExpression('i', new NumberExpression(0));

            Assert.NotNull(expression.First());

            Assert.That(excepted.ToString(), Is.EqualTo(expression.First().ToString()));
        }

        [Test]
        public void Build_IncreaseInput_CreateIncreaseExpression()
        {
            var inputs = new string[] { "j=i++" };

            var expression = ExpressionBuilder.Build(inputs);

            var excepted =
                new SetExpression('j', new IncreaseExpression('i', Order.Post));


            Assert.That(excepted.ToString(), Is.EqualTo(expression[0].ToString()));
        }

        [Test]
        public void Build_DecreaseInput_CreateDecreaseExpression()
        {
            var inputs = new string[] { "j=i--" };

            var expression = ExpressionBuilder.Build(inputs);

            var excepted =
                new SetExpression('j', new DecreaseExpression('i', Order.Post));


            Assert.That(excepted.ToString(), Is.EqualTo(expression[0].ToString()));
        }


        [Test]
        public void Build_OperationInput_CreateOperationExpression()
        {
            var input = "x=2+4";

            var expression = ExpressionBuilder.Build(new string[] { input });

            var excepted = new SetExpression('x', new OperationExpression(new NumberExpression(2), new NumberExpression(4), '+'));

            Assert.IsNotNull(expression);
            Assert.IsNotNull(expression.First());

            Assert.That(excepted.ToString(), Is.EqualTo(expression.First().ToString()));
        }

        [Test]
        public void Build_BracketInput_CreateOperationExpression()
        {
            var input = "y=(5+3)*10";

            var expression = ExpressionBuilder.Build(new string[] { input });

            var excepted = new SetExpression('y', new OperationExpression(
                                                    new OperationExpression(new NumberExpression(5), new NumberExpression(3), '+'),
                                                    new NumberExpression(10), '*'));

            Assert.IsNotNull(expression);
            Assert.IsNotNull(expression.First());

            Assert.That(excepted.ToString(), Is.EqualTo(expression.First().ToString()));
        }

       


        [Test]
        public void Build_EqualPlusNumberInput_CreateEqualOperationExpression()
        {
            var input = "i+=7";

            var expression = ExpressionBuilder.Build(new string[] { input });

            var excepted = new EqualOperationExpression('i', new NumberExpression(7), '+');

            Assert.IsNotNull(expression);
            Assert.IsNotNull(expression[0]);

            Assert.That(excepted.ToString(), Is.EqualTo(expression[0].ToString()));
        }

        [Test]
        public void Build_EqualPlusVariableInput_CreateEqualOperationExpression()
        {
            var input = "i+=j";

            var expression = ExpressionBuilder.Build(new string[] { input });

            var excepted = new EqualOperationExpression('i', new VariableExpression('j'), '+');

            Assert.IsNotNull(expression);
            Assert.IsNotNull(expression[0]);

            Assert.That(excepted.ToString(), Is.EqualTo(expression[0].ToString()));
        }

        [Test]
        public void Build_InvalidExpression_ThrowException()
        {
            Assert.That(() => ExpressionBuilder.Build(new string[] { "x%=7" }), Throws.Exception.TypeOf<Exception>());
        }


    }
}