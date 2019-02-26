using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQCore
{
    public class Abutment : BasicModel
    {
        public Abutment()
        {
        }

        public Abutment(double l, double rhorebar, double rhoprerebar) : base(l, rhorebar, rhoprerebar)
        {
        }

        public override void WriteData(ref DataTable dt, string br, int times = 1)
        {
            Recorder.Write(ref dt, br, "桥台", "", "", "", "", 1, 1, 1,1);
        }
    }
}
