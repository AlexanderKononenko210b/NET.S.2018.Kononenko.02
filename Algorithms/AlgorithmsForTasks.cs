using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Algorithms
{
    public static class AlgorithmsForTasks
    {
        const int BASE_DECIMAL = 10;

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
            if (degree < 0 || accuracy < 0)
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

            var leftValue = number / degree;

            var rightValue = (1.0 / degree) * ((degree - 1) * leftValue + number / Math.Pow(leftValue, degree - 1));

            while (Math.Abs(rightValue - leftValue) > accuracy)
            {
                leftValue = rightValue;
                rightValue = (1.0 / degree) * ((degree - 1) * leftValue + number / Math.Pow(leftValue, degree - 1));
            }

            return rightValue;
        }

        #endregion RootNewton

        #region BinaryInsert


        /// <summary>
        /// Method for binary insert interval bites
        /// </summary>
        /// <param name="numberDestination"> distination number</param>
        /// <param name="numberSource"> source number</param>
        /// <param name="indexStartInsert"> start index inserts interval</param>
        /// <param name="indexEndInsert">end index inserts interval</param>
        /// <returns>rezalt number after insert</returns>
        public static int BinaryInsertNumber(int numberDestination, int numberSource, int indexStartInsert, int indexEndInsert)
        {
            ValidateNumberTypeInt(numberDestination, numberSource, indexStartInsert, indexEndInsert);

            if (indexEndInsert < indexStartInsert)
            {
                throw new ArgumentOutOfRangeException($"Index start insert must be less or equals index end insert");
            }

            int changeOneToZeroDestination = numberDestination;

            for (int i = indexStartInsert; i <= indexEndInsert; i++)
            {
                if ((numberDestination & (1 << i)) != (numberSource & (1 << (i - indexStartInsert))))
                {
                    if ((numberSource & (1 << (i - indexStartInsert))) == 0)
                    {
                        changeOneToZeroDestination ^= (1 << i);
                    }
                    else
                    {
                        changeOneToZeroDestination |= (1 << i);
                    }
                }
            }

            return changeOneToZeroDestination;
        }

        /// <summary>
        /// Method for validate number type int
        /// </summary>
        /// <param name="numberArrayForValidate">array params type int</param>
        public static void ValidateNumberTypeInt(params int[] numberArrayForValidate)
        {
            for (int i = 0; i < numberArrayForValidate.Length; i++)
            {
                if (numberArrayForValidate[i] < 0)
                {
                    throw new ArgumentOutOfRangeException($"Argument`s with index {i} is not valid");
                }
            }
        }

        #endregion BinaryInsert

        #region FindNextBiggerNumber

        /// <summary>
        /// Method for search next bigger number with out parametr
        /// </summary>
        /// <param name="inputNumber">input number</param>
        /// <param name="time">parameter for write time run method</param>
        /// <returns>output number</returns>
        public static int FindNextBiggerNumberReference(int inputNumber, out long time)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            ValidateNumberTypeInt(inputNumber);

            var result = FindNextBiggerNumber(inputNumber);

            if (result <= inputNumber)
            {
                stopwatch.Stop();

                time = stopwatch.ElapsedMilliseconds;

                return -1;
            }

            stopwatch.Stop();

            time = stopwatch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Method for search next bigger number with tuple
        /// </summary>
        /// <param name="inputNumber">input number</param>
        /// <returns>tuple where first parameter - result calc, second parameter - time calc</returns>
        public static (int, long) FindNextBiggerNumberTuple(int inputNumber)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            var result = FindNextBiggerNumber(inputNumber);

            if (result <= inputNumber)
            {
                stopwatch.Stop();

                return (-1, stopwatch.ElapsedMilliseconds);
            }

            stopwatch.Stop();

            return (result, stopwatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Method for find next bigger number
        /// </summary>
        /// <param name="inputNumber">input number</param>
        /// <returns>output number after search</returns>
        public static int FindNextBiggerNumber(int inputNumber)
        {
            var inputArray = GetArrayFromNumber(inputNumber);

            SortForFindNextBiggerNumber(inputArray);

            return GetNumberFromArray(inputArray);
        }

        /// <summary>
        /// Method for get array number from number type int
        /// </summary>
        /// <param name="inputNumber">input number</param>
        /// <returns>result array</returns>
        private static int[] GetArrayFromNumber(int inputNumber)
        {
            List<int> listForRezalt = new List<int>();

            while (inputNumber != 0)
            {
                listForRezalt.Insert(0, inputNumber % 10);

                inputNumber /= 10;
            }

            return listForRezalt.ToArray();
        }

        /// <summary>
        /// Method for get number from array type int
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <returns>result number</returns>
        private static int GetNumberFromArray(int[] inputArray)
        {
            var result = 0;

            var degree = 1;

            for(int i = inputArray.Length-1; i >= 0; i--)
            {
                result += inputArray[i] * degree;

                degree *= BASE_DECIMAL;
            }

            return result;
        }

        /// <summary>
        /// Method for sort array for find next bigger number
        /// </summary>
        /// <param name="inputArray">input array</param>
        private static void SortForFindNextBiggerNumber(int[] inputArray)
        {
            for(int i = inputArray.Length-1; i >= 1; i--)
            {
                if(inputArray[i] > inputArray[i - 1])
                {
                    Swap(ref inputArray[i - 1], ref inputArray[i]);

                    if((inputArray.Length - 1) - (i - 1) > 1)
                    {
                        var arrayHelper = inputArray.Skip(i).ToArray();

                        SortArrayAscend(arrayHelper);

                        Array.Copy(arrayHelper, 0, inputArray, i, arrayHelper.Length);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Helper method for sort array ascend
        /// </summary>
        /// <param name="inputArray">helper array consist element after replace number</param>
        private static void SortArrayAscend(int[] inputArray)
        {
            int depthSort = inputArray.Length;

            while (depthSort != 1)
            {
                for (int i = 0; i < depthSort-1; ++i)
                {
                    if (inputArray[i] > inputArray[i+1])
                    {
                        Swap(ref inputArray[i], ref inputArray[i + 1]);
                    }
                }

                depthSort--;
            }
        }

        /// <summary>
        /// Helper method for replacing values ​​in an array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftElement">left element</param>
        /// <param name="rightElement">right element</param>
        private static void Swap<T>(ref T leftElement, ref T rightElement)
        {
            var helper = leftElement;
            leftElement = rightElement;
            rightElement = helper;
        }
    
        #endregion FindNextBiggerNumber
    }
}