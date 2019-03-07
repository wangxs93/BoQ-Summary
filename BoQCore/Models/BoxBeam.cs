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
        /// <summary>
        /// 箱梁构造函数
        /// </summary>
        /// <param name="h">梁高</param>
        /// <param name="ac">断面面积</param>
        /// <param name="l">梁长</param>
        /// <param name="rhoRebar">含筋率</param>
        /// <param name="rhoPreRebar">含预应力筋率</param>
        public BoxBeam(double h,double ac, double l, double rhoRebar, double rhoPreRebar) :
            base(h, l, ac, rhoRebar, rhoPreRebar)
        {            
            if (l == 50)
            {
                curBeamType = Globals.BeamType.B50;
            }
            else if (l == 60)
            {
                curBeamType = Globals.BeamType.B60;
            }
            else
            {
                curBeamType = Globals.BeamType.None;
            }
        }
        public override void WriteData(ref DataTable dt, string br, int times = 1)
        {
            for (int i = 0; i < times; i++)
            {
                Globals.Write(ref dt, br, "箱梁", string.Format("{0:D2}", i + 1), curBeamType.ToString(), "混凝土", "", Vc, 1, 1, 1);
                Globals.Write(ref dt, br, "箱梁", string.Format("{0:D2}", i + 1), curBeamType.ToString(), "钢筋", "", Vc * RhoRebar, 1, 1, 1);
                Globals.Write(ref dt, br, "箱梁", string.Format("{0:D2}", i + 1), curBeamType.ToString(), "预应力钢束", "", Vc * RhoPreRebar, 1, 1, 1);
            }
           
        }
    }
}
