using BoQCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    public class GeneralConfig:BasicConfig
    {

        public GeneralConfig()
        {
            Name = "General";
        }

        

        public override void Run()
        {
            Anouncement();
            // 循环读取桥涵信息表
            for (int i = 0; i < BridgeList.BRList.Count; i++)
            {
                curBridge = BridgeList.BRList[i];

                GenStrList(ref curBridge);

                Auxiliary(ref curBridge);
            }

        }


        public override void Anouncement()
        {
            Console.WriteLine("\nThis is General Configuration.");
        }

        private void GenStrList( ref Bridge curBridge)
        {
            Console.WriteLine(curBridge.Name);

            double h0, pk0, w0;
            
            w0 = GetBridgeWidth(curBridge.ZH);

            for (int i = 0; i < curBridge.SpanList.Count+1; i++)
            {
                // 当前设计墩高
                double a = curBridge.SpanList.GetRange(0, i).Sum();
                pk0 = curBridge.ZH - 0.5 * curBridge.Length + a;
                h0=Sjx.GetBG(pk0) - Dmx.GetBG(pk0);





                // 获取结构类型
                if (i==0)
                {                    
                    GetSupStr(out curSupStr, curBridge.SpanList[i], curBridge.Type);
                    curSupStr.WriteData(ref Record, curBridge.Name);

                    GetAbutment(out Abutment curAbut,h0);
                }
                else if (i == curBridge.SpanList.Count)
                {                    
                    GetSupStr(out curSupStr, curBridge.SpanList[i - 1], curBridge.Type);
                    GetAbutment(out Abutment curAbut, h0);
                }
                else
                {
                    GetSupStr(out curSupStr, curBridge.SpanList[i-1], curBridge.Type);
                    curSupStr.WriteData(ref Record, curBridge.Name);

                    GetPier(out curPier, h0);
                    GetCapBeam(out CapBeam curCB, w0);
                    GetPileCap(out PileCap curPC);
                    GetPile(out Pile curPile, curBridge.ZH);
                }

                
            }
        }



        public override void GetPile(out Pile curPile,  double cZH)
        {
            double ZL = GetZLength(cZH);



            curPile = null;
            
        }



        public override void GetPileCap(out PileCap curPC)
        {
            curPC=new PileCap();
        }


        /// <summary>
        /// 配置盖梁
        /// </summary>
        /// <param name="curCB">盖梁类</param>
        /// <param name="curBeam">当前主梁</param>
        /// <param name="curPier">当前桥墩</param>
        /// <param name="w0">当前桥宽</param>
        public override void GetCapBeam(out CapBeam curCB,  double w0)
        {
            double l = w0;
            double dl, dv;
            if (curPier==null||curPier.GetType()==typeof(SolidCirclePier))
            {
                dl = 1.6;
                dv = 1.7;
            }
            else
            {
                dl = curPier.DimLong + 0.4;
                if (curSupStr.curBeamType == Globals.BeamType.T25)
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
        public override void GetPier(out Pier curPier,  double hh)
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

        /// <summary>
        ///  配置主梁
        /// </summary>
        /// <param name="obj">主梁输出</param>
        /// <param name="span">跨径</param>
        /// <param name="typeDescription">文件描述</param>
        public override void GetSupStr(out SupStructure obj,double span,string typeDescription)
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


        public override void GetAbutment(out Abutment curAbut,double h0)
        {
            curAbut = new Abutment();
        }

        private double GetBridgeWidth(double pk0)
        {
            return 17.15;

        }
        private double GetZLength(double cZH)
        {
            return 30.0;
        }

        internal virtual void Auxiliary(ref Bridge curBridge)
        {
            ;
        }
    }
}
