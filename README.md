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

|                  Method |       Categories |      Mean |    Error |   StdDev |   Gen0 |   Gen1 | Allocated |
|------------------------ |----------------- |----------:|---------:|---------:|-------:|-------:|----------:|
|    Utf8Json_Deserialize | Deserialize,Json |  29.15 μs | 0.059 μs | 0.053 μs | 2.3804 | 0.1526 |  39.07 KB |
| JsonUtility_Deserialize | Deserialize,Json |  60.36 μs | 0.207 μs | 0.183 μs | 1.5259 | 0.1221 |   25.8 KB |
|  Newtonsoft_Deserialize | Deserialize,Json |  60.44 μs | 0.214 μs | 0.200 μs | 2.7466 | 0.2441 |  45.84 KB |
|     LitJson_Deserialize | Deserialize,Json | 117.05 μs | 0.194 μs | 0.181 μs | 4.7607 | 0.7324 |  78.23 KB |
|                         |                  |           |          |          |        |        |           |
|      Utf8Json_Serialize |   Serialize,Json |  25.10 μs | 0.058 μs | 0.054 μs | 1.6479 |      - |  27.37 KB |
|    Newtonsoft_Serialize |   Serialize,Json |  40.44 μs | 0.188 μs | 0.176 μs | 4.0283 | 0.1831 |  66.04 KB |
|   JsonUtility_Serialize |   Serialize,Json |  45.93 μs | 0.124 μs | 0.097 μs | 2.1362 |      - |  35.78 KB |
|       LitJson_Serialize |   Serialize,Json |  59.03 μs | 0.158 μs | 0.147 μs | 2.1973 |      - |  36.14 KB |

JsonSerializer Length:18059 result:False
Newtonsoft Length:13973 result:False
LitJson Length:13973 result:False
Utf8Json Length:13976 result:False