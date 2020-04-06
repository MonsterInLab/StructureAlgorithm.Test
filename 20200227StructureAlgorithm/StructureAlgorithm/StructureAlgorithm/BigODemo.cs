using System;
using System.Collections.Generic;
using System.Text;

namespace StructureAlgorithm
{
    public class BigODemo
    {

        // 单位时间  一行代码  执行得代码行数

        /// <summary>
        /// 分析时间
        /// 2n+1
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        private static long Method1(int iNumber)
        {
            long lResult = 0;
            for(int i=0; i< iNumber; i++)
            {
                lResult += i;
            }
            return lResult;
        }

        /// <summary>
        /// n^2  
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        private static long Method2(int iNumber)
        {
            long lResult = 0;
            for (int i = 0; i < iNumber; i++)
            {
                for (int j = 0; j < iNumber; j++)
                {

                    lResult += i;
                }
            }
            return lResult;
        }

        private static int Method3(int iNumber)
        {
            int iResult = 1;
            while(iResult <= iNumber)
            {
                iResult = iResult * 2;
            }
            return iResult;

            // iResult 1  2  4  8  16  32
            // 2^x = n,  x = Log2N
        }
        private static int Method4(int iNumber)
        {
            int lResult = 0;
            int iResult = 1;
            while (iResult <= iNumber)
            {

                iResult = iResult * 2;
            }
            return iResult;

            // iResult 1  2  4  8  16  32
            // 2^x = n,  x = Log2N
        }

        /// <summary>
        /// O(1)
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        private static long Method5(int iNumber)
        {
            long lResult = 0;
            return iNumber * iNumber + iNumber;
        }



    }
}
