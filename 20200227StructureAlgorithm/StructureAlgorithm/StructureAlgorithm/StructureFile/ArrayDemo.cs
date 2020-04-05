using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StructureAlgorithm.StructureFile
{
    public class ArrayDemo
    {
        public static void Show()
        {
            {
                Console.WriteLine("***************多维Array******************");

                int[,] a = new int[3, 4] {
                                 {0, 1, 2, 3} ,   /*  初始化索引号为 0 的行 */
                                 {4, 5, 6, 7} ,   /*  初始化索引号为 1 的行 */
                                 {8, 9, 10, 11}   /*  初始化索引号为 2 的行 */
                                };
            }

            {
                Console.WriteLine("***************锯齿Array******************");
                int[][] a = new int[2][];
                a[0] = new int[] { 1, 2, 3 };
                a[1] = new int[] { 2 };
            }

            {

                Console.WriteLine("***************ArrayList******************");
                ArrayList arrayList = new ArrayList();
                arrayList.Add("Eleven");
                arrayList.Add("Is");
                arrayList.Add(32);//add增加长度
                //arrayList[4] = 26;//索引复制，不会增加长度
                //删除数据
                //arrayList.RemoveAt(4);
                var value = arrayList[2];
                arrayList.RemoveAt(0);//开辟空间--copy
                arrayList.Remove("Eleven");

                {
                    ArrayList arrayList1 = new ArrayList();
                    arrayList1.Add("Eleven");
                    arrayList1.Add("Is");
                    Console.WriteLine(arrayList1.Capacity);
                    arrayList1.TrimToSize();
                    Console.WriteLine(arrayList1.Capacity);
                }
                {
                    ArrayList arrayList1 = new ArrayList(6);
                    arrayList1.Add("Eleven");
                    arrayList1.Add("Is");
                    arrayList1.Add("Eleven");
                    arrayList1.Add("Is");
                    Console.WriteLine(arrayList1.Capacity);
                    arrayList1.TrimToSize();
                    Console.WriteLine(arrayList1.Capacity);
                }
            }
            {
                //List:也是Array，内存上都是连续摆放;不定长；泛型，保证类型安全，避免装箱拆箱
                //读取快--增删慢
                Console.WriteLine("***************List<T>******************");
                List<int> intList = new List<int>() { 1, 2, 3, 4 };
                intList.Add(123);
                intList.Add(123);
                //intList.Add("123");
                //intList[0] = 123;
                List<string> stringList = new List<string>();
                //stringList[0] = "123";//异常的

                {
                    List<int> intList1 = new List<int>() { 1, 2, 3, 4, 5 };
                    intList1.Add(123);
                    intList1.Add(123);
                    intList1.Add(123);
                    intList1.Add(123);
                    Console.WriteLine(intList1.Capacity);
                    intList1.TrimExcess();
                    Console.WriteLine(intList1.Capacity);
                }
                {
                    List<int> intList1 = new List<int>(3) { 1, 2, 3, 4 };
                    intList1.Add(123);
                    intList1.Add(123);
                    intList1.Add(123);
                    Console.WriteLine(intList1.Capacity);
                    //intList1.TrimToSize();
                    Console.WriteLine(intList1.Capacity);
                }
            }





        }
    }
}
