using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQCore
{
    public class BoxBeam : SupStructure
    {
        public double LowerLength;
        /// <summary>
        /// 箱梁构造函数
        /// </summary>
        /// <param name="h">梁高</param>
        /// <param name="ac">断面面积</param>
        /// <param name="l">梁长</param>
        /// <param name="rhoRebar">含筋率</param>
        /// <param name="rhoPreRebar">含预应力筋率</param>
        public BoxBeam(double h,double ac,double lc, double l, double rhoRebar, double rhoPreRebar) :
            base(h, l, ac, rhoRebar, rhoPreRebar)
        {
            LowerLength = lc;
        }
        public override void WriteData(ref DataTable dt, string br, int times = 1)
        {
            Globals.Write(ref dt, br, "箱梁", "", "", "", "", 1, 1, 1, 1);
        }
    }
}
