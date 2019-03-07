using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQCore
{
    public class SlabBeam : SupStructure
    {

        public SlabBeam(double h, double l, double ac, double rho1, double rho2) : base(h, l, ac, rho1, rho2)
        {
        }

        public override void WriteData(ref DataTable dt, string br, int times = 1)
        {
            Globals.Write(ref dt, br, "框架梁", "", "", "", "", 1, 1, 1, 1);
        }
    }
}
