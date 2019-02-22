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
            SQX LK_SQX =new SQX("LK", InputDatas.LKSQX);
            DMX LK_DMX = new DMX("LK", InputDatas.LKDMX);
            GZX LK_GZX = new GZX("LK", InputDatas.LKBOB);
            foreach (var item in LK_GZX.BRList)
            {
                Console.WriteLine();
                List<double> aa = new List<double>();
                
                for (int i = 0; i < item.SpanList.Count+1; i++)
                {
                    double pk0 = item.ZH - 0.5 * item.Length + item.SpanList.GetRange(0, i).Sum();
                    aa.Add(LK_SQX.GetBG(pk0) - LK_DMX.GetBG(pk0));
                    //Console.WriteLine("\t{0:F2}", LK_SQX.GetBG(pk0) - LK_DMX.GetBG(pk0));

                }
                Console.Write("{0},{1:F1}", item.Name,aa.Max());
            }
        }
    }
}
