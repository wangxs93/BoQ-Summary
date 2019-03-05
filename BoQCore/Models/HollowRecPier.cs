using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQCore
{

    public class HollowRecPier : Pier
    {
        
        public double AcSolid,AcHollow,HSolid;

        public HollowRecPier() : base()
        {
            AcSolid = 0;
            AcHollow = 0;
            HSolid = 0;
        }
        /// <summary>
        /// 空心墩构造函数
        /// </summary>
        /// <param name="acs">实心断面面积</param>
        /// <param name="ach">空心断面面积</param>
        /// <param name="hs">实心断面总长度</param>
        /// <param name="l">墩高</param>
        /// <param name="rho1">含筋率</param>
        /// <param name="rho2">含预应力筋率</param>
        public HollowRecPier(double acs,double ach,double hs,  double l, double rho1, double rho2)
            : base(l, rho1, rho2)
        {
            AcSolid = acs;
            AcHollow = ach;
            HSolid = hs;            
            Vc = acs * hs+(l-hs)*ach;
        }


        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="dt"></param>
        public override void WriteData(ref DataTable dt, string br, int times = 1)
        {
            for (int i = 0; i < times; i++)
            {
                Globals.Write(ref dt, br, "空心墩", "", "", "", "", 1, 1, 1, 1);
            }
        }
    }
}
