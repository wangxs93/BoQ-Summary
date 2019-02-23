using System;
using System.Data;
using System.IO;
using System.Reflection;
using BoQCore;

namespace Configuration
{    

    public class Configer
    {
        public string Name;
        public GZX BridgeList { get; set; }
        public DMX Dmx { get; set; }
        public SQX Sjx { get; set; }
        public DataTable Record { get; set; }

        readonly GeneralConfig ConfigInstance;


        public Configer(string ss)
        {
            Name = ss;
            string fullName = "Configuration." + ss;//命名空间.类型名
            object ect = Assembly.Load("Configuration").CreateInstance(fullName);
            ConfigInstance = (GeneralConfig)ect;

        }



        public void Run()
        {
            ConfigInstance.testc();
        }

       
    }
}