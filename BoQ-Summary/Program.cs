using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoQCore;
using Configuration;

namespace BoQApplication
{
    class Program
    {
        static void Main()
        {
            // 初始化

            DataTable AllRecord = RecIni();

            // 准备输入数据
            SQX LK_SQX = new SQX("LK", InputDatas.LKSQX);
            DMX LK_DMX = new DMX("LK", InputDatas.LKDMX);
            GZX LK_GZX = new GZX("LK", InputDatas.LKBOB);

            
            // 调用配置器
            //Configer Bill = new Configer("E763Config");
            Configer Bill = new Configer("GeneralConfig");
            Bill.ConfigInstance.BridgeList = LK_GZX;
            Bill.ConfigInstance.Dmx = LK_DMX;
            Bill.ConfigInstance.Sjx = LK_SQX;
            Bill.ConfigInstance.Record = AllRecord;
            Bill.ConfigInstance.Run();






            // 完成




            Console.ReadKey();
        }


        static DataTable RecIni()
        {
            DataTable r = new DataTable();
            r.Columns.Add("bridge", typeof(string));
            r.Columns.Add("class", typeof(string));
            r.Columns.Add("loc", typeof(string));
            r.Columns.Add("detial", typeof(string));
            r.Columns.Add("name", typeof(string));
            r.Columns.Add("spec", typeof(string));
            r.Columns.Add("quantity1", typeof(double));
            r.Columns.Add("quantity2", typeof(double));
            r.Columns.Add("xmh1", typeof(string));
            r.Columns.Add("xmh2", typeof(string));

            return r;
        }



    }
}
