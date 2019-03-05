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

        public override void GenStrList(ref Bridge curBridge)
        {
            throw new NotImplementedException();
        }

        public override void GetAbutment(out Abutment curAbut, double H0)
        {
            throw new NotImplementedException();
        }

        public override double GetBridgeWidth(double pk)
        {
            throw new NotImplementedException();
        }

        public override void GetCapBeam(out CapBeam ret, double bridgeWidth)
        {
            throw new NotImplementedException();
        }
        

        public override void GetPier(out Pier curPier, ref Globals.BeamType curBT, double Lp)
        {
            throw new NotImplementedException();
        }

        public override void GetPile(out Pile ret, double Lz)
        {
            throw new NotImplementedException();
        }

        public override void GetPileCap(out PileCap ret, ref SupStructure curBT, ref Pier curPier)
        {
            throw new NotImplementedException();
        }

        public override void GetSupStr(out SupStructure curSupStr, double L, double w0, Globals.BeamType curBT)
        {
            throw new NotImplementedException();
        }

        public override int GetTBeamNum(double w0, Globals.BeamType refBT)
        {
            throw new NotImplementedException();
        }

        public override double GetZHTLength(double pk)
        {
            throw new NotImplementedException();
        }

        public override double GetZLength(double pk)
        {
            throw new NotImplementedException();
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
