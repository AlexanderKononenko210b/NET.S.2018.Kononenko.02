using System;

namespace Algorithms
{
    public static class AlgorithmsForTask
    {
        #region RootNewton

        /// <summary>
        /// Method for calculating a root of degree n from a real number by the Newton method
        /// </summary>
        /// <param name="number">number</param>
        /// <param name="degree">degree</param>
        /// <param name="accuracy">accuracy</param>
        /// <returns>rezalt</returns>
        public static double FindNthRoot(double number, int degree, double accuracy)
        {
            if (degree < 0 || degree < int.MinValue || degree > int.MaxValue || accuracy < 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(degree)} is not valid");
            }

            if (degree == 0)
            {
                return 1;
            }
            else if (degree == 1)
            {
                return number;
            }

            var x0 = number / degree;

            var x1 = (1.0 / degree) * ((degree - 1) * x0 + number / Math.Pow(x0, degree - 1));

            while (Math.Abs(x1 - x0) > accuracy)
            {
                x0 = x1;
                x1 = (1.0 / degree) * ((degree - 1) * x0 + number / Math.Pow(x0, degree - 1));
            }

            int flag = 0;

            do
            {
                accuracy *= 10;
                flag++;
            }
            while (accuracy > 0);

            return Math.Round(x1, flag - 1);
        }

        #endregion RootNewton

        #region SortMassive

        /// <summary>
        /// Method for sorting rows of an array by increasing the sum of elements in a row
        /// </summary>
        /// <param name="inputArray">input array</param>
        public static void SortSummElementAscendArray(int [,] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");
            }

