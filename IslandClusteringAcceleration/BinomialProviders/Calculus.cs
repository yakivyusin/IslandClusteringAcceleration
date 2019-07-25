using IslandClusteringAcceleration.Contracts;

namespace IslandClusteringAcceleration.BinomialProviders
{
    public class Calculus : IBinomialProvider
    {
        public double GetCoefficient(double n, double k)
        {
            if (k > n)
            {
                return 0;
            }

            if (n == k)
            {
                return 1;
            }

            if (k > n - k)
            {
                k = n - k;
            }

            double result = 1;
            for (double i = 1; i <= k; i++)
            {
                result *= n--;
                result /= i;
            }

            return result;
        }
    }
}
