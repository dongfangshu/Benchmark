using BenchmarkDotNet.Attributes;
using MemoryPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{

    public class MemoryPack
    {
        [Benchmark]
        public void Test1()
        {
            var data = ModelHelper.GetTest1Data();
            var segment = MemoryPackSerializer.Serialize(data);
            Console.WriteLine($"MemoryPack,byte size =" + segment.Length);
        }
    }
}
