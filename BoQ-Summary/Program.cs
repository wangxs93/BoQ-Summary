using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoQ_Summary
{
    class Program
    {
        static void Main(string[] args)
        {
            Inputs.SQX LK =new Inputs.SQX("LK", InputDatas.LK);

            var ff=LK.GetBG(148020.000);
        }
    }
}
