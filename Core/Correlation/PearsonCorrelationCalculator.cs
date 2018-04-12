using System;

namespace Core.Correlation
{
    internal class PearsonCorrelationCalculator : CorrelationCalculator
    {
        public override double GetCorrelation(Function f1, Function f2)
        {
            double numerator = 0;
            double denominator = 0;
            double denominatorSum1 = 0;
            double denominatorSum2 = 0;

            double f1Avg = f1.Average;
            double f2Avg = f2.Average;

            Scale(f1, f2);

            for (int i = 0; i < f1.Count; i++)
            {
                double f1Diff = f1[i].Y - f1Avg;
                double f2Diff = f2[i].Y - f2Avg;

                numerator += f1Diff * f2Diff;
                denominatorSum1 += Math.Pow(f1Diff, 2);
                denominatorSum2 += Math.Pow(f2Diff, 2);
            }

            denominator = Math.Sqrt(denominatorSum1 * denominatorSum2);

            return numerator / denominator;
        }
    }
}
