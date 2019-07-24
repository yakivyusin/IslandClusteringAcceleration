using System;

namespace IslandClusteringAcceleration.Helpers
{
    internal class VectorPositionCalculationHelper
    {
        public int GetPositionInVector(int i, int j, int matrixDimension)
        {
            if (i == j)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (i > j)
            {
                var temp = i;
                i = j;
                j = temp;
            }

            return matrixDimension * (matrixDimension - 1) / 2 - (matrixDimension - i) * (matrixDimension - i - 1) / 2 + j - i - 1;
        }
    }
}
