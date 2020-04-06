using System;
using System.Collections.Generic;
using System.Text;

namespace StructureAlgorithm.MathConvert
{
    public class MethodDemo
    {
        public void doubleToIntTest()
        {
            double timeStampDouble = 1343403554609.3293;

           // Int64 timeStampInt64 = Convert.ToInt64(timeStampDouble);//1343403554609

            //An unhandled exception of type 'System.OverflowException' occurred in mscorlib.dll
            //Additional information: Value was either too large or too small for an Int32.
            //Int32 timeStampInt32 = Convert.ToInt32(timeStampDouble);

            int timeStampInt = (int)timeStampDouble;                //-2147483648

            double doubleFllor = Math.Floor(timeStampDouble);       //1343403554609.0
            double doubleCeiling = Math.Ceiling(timeStampDouble);   //1343403554610.0
            double doubleRound = Math.Round(timeStampDouble);       //1343403554609.0

            Int64 fllorInt64 = Convert.ToInt64(doubleFllor);        //1343403554609
            Int64 ceilingInt64 = Convert.ToInt64(doubleCeiling);    //1343403554610
            Int64 roundInt64 = Convert.ToInt64(doubleRound);        //1343403554609
        }
    }
}
