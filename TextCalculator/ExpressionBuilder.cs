using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextCalculator.Expression;

namespace TextCalculator
{
    public class PartialExpression
    {
        public IExpression Expression { get; set; }
        public string Input { get; set; }

    }
    public class ExpressionBuilder
    {


        private static readonly Dictionary<string, Func<Match, PartialExpression, PartialExpression>> _checkList = new Dictionary<string, Func<Match, PartialExpression, PartialExpression>>
        {
            { RegularExpression.EQUAL_OPERATION_CHECK, EqualOperationCreator() } ,
            { RegularExpression.OPERATION_CHECK, OperationCreator() } ,
            { RegularExpression.PRE_SET_CHECK, PreIncreaseCreator() },
            { RegularExpression.POST_SET_CHECK,PostIncreaseCreator() },
            { RegularExpression.BRACKET_CHECK, OperationCreator() },
            { RegularExpression.SIMPLE_SET_CHECK, SimpleSetCreator() },
            { RegularExpression.EXPRESSION_REST_CHECK, ExpressionRestCreator() },
            { RegularExpression.SET_REST_CHECK, CreateSetRestCheck()  }

        };

       

        public static IList<ISetExpression> Build(IEnumerable<string> inputs)
        {
            var expressions = new List<ISetExpression>();

            foreach (var input in inputs)
            {

                var setExpression = CreateSetExpression(input);

                if (setExpression != null)
                {
                    expressions.Add(setExpression);
                }
                else
                {
                    throw new Exception("expression not supported");
                }
            }
            return expressions;
        }

        public static ISetExpression CreateSetExpression(string input)
        {
            var build = CreateExpression(new PartialExpression { Expression = null, Input = input });

            return build.Expression as ISetExpression;
        }

        private static PartialExpression CreateExpression(PartialExpression inner)
        {

            if (inner.Input.Trim() == string.Empty)
            {
                return inner;
            }

            foreach (var check in _checkList)
            {
                Match match = Regex.Match(inner.Input, check.Key);

                if (match.Success)
                {
                    PartialExpression result = check.Value.Invoke(match, inner);

                    inner.Input = inner.Input.Replace(match.Groups[0].Value, " ");

                    if (result.Expression != null && result.Expression is SetExpression)
                    {
                        return result;
                    }
                    else
                    {
                        return CreateExpression(result);
                    }
                };
            }
            throw new Exception($"input {inner.Input} is not supported");
        }

        private static IExpression CreateSimpleExpression(string value)
        {
            return char.IsLetter(value[0]) ?
                new VariableExpression(value[0]) :
                new NumberExpression(Convert.ToInt32(value));
        }

        #region Checks
        private static Func<Match, PartialExpression, PartialExpression> CreateSetRestCheck()
        {
            return (m, inner) =>
            {
                inner.Expression = new SetExpression(m.Groups[0].Value[0],
                     inner.Expression);
                return inner;
            };
        }

        private static Func<Match, PartialExpression, PartialExpression> EqualOperationCreator()
        {
            return (m, inner) =>
            {
                inner.Expression = new EqualOperationExpression(m.Groups[1].Value[0],
                    CreateSimpleExpression(m.Groups[3].Value), m.Groups[2].Value[0]);
                return inner;
            };
        }

        private static Func<Match, PartialExpression, PartialExpression> OperationCreator()
        {
            return (m, inner) =>
            {
                inner.Expression = new OperationExpression(
                          CreateSimpleExpression(m.Groups[1].Value),
                          CreateSimpleExpression(m.Groups[3].Value),
                          m.Groups[2].Value[0]);

                return inner;
            };
        }

        private static Func<Match, PartialExpression, PartialExpression> ExpressionRestCreator()
        {
            return (m, inner) =>
            {
                inner.Expression = new OperationExpression(
                          inner.Expression,
                        CreateSimpleExpression(m.Groups[2].Value),
                        m.Groups[1].Value[0]);

                return inner;
            };
        }

        private static Func<Match, PartialExpression, PartialExpression> PreIncreaseCreator()
        {
            return (m, inner) =>
            {
                inner.Expression = new IncreaseExpression(m.Groups[2].Value[0], Order.Pre);

                return inner;
            };
        }

        private static Func<Match, PartialExpression, PartialExpression> SimpleSetCreator()
        {
            return (m, inner) =>
            {
                inner.Expression = new SetExpression(
                             m.Groups[1].Value[0],
                              CreateSimpleExpression(m.Groups[3].Value)
                              );

                return inner;
            };
        }

        private static Func<Match, PartialExpression, PartialExpression> PostIncreaseCreator()
        {
            return (m, inner) =>
            {
                inner.Expression = new IncreaseExpression(m.Groups[1].Value[0], Order.Post);

                return inner;
            };
        }

        private static Func<Match, PartialExpression, PartialExpression> BracketCreator()
        {
            return (m, inner) =>
            {
                inner.Expression = new OperationExpression(
                          CreateSimpleExpression(m.Groups[2].Value),
                          CreateSimpleExpression(m.Groups[4].Value),
                          m.Groups[3].Value[0]);

                return inner;
            };
        }
        #endregion

    }
}
