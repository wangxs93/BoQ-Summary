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

        public override void GenStrList( ref Bridge curBridge)
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
                    Globals.BeamType curBT = GetBeamType(i, ref curBridge);
                    GetSupStr(out curSupStr, curBridge.SpanList[i],w0,curBT);                    
                    int beamNum = GetTBeamNum(w0,curBT);
                    curSupStr.WriteData(ref Record, curBridge.Name, beamNum);

                    GetAbutment(out Abutment curAbut,h0);
                    curAbut.WriteData(ref Record, curBridge.Name);
                }
                else if (i == curBridge.SpanList.Count)
                {
                    Globals.BeamType curBT = GetBeamType(i-1, ref curBridge);
                    GetSupStr(out curSupStr, curBridge.SpanList[i - 1], w0, curBT);

                    GetAbutment(out Abutment curAbut, h0);
                    curAbut.WriteData(ref Record, curBridge.Name);
                }
                else
                {
                    Globals.BeamType curBT = GetBeamType(i, ref curBridge);
                    GetSupStr(out curSupStr, curBridge.SpanList[i-1],w0,curBT);                    
                    int beamNum = GetTBeamNum(w0, curBT);
                    curSupStr.WriteData(ref Record, curBridge.Name, beamNum);

                    GetPier(out curPier,ref curBT, h0);
                    if (curPier != null)
                    {
                        curPier.WriteData(ref Record, curBridge.Name);

                        GetCapBeam(out CapBeam curCB, w0);
                        curCB.WriteData(ref Record, curBridge.Name);

                        GetPileCap(out PileCap curPC);
                        curPC.WriteData(ref Record, curBridge.Name);


                        GetPile(out Pile curPile, curBridge.ZH);
                        curPile.WriteData(ref Record, curBridge.Name);
                    }
                }                
            }
        }



        public override void GetPile(out Pile curPile,  double cZH)
        {
            double ZL = GetZLength(cZH);



            curPile = new Pile(ZL,1.0,100);
            
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
        public override void GetPier(out Pier curPier, ref Globals.BeamType curBT, double hh)
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
                if (curBT>=Globals.BeamType.B50)
                {
                    curPier = new SolidRecPier(7, 2.2, h0, 160, 0);
                }
                else if (curBT>= Globals.BeamType.T25)
                {
                    curPier = new SolidRecPier(7, 1.8, h0, 160, 0);
                }
                else
                {
                    curPier = null;
                }
               

            }
            else if (h0 <= 40)
            {
                if (curBT >= Globals.BeamType.B50)
                {
                    curPier = new HollowRecPier(19.6, 10.24, 4.5, h0, 180, 0);
                }
                else if (curBT >= Globals.BeamType.T25)
                {
                    curPier = new HollowRecPier(17.5, 10.04, 3.5, h0, 180, 0);
                }
                else
                {
                    curPier = null;
                }

            }
            else
            {
                curPier = new HollowRecPier(21, 10.8, 4.5, h0, 180, 0);
            }            


            
        }

        /// <summary>
        ///  配置主梁
        /// </summary>
        /// <param name="obj">主梁输出</param>
        /// <param name="span">跨径</param>
        /// <param name="w0">桥宽</param>
        /// <param name="curBT">上部类型</param>
        public override void GetSupStr(out SupStructure obj,double span,double w0,Globals.BeamType curBT)
        {
            if (span==10)
            {
                obj = new SlabBeam(1, span, w0, 170, 0);
            }
            else if (span==15)
            {
                obj = new SlabBeam(1, span, w0, 170, 0);
            }
            else if (span==25)
            {
                obj = new TBeam(1.57,0.44,0.08,25,170,65);                
            }
            else if (span == 35)
            {
                if (curBT==Globals.BeamType.B60)
                {
                    double Ac;//涂装长度
                    if (w0 == 13.65)
                    {
                        Ac = 9.66;                        
                    }
                    else if (w0 == 14.65)
                    {
                        Ac = 10.0549;                        
                    }
                    else if (w0 == 17.15)
                    {
                        Ac = 11.4707;                        
                    }
                    else if (w0 == 18.15)
                    {
                        Ac = 11.8;                        
                    }
                    else
                    {
                        Ac = 0;                        
                    }
                    obj = new BoxBeam(3.6, Ac, span, 190, 40);
                }
                else
                {
                    obj = new TBeam(2.1, 0.74, 0.07, 35, 170, 65);
                }
            }
            else if (span == 50)
            {
                double Ac, Lc;//涂装长度
                if (w0 == 13.65)
                {
                    Ac = 9.66;
                    Lc = 18.3;
                }
                else if (w0 == 14.65)
                {
                    Ac = 10.0549;
                    Lc = 19.3;
                }
                else if (w0 == 17.15)
                {
                    Ac = 11.4707;
                    Lc = 22.2;
                }
                else if (w0 == 18.15)
                {
                    Ac = 11.8;
                    Lc = 23.1;
                }
                else
                {
                    Ac = 0;
                    Lc = 0;
                }
                obj = new BoxBeam(3.6, Ac, span, 190, 40);
                
            }
            else if (span == 60)
            {
                double Ac, Lc;//涂装长度
                if (w0 == 13.65)
                {
                    Ac = 9.66;
                    Lc = 18.3;
                }
                else if (w0 == 14.65)
                {
                    Ac = 10.0549;
                    Lc = 19.3;
                }
                else if (w0 == 17.15)
                {
                    Ac = 11.4707;
                    Lc = 22.2;
                }
                else if (w0 == 18.15)
                {
                    Ac = 11.8;
                    Lc = 23.1;
                }
                else
                {
                    Ac = 0;
                    Lc = 0;
                }
                obj = new BoxBeam(3.6, Ac, span, 190, 40);
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

        public override double GetBridgeWidth(double pk0)
        {
            return 17.15;
        }

        public override int GetTBeamNum(double w0,Globals.BeamType refBT)
        {
            int beamNum;
            
            if (refBT == Globals.BeamType.T25)
            {
                if (w0 == 13.65)
                {
                    beamNum = 8;

                }
                else if (w0 == 14.65)
                {
                    beamNum = 9;

                }
                else if (w0 == 17.15)
                {
                    beamNum = 10;

                }
                else if (w0 == 18.15)
                {
                    beamNum = 11;
                }
                else
                {
                    beamNum = 0;
                }
            }
            else if (refBT == Globals.BeamType.T35)
            {
                if (w0 == 13.65)
                {
                    beamNum = 7;

                }
                else if (w0 == 14.65)
                {
                    beamNum = 8;

                }
                else if (w0 == 17.15)
                {
                    beamNum = 9;

                }
                else if (w0 == 18.15)
                {
                    beamNum = 10;
                }
                else
                {
                    beamNum = 0;
                }
            }
            else
            {
                beamNum = 1;
            }
            return beamNum;
        }


        /// <summary>
        /// 获取第spanIndex跨主梁类型
        /// </summary>
        /// <param name="spanIndex">索引</param>
        /// <param name="curBridge">对象</param>
        /// <returns></returns>
        private Globals.BeamType GetBeamType(int spanIndex,ref Bridge curBridge)
        {
            double span = curBridge.SpanList[spanIndex];
            if (span == 10)
            {
                return Globals.BeamType.F10;
            }
            else if (span == 15)
            {
                return Globals.BeamType.F15;
            }
            else if (span == 25)
            {
                return Globals.BeamType.T25;
            }
            else if (span == 35)
            {

                if (spanIndex == 0)
                {
                    if (curBridge.SpanList.Count == 1)
                    {
                        return Globals.BeamType.T35;
                    }
                    else if (curBridge.SpanList[spanIndex + 1] == 60)
                    {
                        return Globals.BeamType.B60;
                    }
                    else
                    {
                        return Globals.BeamType.T35;
                    }
                }
                else if (spanIndex == curBridge.SpanList.Count - 1)
                {
                    if (curBridge.SpanList[spanIndex - 1] == 60)
                    {
                        return Globals.BeamType.B60;
                    }
                    else
                    {
                        return Globals.BeamType.T35;
                    }
                }
                else
                {
                    if (curBridge.SpanList[spanIndex + 1] == 60 | curBridge.SpanList[spanIndex - 1] == 60)
                    {
                        return Globals.BeamType.B60;
                    }
                    else
                    {
                        return Globals.BeamType.T35;
                    }

                }
            }
            else if (span == 50)
            {
                return Globals.BeamType.B50;
            }
            else if (span == 60)
            {
                return Globals.BeamType.B60;
            }

            return Globals.BeamType.F15;
        }


        
        public override double GetZLength(double cZH)
        {
            return 30.0;
        }

        internal virtual void Auxiliary(ref Bridge curBridge)
        {
            ;
        }

        public override double GetZHTLength(double pk)
        {
            return GetZLength(pk) * 0.05;
        }

       
    }
}
