using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator.Tests.Expression
{
    internal class VariableExpressionTests
    {
        [Test]
        public void Evaluate_ReturnOutValue()
        {
            var expression = new VariableExpression('i');

            Assert.That(expression.Evaluate(i => 5), Is.EqualTo(5));
        }
    }
}
