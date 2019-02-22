using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQApplication.Models
{
    abstract public class BaseModel
    {
        public abstract void WriteData(ref DataTable dt, string br, int xmh1, int xmh2);

    }
}
