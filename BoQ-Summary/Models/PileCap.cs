using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQ_Summary.Models
{
    public class PileCap:BaseModel
    {
        public double LongDim
        {
            set;get;
        }
        public double TransDim
        {
            set;get;
        }
        public double Height
        {
            set;get;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public PileCap(double a)
        {

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
