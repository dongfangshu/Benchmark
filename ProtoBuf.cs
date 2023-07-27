using BenchmarkDotNet.Attributes;
using MemoryPack;
using ProtoBuf;
using System.IO;

namespace TestConsole
{
    [MemoryDiagnoser]
    public class ProtoBuf
    {
        [Benchmark]
        public void Test1()
        {
            MemoryStream stream = new MemoryStream();
            var data = ModelHelper.GetTest1Data();
            Serializer.Serialize(stream, data);
        }
        public void ConsoleSize()
        {
            MemoryStream stream = new MemoryStream();
            var data = ModelHelper.GetTest1Data();
            Serializer.Serialize(stream, data);
            Console.WriteLine($"ProtoBuf,byte size =" + stream.ToArray().Length);
        }
    }
}
