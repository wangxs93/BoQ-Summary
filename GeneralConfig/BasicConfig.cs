using BoQCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    public abstract class BasicConfig
    {
        public string Name;
        public DataTable Record;
        public SupStructure curSupStr;
        public Pier curPier;
        public GZX BridgeList;
        public DMX Dmx;
        public SQX Sjx;

        public BasicConfig()
        {
            Record = new DataTable();
            Record.Columns.Add("bridge", typeof(string));
            Record.Columns.Add("class", typeof(string));
            Record.Columns.Add("loc", typeof(string));
            Record.Columns.Add("detial", typeof(string));
            Record.Columns.Add("name", typeof(string));
            Record.Columns.Add("spec", typeof(string));
            Record.Columns.Add("quantity1", typeof(double));
            Record.Columns.Add("quantity2", typeof(double));
            Record.Columns.Add("xmh1", typeof(string));
            Record.Columns.Add("xmh2", typeof(string));

        }

        // =====================================================================
        public abstract void Run();
        public abstract void Anouncement();
        // =====================================================================
        public abstract void GetSupStr(out SupStructure curSupStr, double L, string descreption);
        public abstract void GetPier(out Pier curPier, double Lp);
        public abstract void GetPile(out Pile ret,double Lz);
        public abstract void GetPileCap(out PileCap ret);
        public abstract void GetCapBeam(out CapBeam ret, double bridgeWidth);
        // =====================================================================
    }
}
