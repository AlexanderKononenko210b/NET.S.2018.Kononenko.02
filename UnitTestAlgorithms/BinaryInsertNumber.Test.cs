using System;
using NUnit.Framework;
using Algorithms;

namespace UnitTestAlgorithms
{
    /// <summary>
    /// Class for test BinaryInsertNumber method
    /// </summary>
    [TestFixture]
    public class BinaryInsertNumber
    {
        /// <summary>
        /// Test method BinaryInsertNumber with valid data
        /// </summary>
        /// <param name="numberDestination">number for insert</param>
        /// <param name="numberSource">source number</param>
        /// <param name="indexStartInsert">index start insert</param>
        /// <param name="indexEndInsert">index end insert</param>
        /// <param name="result">number destination after insert</param>
        [TestCase(15, 15, 0, 0, 15)]
        [TestCase(8, 15, 0, 0, 9)]
        [TestCase(8, 15, 3, 8, 120)]
        [TestCase(3, 7, 1, 3, 15)]
        [TestCase(14, 1, 0, 0, 15)]
        [TestCase(15, 1, 0, 0, 15)]
        [TestCase(12, 3, 1, 2, 14)]
        public void BinaryInsertNumber_With_Valid_Data(int numberDestination, int numberSource, int indexStartInsert, int indexEndInsert, int result)
            => Assert.AreEqual(AlgorithmsForTasks.BinaryInsertNumber(numberDestination, numberSource, indexStartInsert, indexEndInsert), result);

        /// <summary>
        /// Test method BinaryInsertNumber with not valid data
        /// </summary>
        /// <param name="numberDestination">number for insert</param>
        /// <param name="numberSource">source number</param>
        /// <param name="indexStartInsert">index start insert</param>
        /// <param name="indexEndInsert">index end insert</param>
        /// <param name="result">number destination after insert</param>
        [TestCase(-1, 15, 0, 0, 15)]
        [TestCase(15, -1, 0, 0, 15)]
        [TestCase(3, 7, -1, 3, 15)]
        [TestCase(3, 7, 1, -1, 15)]
        [TestCase(3, 7, 1, 0, 15)]
        public void BinaryInsertNumber_With_Not_Valid_Data(int numberDestination, int numberSource, int indexStartInsert, int indexEndInsert, int result)
            => Assert.Throws<ArgumentOutOfRangeException>(() => AlgorithmsForTasks.BinaryInsertNumber(numberDestination, numberSource, indexStartInsert, indexEndInsert));
    }
}
