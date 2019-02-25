using BoQCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                GenStrList(ref curBridge);

                Auxiliary(ref curBridge);
            }

        }


        public virtual void Anouncement()
        {
            Console.WriteLine("\nThis is General Configuration.");
        }

        internal virtual void GenStrList( ref Bridge curBridge)
        {
            for (int i = 0; i < curBridge.SpanList.Count-1; i++)
            {
                // 当前设计墩高
                double a = curBridge.SpanList.GetRange(0, i + 1).Sum();
                double pk0 = curBridge.ZH - 0.5 * curBridge.Length +a ;
                double h0=Sjx.GetBG(pk0) - Dmx.GetBG(pk0);
                // 当前桥宽
                double w0 = GetBridgeWidth(pk0);
                // 获取结构类型
                GetBeam(out SupStructure curBeam, curBridge.SpanList[i], curBridge.Type);                
                GetPier(out Pier curPier, curBeam, h0);
                GetCapBeam(out CapBeam curCB, curBeam,curPier,w0);

                Console.WriteLine(pk0);
            }
        }


        /// <summary>
        /// 配置盖梁
        /// </summary>
        /// <param name="curCB">盖梁类</param>
        /// <param name="curBeam">当前主梁</param>
        /// <param name="curPier">当前桥墩</param>
        /// <param name="w0">当前桥宽</param>
        private void GetCapBeam(out CapBeam curCB, SupStructure curBeam, Pier curPier, double w0)
        {
            double l = w0;
            double dl, dv;
            if (curPier.GetType()==typeof(SolidCirclePier))
            {
                dl = 1.6;
                dv = 1.7;
            }
            else
            {
                dl = curPier.DimLong + 0.4;
                if (curBeam.curBeamType == Globals.BeamType.T25)
                {
                    dv = 2.0;
                }
                else
                {
                    dv = 2.5;
                }
            }

            curCB = new CapBeam(l, dl, dv, 180,0);
        }



        /// <summary>
        /// 配置桥墩
        /// </summary>
        /// <param name="curPier">桥墩类</param>
        /// <param name="curBt">当前主梁</param>
        /// <param name="hh">设计高差</param>
        private void GetPier(out Pier curPier, SupStructure curBt, double hh)
        {
            double h0 = hh - 2.0;
            curPier=null;

            if (h0<0)
            {
                curPier = null;
            }
            else if(h0<=10)
            {
                curPier = new SolidCirclePier(1.0,h0,180,0);

            }
            else if (h0 <= 25)
            {
                curPier = new SolidCirclePier(1.0, h0, 180, 0);

            }
            else if (h0 <= 40)
            {
                curPier = new SolidCirclePier(1.0, h0, 180, 0);

            }
            else
            {
                curPier = new SolidCirclePier(1.0, h0, 180, 0);

            }            


            
        }

        //internal virtual void GenSupStructure( ref Bridge curBridge)
        //{
        //    for (int i = 0; i < curBridge.SpanList.Count; i++)
        //    {
        //        GetBeam(out SupStructure obj,curBridge.SpanList[i], curBridge.Type);

        //    }
        //}

        internal virtual void Auxiliary( ref Bridge curBridge)
        {
          ;
        }



        


        public void GetBeam(out SupStructure obj,double span,string typeDescription)
        {
            if (span==10)
            {
                obj = new TBeam(1.57, 0.44, 0.08, 25, 170, 65);
                
            }
            else if (span==15)
            {
                obj = new TBeam(1.57, 0.44, 0.08, 25, 170, 65);
                

            }
            else if (span==25)
            {
                obj = new TBeam(1.57,0.44,0.08,25,170,65);
                
            }
            else if (span == 35)
            {
                obj = new TBeam(1.57, 0.44, 0.08, 25, 170, 65);
                
            }
            else if (span == 50)
            {
                obj = new TBeam(1.57, 0.44, 0.08, 25, 170, 65);
                
            }
            else if (span == 60)
            {
                obj = new TBeam(1.57, 0.44, 0.08, 25, 170, 65);
                
            }
            else
            {
                throw new Exception("跨径无匹配上部类型.");
            }
        }
        private double GetBridgeWidth(double pk0)
        {
            return 17.15;

        }
    }
}
