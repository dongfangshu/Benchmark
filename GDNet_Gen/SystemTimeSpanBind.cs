using Net.Serialize;
using Net.System;
using System;
using System.Collections.Generic;

namespace Binding
{
    public struct SystemTimeSpanBind : ISerialize<System.TimeSpan>, ISerialize
    {
        public void Write(System.TimeSpan value, Segment stream)
        {
            int pos = stream.Position;
            stream.Position += 1;
            byte[] bits = new byte[1];

            int pos1 = stream.Position;
            stream.Position = pos;
            stream.Write(bits, 0, 1);
            stream.Position = pos1;
        }
		
		public System.TimeSpan Read(Segment stream)
		{
			byte[] bits = stream.Read(1);
			var value = new System.TimeSpan();

			return value;
		}

        public void WriteValue(object value, Segment stream)
        {
            Write((System.TimeSpan)value, stream);
        }

        public object ReadValue(Segment stream)
        {
            return Read(stream);
        }
    }
}

namespace Binding
{
	public struct SystemTimeSpanArrayBind : ISerialize<System.TimeSpan[]>, ISerialize
	{
		public void Write(System.TimeSpan[] value, Segment stream)
		{
			int count = value.Length;
			stream.Write(count);
			if (count == 0) return;
			var bind = new SystemTimeSpanBind();
			foreach (var value1 in value)
				bind.Write(value1, stream);
		}

		public System.TimeSpan[] Read(Segment stream)
		{
			var count = stream.ReadInt32();
			var value = new System.TimeSpan[count];
			if (count == 0) return value;
			var bind = new SystemTimeSpanBind();
			for (int i = 0; i < count; i++)
				value[i] = bind.Read(stream);
			return value;
		}

		public void WriteValue(object value, Segment stream)
		{
			Write((System.TimeSpan[])value, stream);
		}

		public object ReadValue(Segment stream)
		{
			return Read(stream);
		}
	}
}
namespace Binding
{
	public struct SystemTimeSpanGenericBind : ISerialize<List<System.TimeSpan>>, ISerialize
	{
		public void Write(List<System.TimeSpan> value, Segment stream)
		{
			int count = value.Count;
			stream.Write(count);
			if (count == 0) return;
			var bind = new SystemTimeSpanBind();
			foreach (var value1 in value)
				bind.Write(value1, stream);
		}

		public List<System.TimeSpan> Read(Segment stream)
		{
			var count = stream.ReadInt32();
			var value = new List<System.TimeSpan>(count);
			if (count == 0) return value;
			var bind = new SystemTimeSpanBind();
			for (int i = 0; i < count; i++)
				value.Add(bind.Read(stream));
			return value;
		}

		public void WriteValue(object value, Segment stream)
		{
			Write((List<System.TimeSpan>)value, stream);
		}

		public object ReadValue(Segment stream)
		{
			return Read(stream);
		}
	}
}