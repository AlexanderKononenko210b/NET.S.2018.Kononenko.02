using System;
using NUnit.Framework;
using Algorithms;
using System.Diagnostics;

namespace UnitTestAlgorithms
{
    /// <summary>
    /// Class for test methods FindNextBiggerNumberReference
    /// and FindNextBiggerNumberTuple
    /// </summary>
    [TestFixture]
    public class FindNextBiggerNumberReference
    {
        /// <summary>
        /// Test method FindNextBiggerNumberReference with valid data
        /// </summary>
        /// <param name="numberInput">input number</param>
        /// <param name="result">output number</param>
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
        public void FindNextBiggerNumberReference_With_Valid_Data_Out_Param(int numberInput, int result)
            => Assert.AreEqual(AlgorithmsForTasks.FindNextBiggerNumberReference(numberInput, out _), result);

        /// <summary>
        /// Test method FindNextBiggerNumberTuple with valid data
        /// </summary>
        /// <param name="numberInput">input number</param>
        /// <param name="result">output number</param>
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
        public void FindNextBiggerNumberTuple_With_Valid_Data_Tuple_As_Ouput_Rezalt(int numberInput, int result)
            => Assert.AreEqual(AlgorithmsForTasks.FindNextBiggerNumberTuple(numberInput).Item1, result);
    }
}
