using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQCore.Models
{
    public class SupStructure : BaseModel
    {

        public double H,Ac;
        

        public SupStructure()
        {
        }
        public SupStructure(double h,double l,double ac,double rho1,double rho2):base(l,l*ac,rho1,rho2)
        {
            H = h;            
            Ac = ac;
        }

        public override void WriteData(ref DataTable dt, string br, int xmh1, int xmh2)
        {
            throw new NotImplementedException();
        }
    }
}
