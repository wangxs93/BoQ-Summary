using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoQ_Summary.Inputs;
namespace BoQ_Summary
{
    class Program
    {
        static void Main(string[] args)
        {
            SQX LK_SQX =new SQX("LK", InputDatas.LK);
            DMX LK_DMX = new DMX("LK", InputDatas.LKDMX);
            var ff= LK_SQX.GetBG(148020.000);
        }
    }
}
