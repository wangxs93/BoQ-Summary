using System;
using System.Data;
using System.IO;
using System.Reflection;
using BoQCore;
using Configuration;

namespace BoQApplication
{

    

    internal class Configer
    {
        public string Name;
        public GZX BridgeList { get; internal set; }
        public DMX Dmx { get; internal set; }
        public SQX Sjx { get; internal set; }
        public DataTable Record { get; internal set; }

        readonly GeneralConfig ConfigInstance;


        public Configer(string ss)
        {
            Name = ss;
            string fullName = "Configuration." + ss;//命名空间.类型名
            object ect = Assembly.Load("Configuration").CreateInstance(fullName);
            ConfigInstance = (GeneralConfig)ect;

        }



        internal void Run()
        {
            ConfigInstance.testc();
        }

        /// <summary>
        /// 创建对象实例
        /// </summary>
        /// <typeparam name="T">要创建对象的类型</typeparam>
        /// <param name="assemblyName">类型所在程序集名称</param>
        /// <param name="nameSpace">类型所在命名空间</param>
        /// <param name="className">类型名</param>
        /// <returns></returns>
        public static T CreateInstance<T>(string assemblyName, string nameSpace, string className)
        {
            try
            {
                string fullName = nameSpace + "." + className;//命名空间.类型名
                //此为第一种写法
                object ect = Assembly.Load(assemblyName).CreateInstance(fullName);//加载程序集，创建程序集里面的 命名空间.类型名 实例
                return (T)ect;//类型转换并返回
                //下面是第二种写法
                //string path = fullName + "," + assemblyName;//命名空间.类型名,程序集
                //Type o = Type.GetType(path);//加载类型
                //object obj = Activator.CreateInstance(o, true);//根据类型创建实例
                //return (T)obj;//类型转换并返回
            }
            catch
            {
                //发生异常，返回类型的默认值
                return default(T);
            }
        }
    }
}