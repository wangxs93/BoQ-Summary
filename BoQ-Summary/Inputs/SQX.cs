using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoQ_Summary.Inputs
{
    public struct BPD
    {
        public double PK,H,R;       
        
    }

    public class SQX
    {
        public string Name
        {
            get;
        }
        public List<BPD> BPDList;

        public SQX(string name,byte[] inputs)
        {
            Name = name;
            BPDList = new List<BPD>();

            var ff = inputs;
            Decoder d = Encoding.UTF8.GetDecoder();
            int charSize = d.GetCharCount(ff, 0, ff.Length);
            char[] chs = new char[charSize];
            d.GetChars(ff, 0, ff.Length, chs, 0);
            string s = new string(chs);
            var ss = s.Split('\n');
            
            foreach (string item in ss)
            {
                BPD pt = new BPD();
                try
                {
                    string line=item.TrimEnd('\r');
                    var xx = Regex.Split(line,@"\s+");
                    pt.PK = double.Parse(xx[0]);
                    pt.H = double.Parse(xx[1]);
                    if (xx.Length==3)
                    {
                        pt.R = double.Parse(xx[2]);
                    }
                    else
                    {
                        pt.R = -1;
                    }
                    BPDList.Add(pt);
                }
                catch (Exception)
                {
                    throw;
                }

            }
            
        }


    }
}
