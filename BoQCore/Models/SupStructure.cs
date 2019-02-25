using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQCore
{
    public class SupStructure : BasicModel
    {
        public Globals.BeamType curBeamType;

        public double H,Ac;
        

        public SupStructure()
        {            
            H = 0;
            Ac = 0;
        }
        public SupStructure(double h,double l,double ac,double rho1,double rho2)
            :base(l,rho1,rho2)
        {
            H = h;            
            Ac = ac;
            Vc = ac * l;
        }

        public override void WriteData(ref DataTable dt, string br, int xmh1, int xmh2)
        {
            throw new NotImplementedException();
        }
    }
}
