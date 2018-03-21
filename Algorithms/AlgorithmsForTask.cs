using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Algorithms
{
    public static class AlgorithmsForTask
    {
        private static long _time;

        private static Stopwatch _watch = new Stopwatch();

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
                if (numberArrayForValidate[i] < 0 || numberArrayForValidate[i] < int.MinValue || numberArrayForValidate[i] > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException($"Argument`s with index {i} is not valid");
                }
            }
        }

        #endregion BinaryInsert

        #region FindBiggerNumber

        /// <summary>
        /// Method for search next bigger number
        /// </summary>
        /// <param name="inputNumber">input number</param>
        /// <param name="_time">variabe for write time run method</param>
        /// <returns>output number</returns>
        public static int FindNextBiggerNumber(int inputNumber, out long _time)
        {
            ValidateNumberTypeInt(inputNumber);

            _watch.Reset();

            _watch.Start();

            List<int> listForRezalt = new List<int>();

            var number = inputNumber;

            while (number != 0)
            {
                listForRezalt.Insert(0, number % 10);

                number /= 10;
            }

            var inputArray = listForRezalt.ToArray();

            SortForFindNextBiggerNumber(ref inputArray);

            var rezaltString = string.Empty;

            for (int i = 0; i < inputArray.Length; i++)
            {
                rezaltString = $"{rezaltString}{inputArray[i]}";
            }

            var rezalt = Convert.ToInt32(rezaltString);

            if(rezalt <= inputNumber)
            {
                _watch.Stop();

                _time = _watch.ElapsedMilliseconds;

                return -1;
            }

            _watch.Stop();

            _time = _watch.ElapsedMilliseconds;

            return rezalt;
        }

        /// <summary>
        /// Method for search next bigger number with tuple
        /// </summary>
        /// <param name="inputNumber">input number</param>
        /// <param name="_time">variabe for write time run method</param>
        /// <returns>output number</returns>
        public static Tuple<int, long> FindNextBiggerNumberTuple(int inputNumber)
        {
            ValidateNumberTypeInt(inputNumber);

            _watch.Reset();

            _watch.Start();

            List<int> listForRezalt = new List<int>();

            var number = inputNumber;

            while (number != 0)
            {
                listForRezalt.Insert(0, number % 10);

                number /= 10;
            }

            var inputArray = listForRezalt.ToArray();

            SortForFindNextBiggerNumber(ref inputArray);

            var rezaltString = string.Empty;

            for (int i = 0; i < inputArray.Length; i++)
            {
                rezaltString = $"{rezaltString}{inputArray[i]}";
            }

            var rezalt = Convert.ToInt32(rezaltString);

            var tuple = new Tuple<int, long>(rezalt, _time);

            if (rezalt <= inputNumber)
            {
                _watch.Stop();

                _time = _watch.ElapsedMilliseconds;

                return new Tuple<int, long>(-1, _time);
            }

            _watch.Stop();

            _time = _watch.ElapsedMilliseconds;

            return new Tuple<int, long>(rezalt, _time);
        }

        /// <summary>
        /// Method for sort array for find next bigger number
        /// </summary>
        /// <param name="inputArray">input array</param>
        private static void SortForFindNextBiggerNumber(ref int[] inputArray)
        {
            for(int i = inputArray.Length-1; i >= 1; i--)
            {
                if(inputArray[i] > inputArray[i - 1])
                {
                    Swap(ref inputArray[i - 1], ref inputArray[i]);

                    if((inputArray.Length - 1) - (i - 1) > 1)
                    {
                        var arrayHelper = inputArray.Skip(i).ToArray();

                        SortArrayAscend(ref arrayHelper);

                        Array.Copy(arrayHelper, 0, inputArray, i, arrayHelper.Length);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Helper method for sort array ascend
        /// </summary>
        /// <param name="inputArray"></param>
        private static void SortArrayAscend(ref int[] inputArray)
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
    
        #endregion FindBiggerNumber
    }
}