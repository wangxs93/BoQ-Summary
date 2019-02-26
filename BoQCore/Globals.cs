using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace BoQCore
{
    
    public static class Globals
    {
        public enum BeamType {None, F10, F15, T25, T35, B50, B60 }

        /// <summary>
        /// 输出CSV文件
        /// </summary>
        /// <param name="dt">当前DataTable</param>
        /// <param name="file_name">文件名</param>
        public static void DataTableToCSV(this DataTable dt, string file_name)
        {
            StreamWriter fw = null;
            try
            {
                fw = new StreamWriter(string.Format("C:\\Users\\Bill\\Desktop\\{0}.csv", file_name), false, Encoding.GetEncoding("GBK"));
                //写入表头
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    fw.Write(dt.Columns[i].ColumnName);
                    if (i != dt.Columns.Count - 1)
                    {
                        fw.Write(",");
                    }
                    else
                    {
                        fw.Write("\n");
                    }
                    fw.Flush();
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string[] arrBody = new string[dt.Columns.Count];
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        try
                        {
                            var f = dt.Rows[i][j];
                            arrBody[j] = f.ToString();
                        }
                        catch (Exception)
                        {

                        }
                    }                    
                    fw.WriteLine(arrBody.Together());
                    fw.Flush();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                fw.Close();
            }
        }

        public static string Together(this string[] arr, string sep = ",")
        {
            string res = "";
            for (int i = 0; i < arr.Length; i++)
            {
                res += arr[i];
                if (i != arr.Length - 1)
                {
                    res += sep;
                }
            }
            return res;
        }

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
