using BoQCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoQCore;
using BoQCore.Models;

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
                // 当前设计墩高
                double a = curBridge.SpanList.GetRange(0, i + 1).Sum();
                double pk0 = curBridge.ZH - 0.5 * curBridge.Length +a ;
                double h0=Sjx.GetBG(pk0) - Dmx.GetBG(pk0);
                // 对应上部结构
                Globals.BeamType curBt = GetBeamType(out BaseModel obj, curBridge.SpanList[i], curBridge.Type);
                // 对应下部结构
                BaseModel curPier=GetPierType(curBt, h0);

                Console.WriteLine(pk0);
            }
        }

        private BaseModel GetPierType(Globals.BeamType curBt, double h0)
        {
            BaseModel obj=null;
            if (h0<0)
            {
                obj = null;
            }
            else if(h0<=10)
            {
                obj = new SolidCirclePier();

            }
            else if (h0 <= 25)
            {

            }
            else if (h0 <= 40)
            {

            }
            else
            {

            }
            return obj;


            
        }

        internal virtual void GenSupStructure( ref Bridge curBridge)
        {
            for (int i = 0; i < curBridge.SpanList.Count; i++)
            {
                Globals.BeamType curBt = GetBeamType(out BaseModel obj,curBridge.SpanList[i], curBridge.Type);

            }
        }

        internal virtual void Auxiliary( ref Bridge curBridge)
        {
          ;
        }



        


        public virtual Globals.BeamType GetBeamType(out BaseModel obj,double span,string typeDescription)
        {
            if (span==10)
            {
                obj = new TBeam(1.57, 0.44, 0.08, 25, 170, 65);
                return Globals.BeamType.F10;
            }
            else if (span==15)
            {
                obj = new TBeam(1.57, 0.44, 0.08, 25, 170, 65);
                return Globals.BeamType.F15;

            }
            else if (span==25)
            {
                obj = new TBeam(1.57,0.44,0.08,25,170,65);
                return Globals.BeamType.T25;
            }
            else if (span == 35)
            {
                obj = new TBeam(1.57, 0.44, 0.08, 25, 170, 65);
                return Globals.BeamType.T35;
            }
            else if (span == 50)
            {
                obj = new TBeam(1.57, 0.44, 0.08, 25, 170, 65);
                return Globals.BeamType.B50;
            }
            else if (span == 60)
            {
                obj = new TBeam(1.57, 0.44, 0.08, 25, 170, 65);
                return Globals.BeamType.B60;
            }
            else
            {
                throw new Exception("跨径无匹配上部类型.");
            }
        }

    }
}