            if (inputArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputArray)} length is 0");
            }

            int summ1 = 0, summ2 = 0, depthSort = inputArray.GetLength(0);
            while(depthSort != 1)
            {
                for (int i = 0; i < depthSort; ++i)
                {
                    summ2 = FindSummElement(inputArray, i);

                    if (summ1 != 0 && summ2 < summ1)
                    {
                        ChangeElementInRow(inputArray, i);
                    }

                    summ1 = summ2;

                    summ2 = 0;
                }

                depthSort--;
                summ1 = summ2 = 0;
            }
            
        }

        /// <summary>
        /// Method for sorting rows of an array by descending the sum of elements in a row
        /// </summary>
        /// <param name="inputArray">input array</param>
        public static void SortSummElementDescendArray(int[,] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");
            }

            if (inputArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputArray)} length is 0");
            }

            int summ1 = 0, summ2 = 0, depthSort = inputArray.GetLength(0);

            while (depthSort != 1)
            {
                for (int i = 0; i < inputArray.GetLength(0); ++i)
                {
                    summ2 = FindSummElement(inputArray, i);

                    if (summ1 != 0 && summ2 > summ1)
                    {
                        ChangeElementInRow(inputArray, i);
                    }

                    summ1 = summ2;

                    summ2 = 0;
                }

                depthSort--;

                summ1 = summ2 = 0;
            }
        }

        /// <summary>
        /// The method of sorting rows of an array by increasing the max values of the elements
        /// </summary>
        /// <param name="inputArray">input array</param>
        public static void SortMaxElementAscendArray(int[,] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");
            }

            if (inputArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputArray)} length is 0");
            }

            int maxElement1 = 0, maxElement2 = 0, depthSort = inputArray.GetLength(0);

            while (depthSort != 1)
            {
                for (int i = 0; i < inputArray.GetLength(0); ++i)
                {
                    maxElement2 = FindMaxElement(inputArray, i);

                    if (maxElement1 != 0 && maxElement2 < maxElement1)
                    {
                        ChangeElementInRow(inputArray, i);
                    }
                    maxElement1 = maxElement2;
                    maxElement2 = 0;
                }

                depthSort--;

                maxElement1 = maxElement2 = 0;
            }
        }

        /// <summary>
        /// The method of sorting rows of an array by decreasing the max values of the elements
        /// </summary>
        /// <param name="inputArray">input array</param>
        public static void SortMaxElementDescendArray(int[,] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");
            }

            if (inputArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputArray)} length is 0");
            }

            int maxElement1 = 0, maxElement2 = 0, depthSort = inputArray.GetLength(0);

            while (depthSort != 1)
            {
                for (int i = 0; i < inputArray.GetLength(0); ++i)
                {
                    maxElement2 = FindMaxElement(inputArray, i);

                    if (maxElement1 != 0 && maxElement2 > maxElement1)
                    {
                        ChangeElementInRow(inputArray, i);
                    }
                    maxElement1 = maxElement2;
                    maxElement2 = 0;
                }

                depthSort--;

                maxElement1 = maxElement2 = 0;
            }
        }

        /// <summary>
        /// The method of sorting rows of an array by increasing the max values of the elements
        /// </summary>
        /// <param name="inputArray">input array</param>
        public static void SortMinElementAscendArray(int[,] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");
            }

            if (inputArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputArray)} length is 0");
            }

            int minElement1 = 0, minElement2 = 0, depthSort = inputArray.GetLength(0);

            while (depthSort != 1)
            {
                for (int i = 0; i < inputArray.GetLength(0); ++i)
                {
                    minElement2 = FindMinElement(inputArray, i);

                    if (minElement1 != 0 && minElement2 < minElement1)
                    {
                        ChangeElementInRow(inputArray, i);
                    }
                    minElement1 = minElement2;
                    minElement2 = 0;
                }

                depthSort--;

                minElement1 = minElement2 = 0;
            }
        }

        /// <summary>
        /// The method of sorting rows of an array by decreasing the max values of the elements
        /// </summary>
        /// <param name="inputArray">input array</param>
        public static void SortMinElementDescendArray(int[,] inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");
            }

            if (inputArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Argument`s {nameof(inputArray)} length is 0");
            }

            int minElement1 = 0, minElement2 = 0, depthSort = inputArray.GetLength(0);
            while (depthSort != 1)
            {
                for (int i = 0; i < inputArray.GetLength(0); ++i)
                {
                    minElement2 = FindMinElement(inputArray, i);

                    if (minElement1 != 0 && minElement2 > minElement1)
                    {
                        ChangeElementInRow(inputArray, i);
                    }
                    minElement1 = minElement2;
                    minElement2 = 0;
                }

                depthSort--;

                minElement1 = minElement2 = 0;
            }
        }

        /// <summary>
        /// Method for change of element in the row
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="indexRowSource">index row source</param>
        /// <param name="indexRowDestination">index row source</param>
        /// <returns>value summ elements</returns>
        public static void ChangeElementInRow(int[,] inputArray, int indexRowSource)
        {
            for (int j = 0; j < inputArray.GetLength(1); ++j)
            {
                var number = inputArray[indexRowSource - 1, j];
                inputArray[indexRowSource - 1, j] = inputArray[indexRowSource, j];
                inputArray[indexRowSource, j] = number;
            }
        }

        /// <summary>
        /// Method for summ of element in the row
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="indexRow">index row for search</param>
        /// <returns>value summ elements</returns>
        public static int FindSummElement(int[,] inputArray, int indexRow)
        {
            var summElement = 0;

            for (int j = 0; j < inputArray.GetLength(1); ++j)
            {
                summElement += inputArray[indexRow, j];
            }

            return summElement;
        }

        /// <summary>
        /// Method for search max element in the row
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="indexRow">index row for search</param>
        /// <returns>value max element</returns>
        public static int FindMaxElement(int[,] inputArray, int indexRow)
        {
            var maxElement = inputArray[indexRow, 0];

            for (int j = 1; j < inputArray.GetLength(1); ++j)
            {
                if(inputArray[indexRow, j] > maxElement)
                {
                    maxElement = inputArray[indexRow, j];
                }
            }

            return maxElement;
        }

        /// <summary>
        /// Method for search min element in the row
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="indexRow">index row for search</param>
        /// <returns>value min element</returns>
        public static int FindMinElement(int[,] inputArray, int indexRow)
        {
            var minElement = inputArray[indexRow, 0];

            for (int j = 1; j < inputArray.GetLength(1); ++j)
            {
                if (inputArray[indexRow, j] < minElement)
                {
                    minElement = inputArray[indexRow, j];
                }
            }

            return minElement;
        }

        #endregion SortMassive

        #region SortMassiveHelper
        /// <summary>
        /// Method for check work method SortSummElementAscendArray
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public static bool SortSummAscendHelper(int[,] inputArray)
        {
            int flagStepTrue = 0, summ1 = 0, summ2 = 0;

            for (int i = 0; i < inputArray.GetLength(0); ++i)
            {
                summ2 = FindSummElement(inputArray, i);

                if (summ1 != 0 && summ2 > summ1)
                {
                    flagStepTrue++;
                }

                summ1 = summ2;

                summ2 = 0;
            }

            return flagStepTrue == inputArray.GetLength(0) - 1;
        }

        /// <summary>
        /// Method for check work method SortSummElementDescendArray
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public static bool SortSummDescendHelper(int[,] inputArray)
        {
            int flagStepTrue = 0, summ1 = 0, summ2 = 0;

            for (int i = 0; i < inputArray.GetLength(0); ++i)
            {
                summ2 = FindSummElement(inputArray, i);

                if (summ1 != 0 && summ2 < summ1)
                {
                    flagStepTrue++;
                }

                summ1 = summ2;

                summ2 = 0;
            }

            return flagStepTrue == inputArray.GetLength(0) - 1;
        }

        /// <summary>
        /// Method for check work method SortMaxElementAscendArray
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public static bool SortMaxElementAscendHelper(int[,] inputArray)
        {
            int flagStepTrue = 0, maxElement1 = 0, maxElement2 = 0;

            for (int i = 0; i < inputArray.GetLength(0); ++i)
            {
                maxElement2 = FindMaxElement(inputArray, i);

                if (maxElement1 != 0 && maxElement2 > maxElement1)
                {
                    flagStepTrue++;
                }

                maxElement1 = maxElement2;

                maxElement2 = 0;
            }

            return flagStepTrue == inputArray.GetLength(0) - 1;
        }

        /// <summary>
        /// Method for check work method SortMaxElementDescendArray
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public static bool SortMaxElementDescendHelper(int[,] inputArray)
        {
            int flagStepTrue = 0, maxElement1 = 0, maxElement2 = 0;

            for (int i = 0; i < inputArray.GetLength(0); ++i)
            {
                maxElement2 = FindMaxElement(inputArray, i);

                if (maxElement1 != 0 && maxElement2 < maxElement1)
                {
                    flagStepTrue++;
                }

                maxElement1 = maxElement2;

                maxElement2 = 0;
            }

            return flagStepTrue == inputArray.GetLength(0) - 1;
        }

        /// <summary>
        /// Method for check work method SortMinElementAscendArray
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public static bool SortMinElementAscendHelper(int[,] inputArray)
        {
            int flagStepTrue = 0, minElement1 = 0, minElement2 = 0;

            for (int i = 0; i < inputArray.GetLength(0); ++i)
            {
                minElement2 = FindMinElement(inputArray, i);

                if (minElement1 != 0 && minElement2 > minElement1)
                {
                    flagStepTrue++;
                }

                minElement1 = minElement2;

                minElement2 = 0;
            }

            return flagStepTrue == inputArray.GetLength(0) - 1;
        }

        /// <summary>
        /// Method for check work method SortMinElementDescendArray
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public static bool SortMinElementDescendHelper(int[,] inputArray)
        {
            int flagStepTrue = 0, minElement1 = 0, minElement2 = 0;

            for (int i = 0; i < inputArray.GetLength(0); ++i)
            {
                minElement2 = FindMinElement(inputArray, i);

                if (minElement1 != 0 && minElement2 < minElement1)
                {
                    flagStepTrue++;
                }

                minElement1 = minElement2;

                minElement2 = 0;
            }

            return flagStepTrue == inputArray.GetLength(0) - 1;
        }

        /// <summary>
        /// Method print in Console
        /// </summary>
        /// <param name="mas"></param>
        public static void Print(int[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); ++i, Console.WriteLine())
            {
                for (int j = 0; j < mas.GetLength(1); ++j)
                {
                    Console.Write("{0,5}", mas[i, j]);
                }
            }
        }

        #endregion SortMassiveHelper
    }
}
