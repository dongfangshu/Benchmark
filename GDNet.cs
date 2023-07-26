using BenchmarkDotNet.Attributes;
using Net.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class GDNet
    {
        [Benchmark]
        public void Test1()
        {
            var data = ModelHelper.GetTest1Data();
            var segment = NetConvertFast2.SerializeObject(data);
            Console.WriteLine($"GDNet,byte size ="+segment.Count);
        }
    }
}
