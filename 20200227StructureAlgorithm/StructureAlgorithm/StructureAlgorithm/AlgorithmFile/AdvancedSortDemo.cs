using System;
using System.Collections.Generic;
using System.Text;

namespace StructureAlgorithm.AlgorithmFile
{
    public static class AdvancedSortDemo
    {
        private static void ShellSort(this int[] arr)
        {
            int inner = 0;
            int temp = 0;
            int increment = 0;

        }

        #region 分治排序

        public static void MergeSort(this int[] arr, int middle, int right)
        {
            int[] temp = new int[arr.Length];
            PartSort(arr, 0, arr.Length - 1, temp);
        }

        private static void PartSort(int[] arr, int left, int right, int[] temp)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                PartSort(arr, left, middle, temp);   //左边分治
                PartSort(arr, middle + 1, right, temp);  //右边分治
                MergeSort(arr,left, middle, right, temp); //合并排序

            }
        }

        private static void MergeSort(int[] arr,int left, int mid, int right, int[] temp)
        {
            int i = left;
            int j  = mid + 1;
            int t = 0;

            while(i<= mid && j <= right)
            {
                if (arr[i] < arr[j])
                {
                    temp[t] = arr[i];
                    t++;
                    i++;
                }
                else
                {
                    temp[t] = arr[j];
                    t++;
                    j++;
                }
            }

            while (i <= mid)
            {
                temp[t] = arr[i];  // 将左边的剩余元素填充进去
                t++;
                i++;
            }
            while(j<= right)
            {
                temp[t] = arr[j];  // 将左边的剩余元素填充进去
                t++;
                j++;
            }

            t = 0;
            while(left < right)
            {
                arr[left] = temp[t];  // 将temp中的元素全部填充进去
                left++;
                t++;
            }



        }


        #endregion
    }
}
