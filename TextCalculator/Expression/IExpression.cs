using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator
{

    public interface IExpression
    {
        int Evaluate(Func<char, int> mapper);
    }
}