using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoQCore;

namespace Configuration
{
    public class E763Config: BasicConfig
    {
        public override void Anouncement()
        {
            Console.Write("\nThis is E763 Configuration~");
        }

        public override void GetCapBeam(out CapBeam ret, double bridgeWidth)
        {
            throw new NotImplementedException();
        }

        public override void GetPier(out Pier curPier, double Lp)
        {
            throw new NotImplementedException();
        }

        public override void GetPile(out Pile ret, double Lz)
        {
            throw new NotImplementedException();
        }

        public override void GetPileCap(out PileCap ret)
        {
            throw new NotImplementedException();
        }

        public override void GetSupStr(out SupStructure curSupStr, double L, string descreption)
        {
            throw new NotImplementedException();
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
