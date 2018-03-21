using System;
using NUnit.Framework;
using Algorithms;
using System.Diagnostics;

namespace UnitTestAlgorithms
{
    /// <summary>
    /// Class for test FindNextBiggerNumber method
    /// </summary>
    [TestFixture]
    public class NUnitTestFindBiggerNumber
    {
        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(2017, 2071)]
        [TestCase(414, 441)]
        [TestCase(144, 414)]
        [TestCase(1234321, 1241233)]
        [TestCase(1234126, 1234162)]
        [TestCase(3456432, 3462345)]
        [TestCase(10, -1)]
        [TestCase(20, -1)]
        public void FindNextBiggerNumber_With_Valid_Data(int numberInput, int result)
            => Assert.AreEqual(AlgorithmsForTask.FindNextBiggerNumber(numberInput, out _), result);

        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(2017, 2071)]
        [TestCase(414, 441)]
        [TestCase(144, 414)]
        [TestCase(1234321, 1241233)]
        [TestCase(1234126, 1234162)]
        [TestCase(3456432, 3462345)]
        [TestCase(10, -1)]
        [TestCase(20, -1)]
        public void FindNextBiggerNumber_With_Valid_Data_Tuple_As_Input_Rezalt(int numberInput, int result)
            => Assert.AreEqual(AlgorithmsForTask.FindNextBiggerNumberTuple(numberInput).Item1, result);
    }
}
