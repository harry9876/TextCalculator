using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator
{
    public static class Printer
    {
        public static string Print(Dictionary<char, int> variables)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append('(');

            variables.ToList().ForEach((a) => sb.Append(a.Key + "=" + a.Value.ToString() + ','));

            sb.Remove(sb.Length - 1, 1);

            sb.Append(')');

            return sb.ToString();
        }
    }
}
