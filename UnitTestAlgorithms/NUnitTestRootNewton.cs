using System;
using NUnit.Framework;
using Algorithms;

namespace UnitTestAlgorithms
{
    /// <summary>
    /// Class for test FindNthRoot method
    /// </summary>
    [TestFixture]
    public class NUnitTestRootNewton
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        [TestCase(1, 5, 0.0001, 1.0)]
        public void S1_Test(double number, int degree, double accuracy, double result)
            => Assert.AreEqual(AlgorithmsForTask.FindNthRoot(number, degree, accuracy), result, accuracy);

        [TestCase(8.0, 15, -7, -5)]
        [TestCase(8.0, 15, -0.6, -0.1)]
        public void SquareRoot_With_Not_Valid_Data(double number, int degree, double precision, double expected)
            => Assert.Throws<ArgumentOutOfRangeException>(() => AlgorithmsForTask.FindNthRoot(number, degree, precision));
    }
}