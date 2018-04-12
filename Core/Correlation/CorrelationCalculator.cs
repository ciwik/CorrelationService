namespace Core.Correlation
{
    public enum CorrelationType
    {
        Pearson,
        Kendall
    }

    public abstract class CorrelationCalculator
    {
        internal CorrelationCalculator()
        {

        }

        public abstract double GetCorrelation(Function f1, Function f2);

        protected void Scale(Function f1, Function f2)
        {
            if (f1.Count > f2.Count)
                f1.Scale(f2.Count);
            else if (f2.Count > f1.Count)
                f2.Scale(f1.Count);
        }

        public static CorrelationCalculator Create(CorrelationType type)
        {
            switch (type)
            {
                case CorrelationType.Pearson:
                    return new PearsonCorrelationCalculator();
                case CorrelationType.Kendall:
                    return new KendallCorrelationCalculator();
                default:
                    return new PearsonCorrelationCalculator();
            }
        }
    }
}
