using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCalculator.Tests
{
    internal class DataPrinterTests
    {
        [Test]
        public void Print_Single_CorrectValue()
        {
            var dic = new Dictionary<char, int>()
            { { 'c', 0 }
            };

            var str = Printer.Print(dic);

            Assert.That(str, Is.EqualTo("(c=0)"));
        }

        [Test]
        public void Print_Multi_CorrectValue()
        {
            var dic = new Dictionary<char, int>()
            { { 'c', 0 },
             { 'x', 80 }

            };

            var str = Printer.Print(dic);

            Assert.That(str, Is.EqualTo("(c=0,x=80)"));
        }
    }
}
