using Binding;
using Net.Serialize;
using Net.System;
using System.Collections.Generic;
public struct Dictionary_SystemInt32_CommitBind_Bind : ISerialize<Dictionary<System.Int32, Commit>>, ISerialize
{
    public void Write(Dictionary<System.Int32, Commit> value, Segment stream)
    {
        int count = value.Count;
        stream.Write(count);
        if (count == 0) return;
        foreach (var value1 in value)
        {
            stream.Write(value1.Key);
            var bind = new CommitBind();
            bind.Write(value1.Value, stream);
        }
    }

    public Dictionary<System.Int32, Commit> Read(Segment stream)
    {
        var count = stream.ReadInt32();
        var value = new Dictionary<System.Int32, Commit>();
        if (count == 0) return value;
        for (int i = 0; i < count; i++)
        {
            var key = stream.ReadInt32();
            var bind = new CommitBind();
            var value1 = bind.Read(stream);
            value.Add(key, value1);
        }
        return value;
    }

    public void WriteValue(object value, Segment stream)
    {
        Write((Dictionary<System.Int32, Commit>)value, stream);
    }

    public object ReadValue(Segment stream)
    {
        return Read(stream);
    }
}