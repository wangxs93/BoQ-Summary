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
            Globals.Write(ref dt, br, "柱式墩", "", "", "", "", 1, 1, 1,1);
        }
    }
}
