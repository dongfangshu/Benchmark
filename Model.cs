using MemoryPack;
using Net;
using ProtoBuf;
using System.Reflection;
using System.Security.AccessControl;
using UnityEngine;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;


[ProtoContract]
[MemoryPackable]
public partial class User
{
    [ProtoMember(1)]
    public long ID { get; set; }
    [ProtoMember(2)]
    public string Name { get; set; }
    [ProtoMember(3)]
    public List<Resources> UserResources { get; set; }
    [ProtoMember(4)]
    public Dictionary<string, string> UserResourcesDictionary { get; set; }
    [ProtoMember(5)]
    public DateTime DateTime { get; set; }
    //[ProtoMember(6)]
    //public DateTime? DateTime1 { get; set; }
    [ProtoMember(7)]
    public int[] IntArray { get; set; }
    [ProtoMember(8)]
    public char SingleChar { get; set; }
    [ProtoMember(9)]
    public char[] CharArray { get; set; }
    [ProtoMember(10)]
    public int Count { get; set; }
    [ProtoMember(11)]
    public string Str { get; set; }
    [ProtoMember(12)]
    public string Title { get; set; }
    [ProtoMember(13)]
    public List<string> Tags { get; set; }
    [ProtoMember(14)]
    public bool BoolValue { get; set; }
    [ProtoMember(15)]
    public Dictionary<int, Commit> CommitDir { get; set; }
    [ProtoMember(16)]
    public TimeSpan TimeSpan { get; set; }
    [ProtoMember(17)]
    public Queue<int> Queue { get; set; }
    [ProtoMember(18)]
    public Stack<int> Stack { get; set; }
    [ProtoMember(19)]
    public LinkedList<int> LinkedList { get; set; }
    //public List<List<int>> DoubleList { get; set; }
    //public int[,] mArray;
    public override bool Equals(object? obj)
    {
        User user = obj as User;
        if (user == null)
        {
            return false;
        }
        if (!ID.Equals(user.ID))
        {
            return false;
        }
        if (!Name.Equals(user.Name))
        {
            return false;
        }
        if (!UserResources.TryListEquals(user.UserResources))
        {
            return false;
        }
        if (!UserResourcesDictionary.TryDictionaryEquals(user.UserResourcesDictionary))
        {
            return false;
        }
        if (!DateTime.Equals(user.DateTime))
        {
            return false;
        }
        //if (!DateTime1.Equals(user.DateTime1))
        //{
        //    return false;
        //}
        if (!IntArray.TryArrayEquals(user.IntArray))
        {
            return false;
        }
        if (!SingleChar.Equals(user.SingleChar))
        {
            return false;
        }
        if (!CharArray.TryArrayEquals(user.CharArray))
        {
            return false;
        }
        if (!Count.Equals(user.Count))
        {
            return false;
        }
        if (!Str.Equals(user.Str))
        {
            return false;
        }
        if (!Title.Equals(user.Title))
        {
            return false;
        }
        
        if (!Tags.TryListEquals(user.Tags))
        {
            return false;
        }
        if (!BoolValue.Equals(user.BoolValue))
        {
            return false;
        }
        if (!CommitDir.TryDictionaryEquals(user.CommitDir))
        {
            return false;
        }
        if (!TimeSpan.Equals(user.TimeSpan))
        {
            return false;
        }
        if (!Queue.TryQueueEquals(user.Queue))
        {
            return false;
        }
        if (!Stack.TryStackEquals(user.Stack))
        {
            return false;
        }
        if (!LinkedList.TryLinkedListEquals(user.LinkedList))
        {
            return false;
        }
        return true;
    }

}
[ProtoContract]
[MemoryPackable]
public partial class Resources
{
    [ProtoMember(1)]
    public EResourceType ResourceType { get; set; }
    [ProtoMember(2)]
    public string ResourceName { get; set; }
    [ProtoMember(3)]
    public int ResourceCount { get; set; }
    public override bool Equals(object? obj)
    {
        Resources resources = obj as Resources;
        if (resources == null)
        {
            return false;
        }
        if (ResourceType!= resources.ResourceType)
        {
            return false;
        }
        if (resources.ResourceCount != ResourceCount)
        {
            return false;
        }
        if (ResourceName!= resources.ResourceName)
        {
            return false;
        }
        return true;
    }
}
[ProtoContract]
[MemoryPackable]
public partial class Commit
{
    [ProtoMember(1)]
    public int ID { get; set; }
    [ProtoMember(2)]
    public string Event { get; set; }
    public override bool Equals(object? obj)
    {
        Commit commit = obj as Commit;
        if (commit == null)
        {
            return false;
        }
        if (ID != commit.ID)
        {
            return false;
        }
        if (commit.Event != Event)
        {
            return false;
        }
        return true;
    }
}
public enum EResourceType
{
    Type1,
    Type2,
    Type3,
    Type4,
    Type5,
}




