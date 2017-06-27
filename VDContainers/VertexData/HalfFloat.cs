using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDriveFiles.VertexData
{
    class HalfFloat
    {
       public ushort data { get; set; }
        public override string ToString()
        {
            int sign = data >> 15;
            int exponent = ((data & 0x7C00)>>14)-15;
            int mantissa = (data & 0x3FF);
            double result=(Math.Pow(2,exponent))*(1+Math.Pow(2,-10)*mantissa);
            if (data == 0)
                return "0.0";
            if(sign == 1)
            {
                result *= -1;
            }
            return result.ToString();
        }
    }
}
