using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQCore
{
    
    abstract public class BaseModel
    {
        public double Vc { set; get; }
        public double L { set; get; }
        public double RhoRebar {  set; get; }
        public double RhoPreRebar {  set; get; }
        public BaseModel()
        {
            Vc = 0;
            L = 0;
            RhoPreRebar = 0;
            RhoRebar = 0;
        }

        public BaseModel(double l,double rhorebar, double rhoprerebar)
        {
            L = l;            
            RhoRebar = rhorebar;
            RhoPreRebar = rhoprerebar;
        }

        public abstract void WriteData(ref DataTable dt, string br, int xmh1, int xmh2);

    }
}
