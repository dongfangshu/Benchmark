using BenchmarkDotNet.Running;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<GDNet>();
            //BenchmarkRunner.Run<MemoryPack>();
            ModelHelper.GetTest1Data();
        }
    }
}