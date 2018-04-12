namespace Core.Correlation
{
    internal class KendallCorrelationCalculator : CorrelationCalculator
    {
        public override double GetCorrelation(Function f1, Function f2)
        {
            Scale(f1, f2);

            double R = 0;
            for (int i = 0; i < f1.Count - 1; i++)
            {
                for (int j = i + 1; j < f1.Count; j++)
                {
                    bool inversion = f1[i].Y < f1[j].Y && f2[i].Y >= f2[j].Y;
                    R += inversion ? 1 : 0;
                }
            }

            double result = 4 * R / (f1.Count * (f1.Count - 1));
            result = 1 - result;

            return result;
        }
    }
}
