using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TextCalculator
{
    public abstract class SimpleExpression<T> : IExpression
    {
        public SimpleExpression(T x)
        {
            X = x;
        }

        public T X { get; set; }
        public abstract int Evaluate(Func<char, int> mapper);

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

   

    

    
}
