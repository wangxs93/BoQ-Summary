using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQCore
{
    class SolidRecPier
    {
        public double LongDim
        {
            set; get;
        }
        public double TransDim
        {
            set; get;
        }
        public double Height
        {
            set; get;
        }

        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="dt"></param>
        public void WriteData(ref DataTable dt)
        {

        }
    }
}
