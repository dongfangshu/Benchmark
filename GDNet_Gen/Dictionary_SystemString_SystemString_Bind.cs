using Binding;
using Net.Serialize;
using Net.System;
using System.Collections.Generic;
public struct Dictionary_SystemString_SystemString_Bind : ISerialize<Dictionary<System.String, System.String>>, ISerialize
{
    public void Write(Dictionary<System.String, System.String> value, Segment stream)
    {
        int count = value.Count;
        stream.Write(count);
        if (count == 0) return;
        foreach (var value1 in value)
        {
            stream.Write(value1.Key);
            var bind = new BaseBind<System.String>();
            bind.Write(value1.Value, stream);
        }
    }

    public Dictionary<System.String, System.String> Read(Segment stream)
    {
        var count = stream.ReadInt32();
        var value = new Dictionary<System.String, System.String>();
        if (count == 0) return value;
        for (int i = 0; i < count; i++)
        {
            var key = stream.ReadString();
            var bind = new BaseBind<System.String>();
            var value1 = bind.Read(stream);
            value.Add(key, value1);
        }
        return value;
    }

    public void WriteValue(object value, Segment stream)
    {
        Write((Dictionary<System.String, System.String>)value, stream);
    }

    public object ReadValue(Segment stream)
    {
        return Read(stream);
    }
}