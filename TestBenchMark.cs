using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TestBenchMark
{
    int Count=0;
    [Benchmark]
    public void Test()
    {
        Count++;
        Console.WriteLine(Count);
    }
}
