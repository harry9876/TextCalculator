using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator
{

    public interface IExpression
    {
        int Evulate(Func<char, int> mapper);
    }
}