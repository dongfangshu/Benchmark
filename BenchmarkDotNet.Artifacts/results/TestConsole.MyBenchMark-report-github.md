```

BenchmarkDotNet v0.13.6, Windows 10 (10.0.19045.3208/22H2/2022Update)
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.203
  [Host]     : .NET 6.0.16 (6.0.1623.17311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.16 (6.0.1623.17311), X64 RyuJIT AVX2


```
|                   Method |         Categories |     Mean |     Error |    StdDev |   Gen0 |   Gen1 | Allocated |
|------------------------- |------------------- |---------:|----------:|----------:|-------:|-------:|----------:|
|     Protocol_Deserialize | Deserialize,byte[] | 3.361 μs | 0.0074 μs | 0.0066 μs | 1.8959 | 0.1755 |   31720 B |
|   MemoryPack_Deserialize | Deserialize,byte[] | 3.644 μs | 0.0076 μs | 0.0071 μs | 1.7853 | 0.1450 |   29912 B |
|        Gdnet_Deserialize | Deserialize,byte[] | 4.571 μs | 0.0656 μs | 0.0581 μs | 1.9302 | 0.2747 |   32401 B |
| Protobuf_net_Deserialize | Deserialize,byte[] | 8.510 μs | 0.0255 μs | 0.0213 μs | 1.8311 | 0.1831 |   30864 B |
|                          |                    |          |           |           |        |        |           |
|     MemoryPack_Serialize |   Serialize,byte[] | 2.698 μs | 0.0068 μs | 0.0064 μs | 0.8316 |      - |   13944 B |
|       Protocol_Serialize |   Serialize,byte[] | 2.898 μs | 0.0120 μs | 0.0112 μs | 0.8774 |      - |   14680 B |
|          Gdnet_Serialize |   Serialize,byte[] | 4.777 μs | 0.0307 μs | 0.0287 μs | 1.9989 | 0.9995 |   33612 B |
|   Protobuf_net_Serialize |   Serialize,byte[] | 7.352 μs | 0.0174 μs | 0.0163 μs | 0.0076 |      - |     128 B |
