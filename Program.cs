using BenchmarkDotNet.Running;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = ModelHelper.GetTest1Data();
            BenchmarkRunner.Run<GDNet>();
            BenchmarkRunner.Run<MemoryPack>();
            //Console.WriteLine(data);
            //GDNet gDNet = new GDNet();
            //gDNet.ConsoleSize();

            //MemoryPack memoryPack = new MemoryPack();
            //memoryPack.ConsoleSize();
        }
    }
}