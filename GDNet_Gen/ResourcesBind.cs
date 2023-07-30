using Net.Serialize;
using Net.System;
using System;
using System.Collections.Generic;

namespace Binding
{
    public struct ResourcesBind : ISerialize<Resources>, ISerialize
    {
        public void Write(Resources value, Segment stream)
        {
            int pos = stream.Position;
            stream.Position += 1;
            byte[] bits = new byte[1];

            if (value.ResourceType != 0)
            {
                NetConvertBase.SetBit(ref bits[0], 1, true);
                stream.Write(value.ResourceType);
            }

            if (!string.IsNullOrEmpty(value.ResourceName))
            {
                NetConvertBase.SetBit(ref bits[0], 2, true);
                stream.Write(value.ResourceName);
            }

            if (value.ResourceCount != 0)
            {
                NetConvertBase.SetBit(ref bits[0], 3, true);
                stream.Write(value.ResourceCount);
            }

            int pos1 = stream.Position;
            stream.Position = pos;
            stream.Write(bits, 0, 1);
            stream.Position = pos1;
        }
		
		public Resources Read(Segment stream)
		{
			byte[] bits = stream.Read(1);
			var value = new Resources();

			if(NetConvertBase.GetBit(bits[0], 1))
				value.ResourceType = stream.ReadEnum<EResourceType>();

			if(NetConvertBase.GetBit(bits[0], 2))
				value.ResourceName = stream.ReadString();

			if(NetConvertBase.GetBit(bits[0], 3))
				value.ResourceCount = stream.ReadInt32();

			return value;
		}

        public void WriteValue(object value, Segment stream)
        {
            Write((Resources)value, stream);
        }

        public object ReadValue(Segment stream)
        {
            return Read(stream);
        }
    }
}

namespace Binding
{
	public struct ResourcesArrayBind : ISerialize<Resources[]>, ISerialize
	{
		public void Write(Resources[] value, Segment stream)
		{
			int count = value.Length;
			stream.Write(count);
			if (count == 0) return;
			var bind = new ResourcesBind();
			foreach (var value1 in value)
				bind.Write(value1, stream);
		}

		public Resources[] Read(Segment stream)
		{
			var count = stream.ReadInt32();
			var value = new Resources[count];
			if (count == 0) return value;
			var bind = new ResourcesBind();
			for (int i = 0; i < count; i++)
				value[i] = bind.Read(stream);
			return value;
		}

		public void WriteValue(object value, Segment stream)
		{
			Write((Resources[])value, stream);
		}

		public object ReadValue(Segment stream)
		{
			return Read(stream);
		}
	}
}
namespace Binding
{
	public struct ResourcesGenericBind : ISerialize<List<Resources>>, ISerialize
	{
		public void Write(List<Resources> value, Segment stream)
		{
			int count = value.Count;
			stream.Write(count);
			if (count == 0) return;
			var bind = new ResourcesBind();
			foreach (var value1 in value)
				bind.Write(value1, stream);
		}

		public List<Resources> Read(Segment stream)
		{
			var count = stream.ReadInt32();
			var value = new List<Resources>(count);
			if (count == 0) return value;
			var bind = new ResourcesBind();
			for (int i = 0; i < count; i++)
				value.Add(bind.Read(stream));
			return value;
		}

		public void WriteValue(object value, Segment stream)
		{
			Write((List<Resources>)value, stream);
		}

		public object ReadValue(Segment stream)
		{
			return Read(stream);
		}
	}
}