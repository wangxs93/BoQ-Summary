using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoQCore
{
    public class Pile: BasicModel
    {
        public double Lz
        {
            get;set;
        }
        public double Ld
        {
            get;set;
        }
        public double Rho
        {
            set;get;
        }
        double Vol
        {
            get
            {
                return Lz * Ld * Ld * 0.25 * Math.PI;
            }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="lz">桩长</param>
        /// <param name="ld">桩径</param>
        /// <param name="r">含筋率</param>
        public Pile(double lz,double ld,double r)
        {
            Lz = lz;
            Ld = ld;
            Rho = r;
        }

        //public void WriteData(ref DataTable dt,string br,int xmh_zj,int xmh_zjrebar)
        //{
        //    Recorder.Write(ref dt, br,"桩基", "","","混凝土","",Lz,Vol, xmh_zj);
        //    Recorder.Write(ref dt, br, "桩基", "", "", "钢筋", "", Rho* Vol,Lz, xmh_zjrebar);
        //}

        public override void WriteData(ref DataTable dt, string br,int times=1)
        {
            Recorder.Write(ref dt, br, "桩基", "", "", "", "", 1, 1, 1,1);
            //Recorder.Write(ref dt, br, "桩基", "", "", "混凝土", "", Lz, Vol, xmh_zj);
            //Recorder.Write(ref dt, br, "桩基", "", "", "钢筋", "", Rho * Vol, Lz, xmh_zjrebar);
        }
    }
}
