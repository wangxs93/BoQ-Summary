using BoQCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoQCore;

namespace Configuration
{
    public class GeneralConfig
    {
        public static string Name = "General";
        //public GeneralConfig(Bridge curBridge)
        public GZX BridgeList { get; set; }
        public DMX Dmx { get; set; }
        public SQX Sjx { get; set; }
        readonly public DataTable Record;

        public GeneralConfig()
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


        public void Run()
        {
            Anouncement();
            // 循环读取桥涵信息表
            for (int i = 0; i < BridgeList.BRList.Count; i++)
            {
                Bridge curBridge = BridgeList.BRList[i];

                GenSubStructure(ref curBridge);

                GenSupStructure(ref curBridge);

                Auxiliary(ref curBridge);
            }

        }


        public virtual void Anouncement()
        {
            Console.WriteLine("\nThis is General Configuration.");
        }

        internal virtual void GenSubStructure( ref Bridge curBridge)
        {
            for (int i = 0; i < curBridge.SpanList.Count-1; i++)
            {
                // test
                double a = curBridge.SpanList.GetRange(0, i + 1).Sum();
                double pk0 = curBridge.ZH - 0.5 * curBridge.Length +a ;
                double h0=Sjx.GetBG(pk0) - Dmx.GetBG(pk0);
                Console.WriteLine(pk0);
            }
        }






        internal virtual void GenSupStructure( ref Bridge curBridge)
        {
            for (int i = 0; i < curBridge.SpanList.Count; i++)
            {
                Globals.BeamType curBt = GetBeamType(curBridge.SpanList[i], curBridge.Type);

            }
        }

        internal virtual void Auxiliary( ref Bridge curBridge)
        {
          ;
        }



        public virtual Globals.BeamType GetBeamType(double span,string typeDescription)
        {
            if (span==10)
            {
                return Globals.BeamType.F10;
            }
            else if (span==15)
            {
                return Globals.BeamType.F15;

            }
            else if (span==25)
            {
                return Globals.BeamType.T25;
            }
            else if (span == 35)
            {
                return Globals.BeamType.T35;
            }
            else if (span == 50)
            {
                return Globals.BeamType.B50;
            }
            else if (span == 60)
            {
                return Globals.BeamType.B60;
            }
            else
            {
                throw new Exception("跨径无匹配上部类型.");
            }
        }

    }
}
