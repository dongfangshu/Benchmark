using BenchmarkDotNet.Attributes;
using Net.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    [MemoryDiagnoser]
    public class GDNet
    {
        [Benchmark]
        public void Test1()
        {
            var data = ModelHelper.GetTest1Data();
            var segment = NetConvertFast2.SerializeObject(data);
        }
        public void ConsoleSize()
        {
            var data = ModelHelper.GetTest1Data();
            int size = NetConvertFast2.SerializeObject(data).Count;
            Console.WriteLine($"GDNet,byte size =" + size);
        }
    }
}
