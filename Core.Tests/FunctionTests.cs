using Core.Correlation;
using Xunit;

namespace Core.Tests
{
    public class FunctionTests
    {
        [Fact]
        public void IsConstructorWithDelegateSaveValuesOnBorders()
        {
            Function function = Function.Create(x => x, 0, 10, 100);
            
            Assert.Equal(function[0].X, 0);
            Assert.Equal(function[0].Y, 0);
            Assert.Equal(function[10d].X, 10);
            Assert.Equal(function[10d].Y, 10);
            Assert.Equal(function[99].X, 10);
            Assert.Equal(function[99].Y, 10);
            Assert.Equal(function.Count, 100);
        }

        [Fact]
        public void FunctionScalesCorrectly()
        {
            Function function = Function.Create(x => 2 * x, 0, 10, 100);
            function.Scale(10);

            Assert.Equal(function.Count, 10);
            Assert.Equal(function[0].X, 0);
            Assert.Equal(function[0].Y, 0);
        }

        [Fact]
        public void AutoCorrelationPearson()
        {
            Function function = Function.Create(x => 2 * x, 0, 10, 100);
            CorrelationCalculator correlationCalculator = CorrelationCalculator.Create(CorrelationType.Pearson);
            double corr = correlationCalculator.GetCorrelation(function, function);

            Assert.Equal(corr, 1);
        }

        [Fact]
        public void AutoCorrelationKendall()
        {
            Function function = Function.Create(x => 2 * x, 0, 10, 100);
            CorrelationCalculator correlationCalculator = CorrelationCalculator.Create(CorrelationType.Kendall);
            double corr = correlationCalculator.GetCorrelation(function, function);

            Assert.Equal(corr, 1);
        }
    }
}
