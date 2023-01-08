using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator.Tests.Expression
{
    internal class NumberExpressionTests
    {
        [Test]
        public void Evaluate_ReturnValue_IgnoreMapper()
        {
            var expression = new NumberExpression(5);

            Assert.That(expression.Evaluate(i => 10), Is.EqualTo(5));
        }
    }
}
