using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Binding;
using MemoryPack;
using Net.Serialize;
using Net.System;
using Newtonsoft_X.Json.Linq;
using ProtoBuf;

namespace Binding
{
    //Binding.BindingType
    public class BindingType : IBindingType
    {
        public int SortingOrder => 0;
        //AddSerializeType
        public Dictionary<Type, Type> BindTypes { get; set; } = new Dictionary<Type, Type>()
            {
                { typeof(User), typeof(UserBind) },
                { typeof(Resources), typeof(ResourcesBind) },
                { typeof(Commit), typeof(CommitBind) },
                { typeof(Dictionary<System.Int32, Commit>), typeof(Dictionary_SystemInt32_CommitBind_Bind) },
                { typeof(Dictionary<System.String, System.String>), typeof(Dictionary_SystemString_SystemString_Bind) },
                { typeof(System.Collections.Generic.LinkedList<System.Int32>), typeof(SystemCollectionsGenericLinkedListSystemInt32Bind) },
                { typeof(Queue<System.Int32>), typeof(SystemCollectionsGenericQueueSystemInt32Bind) },
                { typeof(Stack<System.Int32>), typeof(SystemCollectionsGenericStackSystemInt32Bind) },
                { typeof(TimeSpan), typeof(SystemTimeSpanBind) },
            };
    }
}
namespace TestConsole
{
    [ProtoContract]
    [MemoryPackable]
    public partial class MyData
    {
        [ProtoMember(1)]
        public int Id;
        [ProtoMember(2)]
        public string Name;
    }
    internal class Program
    {


        static void Main(string[] args)
        {
            //        var config = ManualConfig.CreateMinimumViable()
            //.AddDiagnoser(MemoryDiagnoser.Default)
            //// .AddColumn(StatisticColumn.OperationsPerSecond)
            ////.AddExporter(DefaultExporters.Plain)
            //.AddExporter(MarkdownExporter.Default)
            //.AddJob(Job.Default.WithWarmupCount(1).WithIterationCount(1)); // .AddJob(Job.ShortRun);
            //        //var config = ManualConfig.CreateEmpty();
            //        config.WithOptions(ConfigOptions.DisableOptimizationsValidator);
            //Fast2BuildMethod.DynamicBuild(BindingEntry.GetBindTypes());//动态编译指定的类型列表


             var Value = ModelHelper.GetTest1Data();
            //try
            //{
            //    //MyData myData = new MyData();
            //    //myData.Id = 10;
            //    //myData.Name="Test";
            //    MemoryStream stream = new MemoryStream();
            //    Serializer.Serialize(stream, Value);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    throw;
            //}

            //NetConvertFast2.AddSerializeType3<User>();

            //var segment = NetConvertFast2.SerializeObject(Value).read;
            //BenchmarkRunner.Run<GDNet>();
            //BenchmarkRunner.Run<MemoryPack>();
            //BenchmarkRunner.Run<ProtoBuf>();
            //Console.WriteLine(data);
            //GDNet gDNet = new GDNet();
            //gDNet.ConsoleSize();

            //MemoryPack memoryPack = new MemoryPack();
            //memoryPack.ConsoleSize();

            //ProtoBuf protoBuf = new ProtoBuf();
            //protoBuf.ConsoleSize();

            BenchmarkRunner.Run<MyBenchMark>();

            //try
            //{
            //    MyBenchMark myBenchMark = new MyBenchMark();
            //    myBenchMark.MemoryPack_Serialize();
            //    myBenchMark.MemoryPack_Deserialize();
            //    myBenchMark.Gdnet_Serialize();
            //    myBenchMark.Gdnet_Deserialize();
            //    myBenchMark.Protobuf_net_Serialize();
            //    myBenchMark.Protobuf_net_Deserialize();
            //    Console.WriteLine("ins");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    throw;
            //}


            //release
            //try
            //{
            //    var Value = ModelHelper.GetTest1Data();
            //    var GDNetSegment = NetConvertFast2.SerializeObject(Value);
            //    var GDNetObj = NetConvertFast2.DeserializeObject<User>(GDNetSegment);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    throw;
            //}
            //BenchmarkRunner.Run<TestBenchMark>();


            //MyBenchMark myBenchMark = new MyBenchMark();
            //myBenchMark.Protocol_Serialize();
            //myBenchMark.Protocol_Serialize();
            //myBenchMark.Protocol_Serialize();
            //myBenchMark.Protocol_Deserialize();
            //myBenchMark.Protocol_Deserialize();
            //myBenchMark.Protocol_Deserialize();
            //myBenchMark.Gdnet_Deserialize();

            //procotol test


            //Byte[] buffer = new Byte[1024*1024];
            //int offset = 0;
            //user.Write(buffer,ref offset);

            ////user.Read(buffer,ref offset);
            //offset = 0;
            //BenchMark.User user1 = new BenchMark.User();
            //user1.Read(buffer,ref offset);
        }
    }
}