using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoQCore
{
    public class SubStructure : BaseModel
    {        

        public SubStructure()
        {
        }

        public SubStructure(double l, double vc, double rhorebar, double rhoprerebar) : base(l, vc, rhorebar, rhoprerebar)
        {
        }

        public override void WriteData(ref DataTable dt, string br, int xmh1, int xmh2)
        {
            throw new NotImplementedException();
        }
    }
}
