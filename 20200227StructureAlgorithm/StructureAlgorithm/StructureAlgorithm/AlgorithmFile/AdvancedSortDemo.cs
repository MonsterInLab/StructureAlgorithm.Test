using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StructureAlgorithm.AlgorithmFile
{
    public static class AdvancedSortDemo
    {

        public static void Show()
        {
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
               // Thread.Sleep(100);
                array[i] = new Random(i + 100 + DateTime.Now.Millisecond).Next(0, 100);
            }

            Console.WriteLine("before sort");
            array.Show();
            Console.WriteLine("start sorting");

            array.HeanpSort();


        }

        #region 希尔排序


        private static void ShellSort(this int[] arr)
        {
            int inner = 0;
            int temp = 0;
            int increment = 0;

        }
        #endregion

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


        #region 堆排序

        public static void HeanpSort(this int[] arr)
        {
            //1.构建大顶堆
            for (int i = arr.Length / 2 - 1 ; i >= 0; i--)
            {
                BuildHeap(arr, i, arr.Length);
            }
            Console.WriteLine("堆构建完成");

            //2.交换堆顶元素与末尾元素
            for (int j = arr.Length-1; j <0; j--)
            {
                Swap(arr, 0, j);
                BuildHeap(arr, 0, j);
            }


        }


        private static void BuildHeap(int[] arr,int i,int length)
        {
            int temp = arr[i];// 枝干节点
            //i = 4

            //k = 9
            for (int k = i*2+1; k < length; k=k*2+1)
            {
                //arr[k+1]子节点  arr[k+1] 子节点
                if(k+1< length && arr[k] < arr[k + 1])
                { 
                    //两个子节点对比， 要最大的k 就把k++
                    k++;
                }
                if (arr[k] > temp)  //最大如果大于枝干节点
                {
                    arr[i] = arr[k];
                    i = k; //把i 换成 k 下面再替换， 等于交换值
                }
                else
                {
                    break;
                }
                //继续循环就以刚才节点位置感节点去比较其他子节点，持续交换下去
            }
            arr[i] = temp;
            arr.Show();
        }


        private static void Swap(int[] arr, int v, int j)
        {

        }


        #endregion

        private static void Show(this int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}
