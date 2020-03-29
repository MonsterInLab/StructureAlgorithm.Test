using System;
using System.Collections.Generic;
using System.Text;

namespace StructureAlgorithm.AlgorithmFile
{
    public static class BasicSearchDemo
    {
        public static void Show()
        {
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Random(i+DateTime.Now.Millisecond).Next(0, 100);
            }
            array.Show();
            int iResult = -1;
            Console.WriteLine("find your int number");
            while (iResult < 0)
            {
                Console.WriteLine("please input your int number");
                string sValue = Console.ReadLine();
                if (!int.TryParse(sValue,out int iValue))
                {
                    Console.WriteLine("please input right number");
                }
                else
                {
                    array.BubbleSort();
                    var index = BinarySearch(array, iValue);
                    Console.WriteLine(index);
                }
            }

        }

        /// <summary>
        /// 顺序查找
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="iValue"></param>
        /// <returns></returns>
        public static int SquentialSearch(this int[] arr, int iValue)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == iValue)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int Min(this int[] arr)
        {
            int min = arr[0];
            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return min;
        }

        public static int Max(this int[] arr)
        {
            int max = arr[0];
            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i]>max)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        #region 自组织查找
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sValue"></param>
        /// <returns></returns>
        public static bool SquentialSearchWithSelfOrganizing(this int[] arr, int sValue)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] == sValue)
                {
                    if (i > 0)
                    {
                        int temp = arr[i - 1];
                        arr[i - 1] = arr[i];
                        arr[i] = temp;
                        arr.Show();
                    }
                    return true;
                }
            }
            return false;
        }


        public static int SquentialSearchWithSelfOrganizing28(this int[] arr, int sValue)
        {
            for (int i = 0; i < arr.Length -1; i++)
            {
                if (arr[i] == sValue)
                {
                    if(i >( arr.Length * 0.2))
                    {
                        int temp = arr[i - 1];
                        arr[i - 1] = arr[i];
                        arr[i] = temp;
                        arr.Show();
                    }
                }
                return i;
            }
            return -1;
        }

        #endregion


        #region 二叉查找

        /// <summary>
        /// 二叉查找
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int BinarySearch(this int[] arr,int value)
        {
            int upper = arr.Length - 1;
            int lower = 0;
            int middle;
            while(lower <= upper)
            {
                middle = (upper + lower) / 2;
                if(arr[middle] == value)
                {
                    return middle;
                }
                else if(value < arr[middle]){
                    upper = middle - 1;
                }
                else
                {
                    lower = middle + 1;
                }
            }
            return -1;
        }

        public static int BinarySearchRecursion(this int[] arr, int value,int lower,int upper)
        {
            if(lower > upper)
            {
                return -1;
            }
            else
            {
                int middle = (int)(lower + upper) / 2;
                if(value < arr[middle])
                {
                    return arr.BinarySearchRecursion(value,lower,middle-1);
                }
                else if(value == arr[middle])
                {
                    return middle;
                }
                else
                {
                    return arr.BinarySearchRecursion(value, middle +1, upper);
                }
            }
        }


        #endregion
        private static void Show(this int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item.ToString("00") + " ");
            }
            Console.WriteLine();
        }
    }
}
