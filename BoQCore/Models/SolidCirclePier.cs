using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQCore
{
    public class SolidCirclePier : SubStructure
    {
        public double D;

        public SolidCirclePier()
        {
        }

        public SolidCirclePier(double l,double rhoRebar, double rhoPreRebar)
        {
            L = l;
            RhoRebar = rhoRebar;
            RhoPreRebar = rhoPreRebar;
        }

        public SolidCirclePier(double d,double l, double rhorebar, double rhoprerebar) 
            : base(l,0.25*Math.PI*d*d*l, rhorebar, rhoprerebar)
        {
            D = d;
        }
        

        public override void WriteData(ref DataTable dt, string br, int xmh1, int xmh2)
        {
            throw new NotImplementedException();
        }
    }
}
