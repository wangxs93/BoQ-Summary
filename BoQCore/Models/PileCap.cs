using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoQCore
{
    public class PileCap:BasicModel//桩承台统计
    {
        public double LongDim//顺桥向长度
        {
            set;get;
        }
        public double TransDim//横桥向长度
        {
            set;get;
        }
        public double Height//承台高度
        {
            set;get;
        }
        double Vol2//垫层体积
        {
            get
            {
                return (LongDim+2*0.1) * (TransDim+2*0.1) * 0.1;
            }
        }
        public string Name;
        /// <summary>
        /// 构造函数
        /// </summary>
        public PileCap(double longDim,double transDim,double height,double r,string name):base(height,r,0)
        {
            Name = name;
            LongDim=longDim;
            TransDim=transDim;
            Height=height;
            Vc = longDim * transDim * height;
        }



        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="dt"></param>
        public override void WriteData(ref DataTable dt,string br, int times = 1)
        {            
            Globals.Write(ref dt, br, "承台", "", Name, "混凝土", "", Vc, 1, 1, 1);
            Globals.Write(ref dt, br, "承台", "", Name,  "混凝土", "C15", Vol2, 1, 1, 1);
            Globals.Write(ref dt, br, "承台", "", Name, "钢筋", "", Vc * RhoRebar, 1, 1, 1);
            
            if (RhoPreRebar != 0)
            {
                Globals.Write(ref dt, br, "承台", "", Name, "预应力钢束", "", Vc * RhoPreRebar, 1, 1, 1);
            }
            
            
            

        }
    }
}
