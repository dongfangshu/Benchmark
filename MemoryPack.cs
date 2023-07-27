using BenchmarkDotNet.Attributes;
using MemoryPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    [MemoryDiagnoser]
    public class MemoryPack
    {
        [Benchmark]
        public void Test1()
        {
            var data = ModelHelper.GetTest1Data();
            MemoryPackSerializer.Serialize(data);
        }
        public void ConsoleSize()
        {
            var data = ModelHelper.GetTest1Data();
            byte[] bytes = MemoryPackSerializer.Serialize(data);
            Console.WriteLine($"MemoryPack,byte size =" + bytes.Length);
        }
    }
}
