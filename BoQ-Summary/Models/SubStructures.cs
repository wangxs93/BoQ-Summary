using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BoQ_Summary.Globals;

namespace BoQ_Summary.Models
{
    public class SubStructures:BaseModel
    {
        public readonly double Hmin, Hmax;
        public readonly BeamType BeamBack, BeamFront;
        public PileCap PileCap;
        public Pile Pile;
        public int PileNum;


        public void WriteData(ref DataTable dt, string br, int xmh_zj,int xmh_zjrebar)
        {
            for (int i = 0; i < PileNum; i++)
            {
                Pile.WriteData(ref dt, br, xmh_zj, xmh_zjrebar);
            }            
        }






    }
}
