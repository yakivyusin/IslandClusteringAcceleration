using IslandClusteringAcceleration.Helpers;
using NUnit.Framework;
using System;

namespace IslandClusteringAcceleration.UnitTests
{
    [TestFixture]
    public class VectorPositionCalculationHelperTests
    {
        private VectorPositionCalculationHelper _vectorPositionCalculationHelper = new VectorPositionCalculationHelper();

        [Test]
        [TestCase(0, 1, 0)]
        [TestCase(0, 2, 1)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 0, 1)]
        [TestCase(2, 1, 2)]
        /// [x] [0] [1]
        /// [0] [x] [2]
        /// [1] [2] [x]
        /// <!--    -->
        /// [0] [1] [2]
        public void If_Map3DimensionMatrix_Then_HasVectorWithLength3(int i, int j, int expectedIndex)
        {
            var actualResult = _vectorPositionCalculationHelper.GetPositionInVector(i, j, 3);

            Assert.AreEqual(expectedIndex, actualResult);
        }

        [Test]
        public void If_DiagonalElement_Then_ThrowException()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => _vectorPositionCalculationHelper.GetPositionInVector(0, 0, 2));
        }
    }
}
