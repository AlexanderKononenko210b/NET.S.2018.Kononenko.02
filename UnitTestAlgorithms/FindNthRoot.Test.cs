using System;
using NUnit.Framework;
using Algorithms;

namespace UnitTestAlgorithms
{
    /// <summary>
    /// Class for test FindNthRoot method
    /// </summary>
    [TestFixture]
    public class FindNthRoot
    {
        /// <summary>
        /// Test method FindNthRoot with valid data
        /// </summary>
        /// <param name="number"></param>
        /// <param name="degree"></param>
        /// <param name="accuracy"></param>
        /// <param name="result"></param>
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        [TestCase(1, 5, 0.0001, 1.0)]
        public void FindNthRoot_With_Valid_Data(double number, int degree, double accuracy, double result)
            => Assert.AreEqual(AlgorithmsForTasks.FindNthRoot(number, degree, accuracy), result, accuracy);

        /// <summary>
        /// Test method FindNthRoot with not valid data
        /// </summary>
        /// <param name="number">input number</param>
        /// <param name="degree">degree</param>
        /// <param name="precision">precision</param>
        /// <param name="expected">expected result</param>
        [TestCase(8.0, 15, -7, -5)]
        [TestCase(8.0, 15, -0.6, -0.1)]
        public void FindNthRoot_With_Not_Valid_Data(double number, int degree, double precision, double expected)
            => Assert.Throws<ArgumentOutOfRangeException>(() => AlgorithmsForTasks.FindNthRoot(number, degree, precision));
    }
}