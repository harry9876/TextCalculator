using System.Text;
using TextCalculator.Expression;

namespace TextCalculator.Tests
{
    public class CalculatorTests
    {
        private Calculator _calculator;

        IList<ISetExpression> _set;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
            _set = null;
        }
        [Test]

        public void Calc_PreIncrease_J_Increasted()
        {
            _set = new List<ISetExpression>()
            {
                new SetExpression('i',new NumberExpression(0)),
                new SetExpression('j', new IncreaseExpression( 'i',Order.Pre)),
            };

            var actual = _calculator.Calc(_set);

            var excepted = new Dictionary<char, int>
            {
                { 'i',1},
                { 'j',1}
            };

            AssertEqualDic(actual, excepted);
        }
        [Test]
        public void Calc_PostIncrease_J_NotIncreasted()
        {
            _set = new List<ISetExpression>()
            {
                new SetExpression('i',new NumberExpression(0)),
                new SetExpression('j', new IncreaseExpression( 'i',Order.Post)),
            };

            var actual = _calculator.Calc(_set);

            var excepted = new Dictionary<char, int>
            {
                { 'i',1},
                { 'j',0}
            };

            AssertEqualDic(actual, excepted);
        }

        [Test]

        public void Calc_PreDecrease_J_Decreasted()
        {
            _set = new List<ISetExpression>()
            {
                new SetExpression('i',new NumberExpression(3)),
                new SetExpression('j', new DecreaseExpression( 'i',Order.Pre)),
            };

            var actual = _calculator.Calc(_set);

            var excepted = new Dictionary<char, int>
            {
                { 'i',2},
                { 'j',2}
            };

            AssertEqualDic(actual, excepted);
        }
        [Test]
        public void Calc_PostDecrease_J_NotDecreasted()
        {
            _set = new List<ISetExpression>()
            {
                new SetExpression('i',new NumberExpression(3)),
                new SetExpression('j', new DecreaseExpression( 'i',Order.Post)),
            };

            var actual = _calculator.Calc(_set);

            var excepted = new Dictionary<char, int>
            {
                { 'i',2},
                { 'j',3}
            };

            AssertEqualDic(actual, excepted);
        }

        [Test]
        public void Calc_VariableSettingExpression_ReturnVariableValue()
        {

            _set = new List<ISetExpression>()
            {
                new SetExpression( 'i', new NumberExpression(10)),

                new SetExpression('j', new VariableExpression('i'))
            };

            var actual = _calculator.Calc(_set);

            var excepted = new Dictionary<char, int>
            {
                { 'i',10},
                { 'j',10}
            };

            AssertEqualDic(actual, excepted);
        }

        [Test]
        public void Calc_SimpleSetExpression_NumberSet()
        {

            _set = new List<ISetExpression>()
            {
                new SetExpression('i', new NumberExpression(10))
            };

            var actual = _calculator.Calc(_set);

            var excepted = new Dictionary<char, int>
            {
                { 'i',10},
            };

            AssertEqualDic(actual, excepted);
        }

        [Test]
        public void Calc_OperationExpression_SetOpeartionCalculation()
        {
            _set = new List<ISetExpression>()
            {
                new SetExpression('i', new OperationExpression(new NumberExpression(10),new NumberExpression(5),'/'))
            };


            var actual = _calculator.Calc(_set);

            var excepted = new Dictionary<char, int>
            {
                { 'i',2},
            };

            AssertEqualDic(actual, excepted);
        }
        [Test]

        public void Calc_InnerIncreaseExpression_CalcInnerIncrease()
        {
            _set = new List<ISetExpression>()
            {
                new SetExpression('x', new OperationExpression( new IncreaseExpression('i',Order.Post),new NumberExpression(5),'+'))
            };

            var actual = _calculator.Calc(_set);

            var excepted = new Dictionary<char, int>
            {
                { 'x',5},
                { 'i',1}
            };

            AssertEqualDic(actual, excepted);
        }

        [Test]
        public void Calc_InnerDecreaseExpression_CalcInnerDecrease()
        {
            _set = new List<ISetExpression>()
            {
                new SetExpression('i', new NumberExpression(10)),
                new SetExpression('x', new OperationExpression( new DecreaseExpression('i',Order.Post),new NumberExpression(5),'+'))
            };

            var actual = _calculator.Calc(_set);

            var excepted = new Dictionary<char, int>
            {
                { 'i',9},
                { 'x',15}
            };

            AssertEqualDic(actual, excepted);
        }


        private void AssertEqualDic(Dictionary<char, int> actual, Dictionary<char, int> excepted)
        {
            Assert.That(actual.Count, Is.EqualTo(excepted.Count));
            var actualArrey = actual.Cast<KeyValuePair<char, int>>().ToArray();
            var exceptedArrey = excepted.Cast<KeyValuePair<char, int>>().ToArray();
            for (int i = 0; i < excepted.Count; i++)
            {
                Assert.That(actualArrey[i].Key, Is.EqualTo(exceptedArrey[i].Key));
                Assert.That(actualArrey[i].Value, Is.EqualTo(exceptedArrey[i].Value));
            }
        }
    }
}