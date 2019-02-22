using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoQCore
{
    public class SubStructures
    {
        public readonly double Hmin, Hmax;
        public readonly Globals.BeamType BeamBack, BeamFront;
        public PileCap PileCap;
        public Pile Pile;
        public int PileNum;


        //public void WriteToRcd(ref DataTable dt, string br, int xmh_zj,int xmh_zjrebar)
        //{
        //    for (int i = 0; i < PileNum; i++)
        //    {
        //        Pile.WriteData(ref dt, br, xmh_zj, xmh_zjrebar);
        //    }            
        //}






    }
}
