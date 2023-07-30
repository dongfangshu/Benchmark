using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Dia2Lib;
using MemoryPack;
using Net.Serialize;
using Net.System;
using Newtonsoft_X.Json.Linq;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    [CategoriesColumn]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class MyBenchMark
    {
        User Value;
        MemoryStream stream;
        byte[] MemoryPackBin;
        byte[] GDNetBin;
        Segment GDNetSegment;
        byte[] ProtobufBin;
        BenchMark.User ProtocolData;
        byte[] ProtocolBin;
        public MyBenchMark() {
            stream = new MemoryStream();
            Value = ModelHelper.GetTest1Data();
            MemoryPackBin = MemoryPackSerializer.Serialize(Value);
            var memoryPackObj = MemoryPackSerializer.Deserialize<User>(MemoryPackBin);
            bool right = Value.Equals(memoryPackObj);
            Console.WriteLine($"memoryPackObj binary size:{MemoryPackBin.Length},Deserialize result:{right}");

            GDNetSegment = NetConvertFast2.SerializeObject(Value);
            GDNetBin = GDNetSegment.ToArray();
            var GDNetObj = NetConvertFast2.DeserializeObject<User>(GDNetSegment);
            right = Value.Equals(GDNetObj);
            Console.WriteLine($"GDNet binary size:{GDNetSegment.Count},Deserialize result:{right}");

            Serializer.Serialize(stream, Value);
            ProtobufBin = stream.ToArray();
            var ProtobufObj = Serializer.Deserialize<User>(ProtobufBin.AsSpan());
            right = Value.Equals(ProtobufObj);
            stream.Position = 0;
            Console.WriteLine($"Protobuf binary size:{ProtobufBin.Length},Deserialize result:{right}");

            ProtocolData = ModelHelper.UserToProtocol(Value);
            ProtocolBin = new byte[1024*500];
            int offset = 0;
            ProtocolData.Write(ProtocolBin,ref offset);
            Console.WriteLine($"Protocol binary size:{offset}");
        }

        [Benchmark,BenchmarkCategory("Serialize","byte[]")]
        public void MemoryPack_Serialize()
        {
            MemoryPackSerializer.Serialize(Value);
        }
        [Benchmark, BenchmarkCategory("Deserialize", "byte[]")]
        public void MemoryPack_Deserialize()
        {
            MemoryPackSerializer.Deserialize<User>(MemoryPackBin);
        }
        [Benchmark, BenchmarkCategory("Serialize", "byte[]")]
        public void Gdnet_Serialize()
        {
            NetConvertFast2.SerializeObject(Value);
        }
        [Benchmark, BenchmarkCategory("Deserialize", "byte[]")]
        public void Gdnet_Deserialize()
        {
            //Segment segment = BufferPool.Take();
            Segment segment = new Segment(GDNetBin);
            //GDNetSegment.Position = 0;
            //GDNetSegment.Offset = 0;
            NetConvertFast2.DeserializeObject<User>(segment, true);
        }

        [Benchmark, BenchmarkCategory("Serialize", "byte[]")]
        public void Protobuf_net_Serialize()
        {
            stream.Position = 0;
            Serializer.Serialize(stream, Value);
        }
        [Benchmark, BenchmarkCategory("Deserialize", "byte[]")]
        public void Protobuf_net_Deserialize()
        {
            Serializer.Deserialize<User>(ProtobufBin.AsSpan());
        }

        [Benchmark, BenchmarkCategory("Serialize", "byte[]")]
        public void Protocol_Serialize()
        {
            int offset = 0;
            ProtocolData.Write(ProtocolBin, ref offset);
        }
        [Benchmark, BenchmarkCategory("Deserialize", "byte[]")]
        public void Protocol_Deserialize()
        {
            int offset = 0;
            BenchMark.User BenchMarkUserData = new BenchMark.User();
            BenchMarkUserData.Read(ProtocolBin, ref offset);
        }
    }
}
