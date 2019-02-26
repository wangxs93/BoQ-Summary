using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BoQCore
{
    public class Recorder
    {
        public static void Write(ref DataTable alrcd,
            string BriName, string cla, string loc, string det, string mname, string spec,
            double Q1, double Q2, int xmh1, int xmh2)
        {
            DataRow newRow = alrcd.NewRow();
            newRow["bridge"] = BriName;
            newRow["class"] = cla;
            newRow["loc"] = loc;
            newRow["detial"] = det;
            newRow["name"] = mname;
            newRow["spec"] = spec;
            newRow["quantity1"] = Q1;
            newRow["quantity2"] = Q2;
            newRow["xmh1"] = xmh1;
            newRow["xmh2"] = xmh2;
            alrcd.Rows.Add(newRow);
        }

    }
}
