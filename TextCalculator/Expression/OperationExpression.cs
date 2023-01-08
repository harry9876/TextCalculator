using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator
{
    public  class OperationExpression : IExpression
    {
        public OperationExpression(IExpression x, IExpression y, char op) 
        {
            Left= x;
            Right = y;
            Opration = op;
        }

        public IExpression Right { get; set; }
        public IExpression Left { get; set; }

        public char Opration { get; set; }

        public virtual int Evulate(Func<char, int> mapper)
        {
            var xValue = Left.Evulate(mapper);

            if (Right == default(IExpression)) return xValue;

            var yValue = Right.Evulate(mapper);

            return EvulateOperation(xValue, yValue);
        }


        private int EvulateOperation(int x, int y) => Opration switch
        {
            '+' => x + y,
            '-' => x - y,
            '*' => x * y,
            '/' => x / y,
            _ => throw new Exception("invalid operand "),
        };

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
