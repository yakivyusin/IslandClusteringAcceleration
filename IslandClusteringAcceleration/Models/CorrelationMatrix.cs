using IslandClusteringAcceleration.Helpers;
using System;

namespace IslandClusteringAcceleration.Models
{
    public class CorrelationMatrix
    {
        private int _dimension;
        private double[] _valueVector;
        private readonly VectorPositionCalculationHelper _vectorPositionCalculationHelper;

        public CorrelationMatrix(int dimension)
        {
            _dimension = dimension;
            _valueVector = new double[_dimension * (_dimension - 1) / 2];
            _vectorPositionCalculationHelper = new VectorPositionCalculationHelper();
        }

        public double this[int i, int j]
        {
            get => _valueVector[_vectorPositionCalculationHelper.GetPositionInVector(i, j, _dimension)];
            set => _valueVector[_vectorPositionCalculationHelper.GetPositionInVector(i, j, _dimension)] = value;
        }
    }
}
