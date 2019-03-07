using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQCore
{
    public class SolidCirclePier : Pier
    {
        public double D;

        public SolidCirclePier()
        {
            D = 0;
        }

        public SolidCirclePier(double d,double l,double rhoRebar, double rhoPreRebar)
            :base(l,rhoRebar,rhoPreRebar)
        {            
            D = d;
            DimLong = d;
            Vc = Math.PI * d * d * l * 0.25;
        }

        

        public override void WriteData(ref DataTable dt, string br, int times = 1)
        {            
            for (int i = 0; i < times; i++)
            {
                Globals.Write(ref dt, br, "柱式墩", string.Format("{0:D2}", i + 1), string.Format("D{0:D3}", (int)(D * 100)), "混凝土", "", Vc, L, 1, 1);
                Globals.Write(ref dt, br, "柱式墩", string.Format("{0:D2}", i + 1), string.Format("D{0:D3}", (int)(D * 100)), "钢筋", "", Vc * RhoRebar, L, 1, 1);
                if (RhoPreRebar!=0)
                {
                    Globals.Write(ref dt, br, "柱式墩", string.Format("{0:D2}", i + 1), string.Format("D{0:D3}", (int)(D * 100)), "预应力钢束", "", Vc * RhoPreRebar, L, 1, 1);
                }                
            }
        }
    }
}
