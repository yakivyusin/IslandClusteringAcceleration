using System;

namespace IslandClusteringAcceleration.Models
{
    public class CorrelationMatrix
    {
        private int _dimension;
        private double[] _valueVector;

        public CorrelationMatrix(int dimension)
        {
            _dimension = dimension;
            _valueVector = new double[_dimension * (_dimension - 1) / 2];
        }

        public double this[int i, int j]
        {
            get => _valueVector[GetPositionInVector(i, j)];
            set => _valueVector[GetPositionInVector(i, j)] = value;
        }

        private int GetPositionInVector(int i, int j)
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

            return _dimension * (_dimension - 1) / 2 - (_dimension - i) * (_dimension - i - 1) / 2 + j - i - 1;
        }
    }
}
