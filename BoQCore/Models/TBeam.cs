using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQCore.Models
{
    public class TBeam : SupStructure
    {
        public double AcPrecast { get; private set; }
        public double AcInplace { get; private set; }


        public TBeam(double h, double acprecast, double acinplace, double l, double rhoRebar, double rhoPreRebar):
            base(h,l,acprecast+acinplace,rhoRebar,rhoPreRebar)
        {            
            AcPrecast = acprecast;
            AcInplace = acinplace;         
        }


        public override void WriteData(ref DataTable dt, string br, int xmh1, int xmh2)
        {
            throw new NotImplementedException();
        }
    }
}
