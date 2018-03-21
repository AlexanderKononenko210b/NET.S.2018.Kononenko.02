using System;
using NUnit.Framework;
using Algorithms;
using System.Diagnostics;

namespace UnitTestAlgorithms
{
    /// <summary>
    /// Class for test BinaryInsertNumber method
    /// </summary>
    [TestFixture]
    public class NUnitTestBinaryInsert
    {
        [TestCase(15, 15, 0, 0, 15)]
        [TestCase(8, 15, 0, 0, 9)]
        [TestCase(8, 15, 3, 8, 120)]
        [TestCase(3, 7, 1, 3, 15)]
        [TestCase(14, 1, 0, 0, 15)]
        [TestCase(15, 1, 0, 0, 15)]
        [TestCase(12, 3, 1, 2, 14)]
        public void InsertNumber_With_Valid_Data(int numberDestination, int numberSource, int indexStartInsert, int indexEndInsert, int result)
            => Assert.AreEqual(AlgorithmsForTask.BinaryInsertNumber(numberDestination, numberSource, indexStartInsert, indexEndInsert), result);

        [TestCase(-1, 15, 0, 0, 15)]
        [TestCase(15, -1, 0, 0, 15)]
        [TestCase(3, 7, -1, 3, 15)]
        [TestCase(3, 7, 1, -1, 15)]
        [TestCase(3, 7, 1, 0, 15)]
        public void InsertNumber_With_Not_Valid_Data(int numberDestination, int numberSource, int indexStartInsert, int indexEndInsert, int result)
            => Assert.Throws<ArgumentOutOfRangeException>(() => AlgorithmsForTask.BinaryInsertNumber(numberDestination, numberSource, indexStartInsert, indexEndInsert));
    }
}
