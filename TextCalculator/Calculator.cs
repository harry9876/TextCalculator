using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TextCalculator;
using TextCalculator.Expression;

namespace TextCalculator
{
    public class Calculator
    {
        public Dictionary<char, int> Calc(IList<ISetExpression> expressions)
        {
            Dictionary<char, int> values = new Dictionary<char, int>();

            Func<char, int> mapper = (c) => values.ContainsKey(c) ? values[c] : 0;

            foreach (var expression in expressions)
            {

                foreach (var set in GetInnerSetters(expression.Right as OperationExpression, Order.Pre))
                {
                    AddOrUpdate(values, GetPair(set, mapper));
                }

                AddOrUpdate(values, GetPair(expression, mapper));

                foreach (var set in GetInnerSetters(expression.Right as OperationExpression, Order.Post))
                {
                    AddOrUpdate(values, GetPair(set, mapper));
                }
            }

            return values;
        }

        #region Private

        private static IEnumerable<ISetExpression> GetInnerSetters(OperationExpression expression, Order order)
        {
            var setters = new List<ISetExpression>();

            if (expression == null) return setters;

            AddInner(expression, setters, order);

            return setters;
        }
        private static void AddInner(OperationExpression operation, List<ISetExpression> setters, Order order)
        {
            if (operation == null) return;

            var increase = operation as IncreaseExpression;

            if (increase != null && increase.Order == order)
            {
                setters.Add(increase.GetSetter());
            }
            AddInner(operation.Left as OperationExpression, setters, order);
            AddInner(operation.Right as OperationExpression, setters, order);
        }
        private static KeyValuePair<char, int> GetPair(ISetExpression expression, Func<char, int> mapper)
        {
            var value = expression.Evulate(mapper);

            var key = expression.Variable;

            return new KeyValuePair<char, int>(key, value);

        }
        private void AddOrUpdate(Dictionary<char, int> values, KeyValuePair<char, int> pair)
        {
            if (!values.ContainsKey(pair.Key))
            {
                values.Add(pair.Key, pair.Value);
            }
            else
            {
                values[pair.Key] = pair.Value;
            }
        }

        #endregion
    }
}






