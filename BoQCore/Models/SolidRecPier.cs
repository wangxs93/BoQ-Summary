using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQCore
{
    public class SolidRecPier:Pier
    {
        public double DimTrans;

        public SolidRecPier():base()
        {
            DimTrans = 0;
        }

        public SolidRecPier(double dt,double dl,double l,double rho1,double rho2)
            :base(l,rho1,rho2)
        {
            DimTrans = dt;
            DimLong = dl;
            Vc = dt * dl * l;
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
