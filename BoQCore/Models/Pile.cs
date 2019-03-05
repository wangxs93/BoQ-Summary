using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoQCore
{
    public class Pile: BasicModel
    {
        public double Ld
        {
            get;set;
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="lz">桩长</param>
        /// <param name="ld">桩径</param>
        /// <param name="r">含筋率</param>
        public Pile(double lz,double ld,double r)
        {
            L = lz;
            Ld = ld;
            RhoRebar = r;
            Vc = ld * ld * 0.25 * Math.PI * lz;
        }


        public override void WriteData(ref DataTable dt, string br,int times=1)
        {            
            for (int i = 0; i < times; i++)
            {
                Globals.Write(ref dt, br, "桩基", string.Format("{0:D2}", i + 1), string.Format("D{0:D2}", (int)(Ld * 100)), "混凝土", "", Vc, L, 1, 1);
                Globals.Write(ref dt, br, "桩基", string.Format("{0:D2}", i + 1), string.Format("D{0:D2}", (int)(Ld * 100)), "钢筋", "", Vc * RhoRebar, L, 1, 1);
            }
        }
    }
}
