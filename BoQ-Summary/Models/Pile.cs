using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BoQ_Summary.Globals;

namespace BoQ_Summary.Models
{
    public class Pile
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
        /// <param name="lz"></param>
        /// <param name="ld"></param>
        /// <param name="r"></param>
        public Pile(double lz,double ld,double r)
        {
            Lz = lz;
            Ld = ld;
            Rho = r;
        }

        public void WriteData(ref DataTable dt,string br,int xmh_zj,int xmh_zjrebar)
        {
            WriteRcd(ref dt, br,"桩基", "","","混凝土","",Lz,Vol, xmh_zj);
            WriteRcd(ref dt, br, "桩基", "", "", "钢筋", "", Rho* Vol,Lz, xmh_zjrebar);
        }


    }
}
