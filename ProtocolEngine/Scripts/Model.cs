using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BenchMark
{
public partial class User
{
    public long ID { get; set; }

    public string Name { get; set; }

    public List<Resources> UserResources { get; set; }

    public Dictionary<string, string> UserResourcesDictionary { get; set; }

    public DateTime DateTime { get; set; }
    //[ProtoMember(6)]
    //public DateTime? DateTime1 { get; set; }

    public int[] IntArray { get; set; }

    public char SingleChar { get; set; }

    public char[] CharArray { get; set; }

    public int Count { get; set; }

    public string Str { get; set; }

    public string Title { get; set; }

    public List<string> Tags { get; set; }

    public bool BoolValue { get; set; }

    public Dictionary<int, Commit> CommitDir { get; set; }

    public TimeSpan TimeSpan { get; set; }

    public Queue<int> Queue { get; set; }

    public Stack<int> Stack { get; set; }

    public LinkedList<int> LinkedList { get; set; }
    //public List<List<int>> DoubleList { get; set; }
    //public int[,] mArray;

}

public partial class Resources
{

    public EResourceType ResourceType;

    public string ResourceName;

    public int ResourceCount;

}

public partial class Commit
{

    public int ID;

    public string Event;

}
public enum EResourceType
{
    Type1,
    Type2,
    Type3,
    Type4,
    Type5,
}}