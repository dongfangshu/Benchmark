using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using MemoryPack;
using Net.Serialize;
using Net.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    [CategoriesColumn]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class 八倍哥的测试代码
    {

        byte[] MemoryPackBin;
        byte[] GDNetBin;
        Test Value;
        public 八倍哥的测试代码()
        {
            Value = new Test()
            {
                f1 = 123,
                f2 = 123,
                f3 = true,
                f4 = 4567,
                f5 = 6842,
                f6 = 'k',
                f7 = 4567891,
                f8 = 456478971,
                f9 = 1234.4564f,
                f10 = 47489745665,
                f11 = 4564654123123,
                f12 = 123.456456,
                f13 = DateTime.Now,
                f14 = 456123.45676465m,
                f15 = "John",
                fa1 = new byte[] { 1, 2, 3 },
                fl1 = new List<byte> { 1, 2, 4 },
                fd1 = new Dictionary<int, byte> { { 1, 5 }, { 2, 3 }, { 5, 8 } },
            };

            MemoryPackBin = MemoryPackSerializer.Serialize(Value);
            GDNetBin = NetConvertFast2.SerializeObject(Value).ToArray();
        }

        [Benchmark, BenchmarkCategory("Serialize", "byte[]")]
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
            NetConvertFast2.DeserializeObject<User>(segment, false);
        }
    }
}
