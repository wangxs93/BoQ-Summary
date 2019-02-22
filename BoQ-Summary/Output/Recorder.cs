using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration;
using System.Data;

namespace BoQApplication.Output
{
    public class Recorder
    {
        public static void Write(ref DataTable alrcd,
            string BriName, string cla, string loc, string det, string mname, string spec,
            double Q1, double Q2, int xmh)
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
            newRow["xmh"] = xmh;
            alrcd.Rows.Add(newRow);
        }

    }
}
