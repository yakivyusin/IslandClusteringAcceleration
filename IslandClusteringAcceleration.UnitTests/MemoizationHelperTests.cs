using IslandClusteringAcceleration.Helpers;
using NUnit.Framework;
using System.Collections.Generic;

namespace IslandClusteringAcceleration.UnitTests
{
    [TestFixture]
    public class MemoizationHelperTests
    {
        private MemoizationHelper<int, int> _helper;
        private List<int> _calculatedValues = new List<int>();

        [SetUp]
        public void SetUp()
        {
            _helper = new MemoizationHelper<int, int>();
            _calculatedValues.Clear();
        }

        [Test]
        public void If_NotCalculated_Then_CallCalculationFunction()
        {
            _helper.GetValue(42, TestCalculationCallback);

            Assert.AreEqual(1, _calculatedValues.Count);
            Assert.AreEqual(42, _calculatedValues[0]);
        }

        [Test]
        public void If_CalculatedForSuchKey_Then_DontCallCalculationFunction()
        {
            _helper.GetValue(42, TestCalculationCallback);
            _helper.GetValue(42, TestCalculationCallback);

            Assert.AreEqual(1, _calculatedValues.Count);
        }

        [Test]
        public void If_CalculatedForOtherKey_Then_CallCalculationFunction()
        {
            _helper.GetValue(43, TestCalculationCallback);
            _helper.GetValue(42, TestCalculationCallback);

            Assert.AreEqual(2, _calculatedValues.Count);
            Assert.AreEqual(43, _calculatedValues[0]);
            Assert.AreEqual(42, _calculatedValues[1]);
        }

        private int TestCalculationCallback(int key)
        {
            _calculatedValues.Add(key);
            return key;
        }
    }
}
