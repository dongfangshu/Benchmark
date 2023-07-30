using MemoryPack;

[MemoryPackable]
public partial class Person
{
    public int Age { get; set; }
    public string Name { get; set; }
    public int Age1 { get; set; }
    public string Name1 { get; set; }
    public int Age2 { get; set; }
    public string Name2 { get; set; }
    public int Age3 { get; set; }
    public string Name3 { get; set; }

    public Person person { get; set; }
}

[MemoryPackable]
public partial class Test
{
    public byte f1;
    public sbyte f2;
    public bool f3;
    public short f4;
    public ushort f5;
    public char f6;
    public int f7;
    public uint f8;
    public float f9;
    public long f10;
    public ulong f11;
    public double f12;
    public DateTime f13;
    public decimal f14;
    public string f15;

    public byte[] fa1;
    public sbyte[] fa2;
    public bool[] fa3;
    public short[] fa4;
    public ushort[] fa5;
    public char[] fa6;
    public int[] fa7;
    public uint[] fa8;
    public float[] fa9;
    public long[] fa10;
    public ulong[] fa11;
    public double[] fa12;
    public DateTime[] fa13;
    public decimal[] fa14;
    public string[] fa15;

    public List<byte> fl1;
    public List<sbyte> fl2;
    public List<bool> fl3;
    public List<short> fl4;
    public List<ushort> fl5;
    public List<char> fl6;
    public List<int> fl7;
    public List<uint> fl8;
    public List<float> fl9;
    public List<long> fl10;
    public List<ulong> fl11;
    public List<double> fl12;
    public List<DateTime> fl13;
    public List<decimal> fl14;
    public List<string> fl15;

    public Dictionary<int, byte> fd1;
    public Dictionary<int, sbyte> fd2;
    public Dictionary<int, bool> fd3;
    public Dictionary<int, short> fd4;
    public Dictionary<int, ushort> fd5;
    public Dictionary<int, char> fd6;
    public Dictionary<int, int> fd7;
    public Dictionary<int, uint> fd8;
    public Dictionary<int, float> fd9;
    public Dictionary<int, long> fd10;
    public Dictionary<int, ulong> fd11;
    public Dictionary<int, double> fd12;
    public Dictionary<int, DateTime> fd13;
    public Dictionary<int, decimal> fd14;
    public Dictionary<int, string> fd15;

    //public Dictionary<int, byte[]> f1;
    //public Dictionary<int, sbyte[]> f2;
    //public Dictionary<int, bool[]> f3;
    //public Dictionary<int, short[]> f4;
    //public Dictionary<int, ushort[]> f5;
    //public Dictionary<int, char[]> f6;
    //public Dictionary<int, int[]> f7;
    //public Dictionary<int, uint[]> f8;
    //public Dictionary<int, float[]> f9;
    //public Dictionary<int, long[]> f10;
    //public Dictionary<int, ulong[]> f11;
    //public Dictionary<int, double[]> f12;
    //public Dictionary<int, DateTime[]> f13;
    //public Dictionary<int, decimal[]> f14;
    //public Dictionary<int, string[]> f15;

    //public Dictionary<int, List<byte>> f1;
    //public Dictionary<int, List<sbyte>> f2;
    //public Dictionary<int, List<bool>> f3;
    //public Dictionary<int, List<short>> f4;
    //public Dictionary<int, List<ushort>> f5;
    //public Dictionary<int, List<char>> f6;
    //public Dictionary<int, List<int>> f7;
    //public Dictionary<int, List<uint>> f8;
    //public Dictionary<int, List<float>> f9;
    //public Dictionary<int, List<long>> f10;
    //public Dictionary<int, List<ulong>> f11;
    //public Dictionary<int, List<double>> f12;
    //public Dictionary<int, List<DateTime>> f13;
    //public Dictionary<int, List<decimal>> f14;
    //public Dictionary<int, List<string>> f15;

    //public Dictionary<int, Vector3> f1;
}