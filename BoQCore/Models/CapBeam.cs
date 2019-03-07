using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQCore
{
    public class CapBeam : BasicModel
    {
        public double DimLong,DimVertical;

        public CapBeam():base()
        {
            DimLong = 0;
            DimVertical = 0;            
        }

        public CapBeam(double l, double dl,double dv, double rhorebar, double rhoprerebar)
            : base(l,rhorebar, rhoprerebar)
        {
            DimLong = dl;
            DimVertical = dv;
            Vc = dl * dv * l;
        }

        public override void WriteData(ref DataTable dt, string br,int times=1)
        {
            Globals.Write(ref dt, br, "盖梁", "1", "", "混凝土", "",Vc, 1, 1,1);
            Globals.Write(ref dt, br, "盖梁", "1", "", "钢筋", "", Vc*RhoRebar, 1, 1, 1);
            if (RhoPreRebar != 0)
            {
                Globals.Write(ref dt, br, "盖梁", "1", "", "预应力钢束", "", Vc * RhoPreRebar, 1, 1, 1);
            }
        }
    }
}
