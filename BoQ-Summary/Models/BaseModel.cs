using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQ_Summary.Models
{
    abstract class BaseModel
    {
        public abstract void WriteData(ref DataTable dt, string br, int xmh_zj, int xmh_zjrebar);

    }
}
