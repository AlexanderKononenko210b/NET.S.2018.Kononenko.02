using System;
using NUnit.Framework;
using Algorithms;

namespace UnitTestAlgorithms
{
    /// <summary>
    /// Class for test 
    /// </summary>
    [TestFixture]
    public class NUnitTestSortMassive
    {

        /// <summary>
        /// input array
        /// </summary>
        private int[,] _inputArray;

        /// <summary>
        /// Method initialize for create input array
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            Random random = new Random();
            int lengthRow = 5, lengthСolumn = 5;

            int[,] inputArray = new int[lengthRow, lengthСolumn];
            for (int i = 0; i < lengthRow; ++i)
            {
                for (int j = 0; j < lengthСolumn; ++j)
                {
                    inputArray[i, j] = random.Next(0, 100);
                }
            }
            _inputArray = inputArray;
        }

        /// <summary>
        /// Method for test method SortSummElementAscendArray with valid data
        /// </summary>
        [Test]
        public void SortSummElementAscendArray_With_Valid_Data()
        {
            AlgorithmsForTask.SortSummElementAscendArray(_inputArray);

            Assert.IsTrue(AlgorithmsForTask.SortSummAscendHelper(_inputArray));
        }

        /// <summary>
        /// Method for test method SortSummElementDescendArray with valid data
        /// </summary>
        [Test]
        public void SortSummElementDescendArray_With_Valid_Data()
        {
            AlgorithmsForTask.SortSummElementAscendArray(_inputArray);

            Assert.IsTrue(AlgorithmsForTask.SortSummDescendHelper(_inputArray));
        }

        /// <summary>
        /// Method for test method SortMaxElementAscendHelper with valid data
        /// </summary>
        [Test]
        public void SortMaxElementAscendArray_With_Valid_Data()
        {
            AlgorithmsForTask.SortMaxElementAscendArray(_inputArray);

            Assert.IsTrue(AlgorithmsForTask.SortMaxElementAscendHelper(_inputArray));
        }

        /// <summary>
        /// Method for test method SortMaxElementDescendArray with valid data
        /// </summary>
        [Test]
        public void SortMaxElementDescendArray_With_Valid_Data()
        {
            AlgorithmsForTask.SortMaxElementDescendArray(_inputArray);

            Assert.IsTrue(AlgorithmsForTask.SortMaxElementDescendHelper(_inputArray));
        }

        /// <summary>
        /// Method for test method SortMinElementAscendArray with valid data
        /// </summary>
        [Test]
        public void SortMinElementAscendArray_With_Valid_Data()
        {
            AlgorithmsForTask.SortMinElementAscendArray(_inputArray);

            Assert.IsTrue(AlgorithmsForTask.SortMinElementAscendHelper(_inputArray));
        }

        /// <summary>
        /// Method for test method SortMinElementDescendArray with valid data
        /// </summary>
        [Test]
        public void SortMinElementDescendArray_With_Valid_Data()
        {
            AlgorithmsForTask.SortMinElementDescendArray(_inputArray);

            Assert.IsTrue(AlgorithmsForTask.SortMinElementDescendHelper(_inputArray));
        }

        /// <summary>
        /// Method for test method SortSummElementAscendArray if expected exception ArgumentNullException
        /// </summary>
        [Test]
        public void SortSummElementAscendArray_With_Not_Valid_Data_ArgumentNullException()
        {
            _inputArray = null;

            Assert.Throws<ArgumentNullException>(() => AlgorithmsForTask.SortSummElementAscendArray(_inputArray));
        }

        /// <summary>
        /// Method for test method SortSummElementAscendArray if expected exception ArgumentNullException
        /// </summary>
        [Test]
        public void SortSummElementDescendArray_With_Not_Valid_Data_ArgumentNullException()
        {
            _inputArray = null;

            Assert.Throws<ArgumentNullException>(() => AlgorithmsForTask.SortSummElementDescendArray(_inputArray));
        }

        /// <summary>
        /// Method for test method SortSummElementAscendArray if expected exception ArgumentOutOfRangeException
        /// </summary>
        [Test]
        public void SortSummElementAscendArray_With_Not_Valid_Data_ArgumentOutOfRangeException()
        {
            _inputArray = new int[0,0];

            Assert.Throws<ArgumentOutOfRangeException>(() => AlgorithmsForTask.SortSummElementAscendArray(_inputArray));
        }

        /// <summary>
        /// Method for test method SortSummElementAscendArray if expected exception ArgumentOutOfRangeException
        /// </summary>
        [Test]
        public void SortSummElementDescendArray_With_Not_Valid_Data_ArgumentOutOfRangeException()
        {
            _inputArray = new int[0, 0];

            Assert.Throws<ArgumentOutOfRangeException>(() => AlgorithmsForTask.SortSummElementDescendArray(_inputArray));
        }
    }
}
