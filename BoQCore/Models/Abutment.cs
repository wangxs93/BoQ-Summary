using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQCore
{
    public class Abutment : BasicModel
    {
        public double  BackWallH, Embarkment, AbutWidth, AbutWallT;
        private readonly double PileCapRho,PlateRho,BackWallRho,AbutWallRho,WingWallRho;
        private readonly double WingWallA, AbutWallH;


        /// <summary>
        /// 桥台构造函数
        /// </summary>
        /// <param name="embark">实际填土高度（背墙+前墙）</param>
        /// <param name="abutw">桥面全宽</param>
        /// <param name="bwh">背墙高</param>
        /// <param name="abwt">桥台厚度</param>
        /// <param name="pcrho"></param>
        /// <param name="plarho"></param>
        /// <param name="bwr"></param>
        /// <param name="awr"></param>
        /// <param name="wwr"></param>
        public Abutment(double embark, double abutw, double bwh,double abwt,double pcrho,double plarho,double bwr,double awr,double wwr) 
            : base(embark, 0,0)
        {
            Embarkment = embark;
            BackWallH = bwh;            
            AbutWallT = abwt;
            AbutWidth = abutw;

            PileCapRho = pcrho;
            PlateRho = plarho;
            BackWallRho = bwr;
            AbutWallRho = awr;
            WingWallRho = wwr;

            AbutWallH = embark - bwh;

            if (AbutWallH*BackWallH*Embarkment<=0)
            {
                throw new Exception("填土高度错误");                
            }            

            if (AbutWallH >= 8)
            {
                WingWallA = Embarkment * 1.55;
            }
            else if (AbutWallH >= 5)
            {
                WingWallA = ((BackWallH + 1.8) * 1.5 + 0.7 - AbutWallT) + Embarkment * 1.55 + Math.Pow((BackWallH + 1.8) * 1.5 - AbutWallT, 2) / 1.5 * 0.5;
            }
            else
            {
                WingWallA = (Embarkment * 1.5 + 0.7 - AbutWallT) + Embarkment * 1.55 + Math.Pow(Embarkment * 1.5 - AbutWallT, 2) / 1.5 * 0.5;
            }
        }

        
        public override void WriteData(ref DataTable dt, string br, int times = 1)
        {
            string ts = string.Format("Abut{0:D2}", (int)(Embarkment * 100));
            Globals.Write(ref dt, br, "台背回填", "", ts, "土石方",  "", (1.75 + Embarkment * 0.5 + 1.75) * Embarkment * 0.5 * AbutWidth, 1, 1, 1);
            Globals.Write(ref dt, br, "搭板", "", ts, "混凝土", "", 0.3 * 4.5 * AbutWidth, 1, 1, 1);
            Globals.Write(ref dt, br, "搭板", "", ts, "混凝土", "C15", 0.1 * (4.5 + 0.2) * (AbutWidth + 0.2) , 1, 1, 1);
            Globals.Write(ref dt, br, "搭板", "", ts, "钢筋", "", 0.3 * 4.5 * AbutWidth * PlateRho, 1, 1, 1);
            Globals.Write(ref dt, br, "承台", "", ts, "混凝土", "C35", 1.6 * 5.6 * AbutWidth, 1, 1, 1);
            Globals.Write(ref dt, br, "承台", "", ts, "混凝土", "C15", 0.1 * 5.8 * (AbutWidth + 0.2), 1, 1, 1);
            Globals.Write(ref dt, br, "承台", "", ts, "钢筋", "HRB400", 1.6 * 5.6 * AbutWidth * PileCapRho, 1, 1, 1);
            Globals.Write(ref dt, br, "背墙", "", ts, "混凝土", "C35", BackWallH * 0.65 * AbutWidth, 1, 1, 1);
            Globals.Write(ref dt, br, "背墙", "", ts, "钢筋", "HRB400", BackWallH * 0.65 * AbutWidth * BackWallRho, 1, 1, 1);
            Globals.Write(ref dt, br, "台身", "", ts, "混凝土", "C35", AbutWallH * AbutWallT * AbutWidth, 1, 1, 1);
            Globals.Write(ref dt, br, "台身", "", ts, "钢筋", "HRB400", AbutWallH * AbutWallT * AbutWidth * AbutWallRho, 1, 1, 1);
            Globals.Write(ref dt, br, "翼墙", "", ts, "混凝土", "C35", WingWallA * 0.5, 1, 1, 1);
            Globals.Write(ref dt, br, "翼墙", "", ts, "钢筋", "HRB400", WingWallA * 0.5 * WingWallRho, 1, 1, 1);
            Globals.Write(ref dt, br, "翼墙", "", ts, "混凝土", "C35", WingWallA * 0.5, 1, 1, 1);
            Globals.Write(ref dt, br, "翼墙", "", ts, "钢筋", "HRB400", WingWallA * 0.5 * WingWallRho, 1, 1, 1);

        }
    }
}
