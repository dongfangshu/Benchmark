using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = ManualConfig.CreateMinimumViable()
    .AddDiagnoser(MemoryDiagnoser.Default)
    // .AddColumn(StatisticColumn.OperationsPerSecond)
    //.AddExporter(DefaultExporters.Plain)
    .AddExporter(MarkdownExporter.Default)
    .AddJob(Job.Default.WithWarmupCount(1).WithIterationCount(1)); // .AddJob(Job.ShortRun);
            //var config = ManualConfig.CreateEmpty();
            config.WithOptions(ConfigOptions.DisableOptimizationsValidator);
            var data = ModelHelper.GetTest1Data();
            //BenchmarkRunner.Run<GDNet>(config);
            //BenchmarkRunner.Run<MemoryPack>(config);
            //BenchmarkRunner.Run<ProtoBuf>(config);
            //Console.WriteLine(data);
            GDNet gDNet = new GDNet();
            gDNet.ConsoleSize();

            MemoryPack memoryPack = new MemoryPack();
            memoryPack.ConsoleSize();

            ProtoBuf protoBuf = new ProtoBuf();
            protoBuf.ConsoleSize();
        }
    }
}