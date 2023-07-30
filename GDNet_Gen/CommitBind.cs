using Net.Serialize;
using Net.System;
using System;
using System.Collections.Generic;

namespace Binding
{
    public struct CommitBind : ISerialize<Commit>, ISerialize
    {
        public void Write(Commit value, Segment stream)
        {
            int pos = stream.Position;
            stream.Position += 1;
            byte[] bits = new byte[1];

            if (value.ID != 0)
            {
                NetConvertBase.SetBit(ref bits[0], 1, true);
                stream.Write(value.ID);
            }

            if (!string.IsNullOrEmpty(value.Event))
            {
                NetConvertBase.SetBit(ref bits[0], 2, true);
                stream.Write(value.Event);
            }

            int pos1 = stream.Position;
            stream.Position = pos;
            stream.Write(bits, 0, 1);
            stream.Position = pos1;
        }
		
		public Commit Read(Segment stream)
		{
			byte[] bits = stream.Read(1);
			var value = new Commit();

			if(NetConvertBase.GetBit(bits[0], 1))
				value.ID = stream.ReadInt32();

			if(NetConvertBase.GetBit(bits[0], 2))
				value.Event = stream.ReadString();

			return value;
		}

        public void WriteValue(object value, Segment stream)
        {
            Write((Commit)value, stream);
        }

        public object ReadValue(Segment stream)
        {
            return Read(stream);
        }
    }
}

namespace Binding
{
	public struct CommitArrayBind : ISerialize<Commit[]>, ISerialize
	{
		public void Write(Commit[] value, Segment stream)
		{
			int count = value.Length;
			stream.Write(count);
			if (count == 0) return;
			var bind = new CommitBind();
			foreach (var value1 in value)
				bind.Write(value1, stream);
		}

		public Commit[] Read(Segment stream)
		{
			var count = stream.ReadInt32();
			var value = new Commit[count];
			if (count == 0) return value;
			var bind = new CommitBind();
			for (int i = 0; i < count; i++)
				value[i] = bind.Read(stream);
			return value;
		}

		public void WriteValue(object value, Segment stream)
		{
			Write((Commit[])value, stream);
		}

		public object ReadValue(Segment stream)
		{
			return Read(stream);
		}
	}
}
namespace Binding
{
	public struct CommitGenericBind : ISerialize<List<Commit>>, ISerialize
	{
		public void Write(List<Commit> value, Segment stream)
		{
			int count = value.Count;
			stream.Write(count);
			if (count == 0) return;
			var bind = new CommitBind();
			foreach (var value1 in value)
				bind.Write(value1, stream);
		}

		public List<Commit> Read(Segment stream)
		{
			var count = stream.ReadInt32();
			var value = new List<Commit>(count);
			if (count == 0) return value;
			var bind = new CommitBind();
			for (int i = 0; i < count; i++)
				value.Add(bind.Read(stream));
			return value;
		}

		public void WriteValue(object value, Segment stream)
		{
			Write((List<Commit>)value, stream);
		}

		public object ReadValue(Segment stream)
		{
			return Read(stream);
		}
	}
}