using Net.System;
using Net.Serialize;

namespace Binding
{
	public struct SystemCollectionsGenericStackSystemInt32Bind : ISerialize<System.Collections.Generic.Stack<System.Int32>>, ISerialize
	{
		public void Write(System.Collections.Generic.Stack<System.Int32> value, Segment stream)
		{
			int count = value.Count;
			stream.Write(count);
			if (count == 0) return;
			var bind = new SystemInt32Bind();
			foreach (var value1 in value)
				bind.Write(value1, stream);
		}

		public System.Collections.Generic.Stack<System.Int32> Read(Segment stream)
		{
			var count = stream.ReadInt32();
			var value = new System.Collections.Generic.Stack<System.Int32>(count);
			if (count == 0) return value;
			var bind = new SystemInt32Bind();
			for (int i = 0; i < count; i++)
				value.Push(bind.Read(stream));
			return value;
		}

		public void WriteValue(object value, Segment stream)
		{
			Write((System.Collections.Generic.Stack<System.Int32>)value, stream);
		}

		public object ReadValue(Segment stream)
		{
			return Read(stream);
		}
	}
}