# Benchmark
一些序列化库的性能测试，给大伙提供参考
设备信息
// * Summary *

BenchmarkDotNet v0.13.6, Windows 10 (10.0.19045.3208/22H2/2022Update)
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.203
  [Host]     : .NET 6.0.16 (6.0.1623.17311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.16 (6.0.1623.17311), X64 RyuJIT AVX2

二进制测试

|                   Method |         Categories |     Mean |     Error |    StdDev |   Gen0 |   Gen1 | Allocated |
|------------------------- |------------------- |---------:|----------:|----------:|-------:|-------:|----------:|
|     Protocol_Deserialize | Deserialize,byte[] | 3.440 μs | 0.0123 μs | 0.0115 μs | 1.8959 | 0.1755 |   31720 B |
|   MemoryPack_Deserialize | Deserialize,byte[] | 3.708 μs | 0.0262 μs | 0.0232 μs | 1.7853 | 0.1450 |   29912 B |
|        Gdnet_Deserialize | Deserialize,byte[] | 4.493 μs | 0.0191 μs | 0.0178 μs | 1.9302 | 0.1831 |   32353 B |
|  MessagePack_Deserialize | Deserialize,byte[] | 4.937 μs | 0.0259 μs | 0.0242 μs | 1.7776 | 0.1755 |   29792 B |
| Protobuf_net_Deserialize | Deserialize,byte[] | 8.641 μs | 0.0313 μs | 0.0261 μs | 1.8311 | 0.1831 |   30864 B |
|                          |                    |          |           |           |        |        |           |
|          Gdnet_Serialize |   Serialize,byte[] | 2.387 μs | 0.0097 μs | 0.0081 μs | 0.8583 |      - |   14384 B |
|     MemoryPack_Serialize |   Serialize,byte[] | 2.736 μs | 0.0175 μs | 0.0163 μs | 0.8316 |      - |   13944 B |
|       Protocol_Serialize |   Serialize,byte[] | 2.917 μs | 0.0158 μs | 0.0140 μs | 0.8774 |      - |   14680 B |
|    MessagePack_Serialize |   Serialize,byte[] | 3.088 μs | 0.0227 μs | 0.0212 μs | 0.8049 |      - |   13544 B |
|   Protobuf_net_Serialize |   Serialize,byte[] | 7.090 μs | 0.0195 μs | 0.0173 μs | 0.0076 |      - |     128 B |

memoryPackObj binary size:13924,Deserialize result:True
GDNet binary size:13547,Deserialize result:False
Protobuf binary size:13786,Deserialize result:False
Protocol binary size:13579
MessagePack binary size:13518,Deserialize result:True


json测试

|                  Method |       Categories |       Mean |   Error |  StdDev |   Gen0 | Allocated |
|------------------------ |----------------- |-----------:|--------:|--------:|-------:|----------:|
| JsonUtility_Deserialize | Deserialize,Json |   116.8 ns | 0.07 ns | 0.07 ns | 0.0052 |      88 B |
|    Utf8Json_Deserialize | Deserialize,Json |   395.4 ns | 2.69 ns | 2.52 ns | 0.0138 |     232 B |
|  Newtonsoft_Deserialize | Deserialize,Json | 2,261.1 ns | 9.86 ns | 9.22 ns | 0.1564 |    2672 B |
|     LitJson_Deserialize | Deserialize,Json | 3,816.3 ns | 8.81 ns | 7.81 ns | 0.1984 |    3320 B |
|                         |                  |            |         |         |        |           |
|   JsonUtility_Serialize |   Serialize,Json |   107.3 ns | 0.99 ns | 0.92 ns | 0.0110 |     184 B |
|      Utf8Json_Serialize |   Serialize,Json |   207.8 ns | 0.84 ns | 0.79 ns | 0.0153 |     256 B |
|    Newtonsoft_Serialize |   Serialize,Json |   868.8 ns | 2.91 ns | 2.72 ns | 0.0935 |    1568 B |
|       LitJson_Serialize |   Serialize,Json |   997.5 ns | 3.36 ns | 2.81 ns | 0.0286 |     496 B |
