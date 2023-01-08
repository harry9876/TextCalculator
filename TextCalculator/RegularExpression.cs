using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator
{
    public struct RegularExpression
    {
        public const string PRE_SET_CHECK = "(\\+{2})([a-z])+";
        public const string POST_SET_CHECK = "([a-z])+(\\+{2})";
        public const string BRACKET_CHECK = "\\(([a-z]|[0-9]+)([*+-\\/])([a-z]|[0-9]+)\\)";
        public const string OPERATION_CHECK = "([a-z]|[0-9]+)([*+-\\/])([a-z]|[0-9]+)";
        public const string SIMPLE_SET_CHECK = "([a-z])([=])([a-z]|[0-9]+)";
        public const string SET_REST_CHECK = "([a-z])(=)";
        public const string EXPRESSION_REST_CHECK = "([-+*\\\\])([0-9]+)";
        public const string EQUAL_OPERATION_CHECK = "([a-z])([-+*\\\\])[=]([a-z]|[0-9]+)";

    }
}
