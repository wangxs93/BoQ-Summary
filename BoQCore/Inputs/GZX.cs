using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoQCore
{
    public class Bridge
    {
        public int ClassNum;
        public string Name;
        public double ZH,Angle,LenA,LenB;
        public string Span, Type;
        public double Length;
        public List<double> SpanList
        {
            get
            {
                List<double> res = new List<double>();
                string[] aa = Span.Split('+');
                foreach (string st in aa)
                {
                    int times,L;                    
                    if (st.Contains("*"))
                    {
                        times = int.Parse(st.Split('*')[0]);
                        L = int.Parse(st.Split('*')[1]);
                    }
                    else
                    {
                        times = 1;
                        L = int.Parse(st);
                    }

                    for (int i = 0; i < times; i++)
                    {
                        res.Add(L);
                    }
                }
                return res;
            }
        }

    }


    public class GZX
    {
        public string Name
        {
            set;get;
        }

        readonly public List<Bridge> BRList;

        public GZX(string name, byte[] inputs)
        {
            Name = name;
            BRList = new List<Bridge>();

            var ff = inputs;
            Decoder d = Encoding.UTF8.GetDecoder();
            int charSize = d.GetCharCount(ff, 0, ff.Length);
            char[] chs = new char[charSize];
            d.GetChars(ff, 0, ff.Length, chs, 0);
            string s = new string(chs);
            var ss = s.Split('\n');

            string line;
            string[] xx;
            foreach (string item in ss)
            {
                Bridge bridge = new Bridge();
                if (item.StartsWith("//"))
                {
                    continue;
                }

                try
                {
                    line = item.TrimEnd('\r');
                    xx = Regex.Split(line, @"\s+");

                    
                    bridge.ClassNum = int.Parse(xx[0]);
                    bridge.Name = xx[1];
                    xx[2] = xx[2].Split('_')[0];
                    xx[2]=xx[2].Replace("C","");
                    bridge.ZH= double.Parse(xx[2]);

                    xx[3] = xx[3].Replace("d", "");
                    bridge.Angle = double.Parse(xx[3]);
                    bridge.LenA = double.Parse(xx[4]);
                    bridge.LenB = double.Parse(xx[5]);
                    bridge.Span = xx[6];
                    bridge.Type = xx[7];                    
                    bridge.Length = double.Parse(new DataTable().Compute(bridge.Span, "").ToString());

                    BRList.Add(bridge);
                }
                catch (Exception)
                {
                    throw;
                }

            }
            BRList.Sort((x, y) => x.ZH.CompareTo(y.ZH));
        }

    }
}
