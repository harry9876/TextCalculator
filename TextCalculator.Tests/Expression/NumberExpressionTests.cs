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
        public void Evulate_ReturnValue_IgnoreMapper()
        {
            var expression = new NumberExpression(5);

            Assert.That(expression.Evulate(i => 10), Is.EqualTo(5));
        }
    }
}
