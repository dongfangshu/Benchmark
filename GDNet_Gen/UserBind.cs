using Net.Serialize;
using Net.System;
using System;
using System.Collections.Generic;

namespace Binding
{
    public struct UserBind : ISerialize<User>, ISerialize
    {
        public void Write(User value, Segment stream)
        {
            int pos = stream.Position;
            stream.Position += 3;
            byte[] bits = new byte[3];

            if (value.ID != 0)
            {
                NetConvertBase.SetBit(ref bits[0], 1, true);
                stream.Write(value.ID);
            }

            if (!string.IsNullOrEmpty(value.Name))
            {
                NetConvertBase.SetBit(ref bits[0], 2, true);
                stream.Write(value.Name);
            }

			if(value.UserResources != null)
			{
				NetConvertBase.SetBit(ref bits[0], 3, true);
				var bind = new ResourcesGenericBind();
				bind.Write(value.UserResources, stream);
			}

			if(value.UserResourcesDictionary != null)
			{
				NetConvertBase.SetBit(ref bits[0], 4, true);
				var bind = new DictionaryBind<System.String, System.String>();
				bind.Write(value.UserResourcesDictionary, stream, new BaseBind<System.String>());
			}

            if (value.DateTime != default)
            {
                NetConvertBase.SetBit(ref bits[0], 5, true);
                stream.Write(value.DateTime);
            }

            if (value.IntArray != null)
            {
                NetConvertBase.SetBit(ref bits[0], 6, true);
                stream.Write(value.IntArray);
            }

            if (value.SingleChar != 0)
            {
                NetConvertBase.SetBit(ref bits[0], 7, true);
                stream.Write(value.SingleChar);
            }

            if (value.CharArray != null)
            {
                NetConvertBase.SetBit(ref bits[0], 8, true);
                stream.Write(value.CharArray);
            }

            if (value.Count != 0)
            {
                NetConvertBase.SetBit(ref bits[1], 1, true);
                stream.Write(value.Count);
            }

            if (!string.IsNullOrEmpty(value.Str))
            {
                NetConvertBase.SetBit(ref bits[1], 2, true);
                stream.Write(value.Str);
            }

            if (!string.IsNullOrEmpty(value.Title))
            {
                NetConvertBase.SetBit(ref bits[1], 3, true);
                stream.Write(value.Title);
            }

            if (value.Tags != null)
            {
                NetConvertBase.SetBit(ref bits[1], 4, true);
                stream.Write(value.Tags);
            }

            if (value.BoolValue != false)
            {
                NetConvertBase.SetBit(ref bits[1], 5, true);
                stream.Write(value.BoolValue);
            }

			if(value.CommitDir != null)
			{
				NetConvertBase.SetBit(ref bits[1], 6, true);
				var bind = new DictionaryBind<System.Int32, Commit>();
				bind.Write(value.CommitDir, stream, new CommitBind());
			}

			//if(value.V1 != default(UnityEngine.Vector3))
			//{
			//	NetConvertBase.SetBit(ref bits[1], 7, true);
			//	var bind = new UnityEngineVector3Bind();
			//	bind.Write(value.V1, stream);
			//}

			//if(value.V2 != default(UnityEngine.Vector3))
			//{
			//	NetConvertBase.SetBit(ref bits[1], 8, true);
			//	var bind = new UnityEngineVector3Bind();
			//	bind.Write(value.V2, stream);
			//}

			if(value.TimeSpan != default(System.TimeSpan))
			{
				NetConvertBase.SetBit(ref bits[2], 1, true);
				var bind = new SystemTimeSpanBind();
				bind.Write(value.TimeSpan, stream);
			}

			if(value.Queue != null)
			{
				NetConvertBase.SetBit(ref bits[2], 2, true);
				var bind = new SystemCollectionsGenericQueueSystemInt32Bind();
				bind.Write(value.Queue, stream);
			}

			if(value.Stack != null)
			{
				NetConvertBase.SetBit(ref bits[2], 3, true);
				var bind = new SystemCollectionsGenericStackSystemInt32Bind();
				bind.Write(value.Stack, stream);
			}

			if(value.LinkedList != null)
			{
				NetConvertBase.SetBit(ref bits[2], 4, true);
				var bind = new SystemCollectionsGenericLinkedListSystemInt32Bind();
				bind.Write(value.LinkedList, stream);
			}

            int pos1 = stream.Position;
            stream.Position = pos;
            stream.Write(bits, 0, 3);
            stream.Position = pos1;
        }
		
		public User Read(Segment stream)
		{
			byte[] bits = stream.Read(3);
			var value = new User();

			if(NetConvertBase.GetBit(bits[0], 1))
				value.ID = stream.ReadInt64();

			if(NetConvertBase.GetBit(bits[0], 2))
				value.Name = stream.ReadString();

			if(NetConvertBase.GetBit(bits[0], 3))
			{
				var bind = new ResourcesGenericBind();
				value.UserResources = bind.Read(stream);
			}

			if(NetConvertBase.GetBit(bits[0], 4))
			{
				var bind = new DictionaryBind<System.String, System.String>();
				value.UserResourcesDictionary = bind.Read(stream, new BaseBind<System.String>());
			}

			if(NetConvertBase.GetBit(bits[0], 5))
				value.DateTime = stream.ReadDateTime();

			if(NetConvertBase.GetBit(bits[0], 6))
				value.IntArray = stream.ReadInt32Array();

			if(NetConvertBase.GetBit(bits[0], 7))
				value.SingleChar = stream.ReadChar();

			if(NetConvertBase.GetBit(bits[0], 8))
				value.CharArray = stream.ReadCharArray();

			if(NetConvertBase.GetBit(bits[1], 1))
				value.Count = stream.ReadInt32();

			if(NetConvertBase.GetBit(bits[1], 2))
				value.Str = stream.ReadString();

			if(NetConvertBase.GetBit(bits[1], 3))
				value.Title = stream.ReadString();

			if(NetConvertBase.GetBit(bits[1], 4))
				value.Tags = stream.ReadStringGeneric<System.Collections.Generic.List<System.String>>();

			if(NetConvertBase.GetBit(bits[1], 5))
				value.BoolValue = stream.ReadBoolean();

			if(NetConvertBase.GetBit(bits[1], 6))
			{
				var bind = new DictionaryBind<System.Int32, Commit>();
				value.CommitDir = bind.Read(stream, new CommitBind());
			}

			//if(NetConvertBase.GetBit(bits[1], 7))
			//{
			//	var bind = new UnityEngineVector3Bind();
			//	value.V1 = bind.Read(stream);
			//}

			//if(NetConvertBase.GetBit(bits[1], 8))
			//{
			//	var bind = new UnityEngineVector3Bind();
			//	value.V2 = bind.Read(stream);
			//}

			if(NetConvertBase.GetBit(bits[2], 1))
			{
				var bind = new SystemTimeSpanBind();
				value.TimeSpan = bind.Read(stream);
			}

			if(NetConvertBase.GetBit(bits[2], 2))
			{
				var bind = new SystemCollectionsGenericQueueSystemInt32Bind();
				value.Queue = bind.Read(stream);
			}

			if(NetConvertBase.GetBit(bits[2], 3))
			{
				var bind = new SystemCollectionsGenericStackSystemInt32Bind();
				value.Stack = bind.Read(stream);
			}

			if(NetConvertBase.GetBit(bits[2], 4))
			{
				var bind = new SystemCollectionsGenericLinkedListSystemInt32Bind();
				value.LinkedList = bind.Read(stream);
			}

			return value;
		}

        public void WriteValue(object value, Segment stream)
        {
            Write((User)value, stream);
        }

        public object ReadValue(Segment stream)
        {
            return Read(stream);
        }
    }
}

namespace Binding
{
	public struct UserArrayBind : ISerialize<User[]>, ISerialize
	{
		public void Write(User[] value, Segment stream)
		{
			int count = value.Length;
			stream.Write(count);
			if (count == 0) return;
			var bind = new UserBind();
			foreach (var value1 in value)
				bind.Write(value1, stream);
		}

		public User[] Read(Segment stream)
		{
			var count = stream.ReadInt32();
			var value = new User[count];
			if (count == 0) return value;
			var bind = new UserBind();
			for (int i = 0; i < count; i++)
				value[i] = bind.Read(stream);
			return value;
		}

		public void WriteValue(object value, Segment stream)
		{
			Write((User[])value, stream);
		}

		public object ReadValue(Segment stream)
		{
			return Read(stream);
		}
	}
}
namespace Binding
{
	public struct UserGenericBind : ISerialize<List<User>>, ISerialize
	{
		public void Write(List<User> value, Segment stream)
		{
			int count = value.Count;
			stream.Write(count);
			if (count == 0) return;
			var bind = new UserBind();
			foreach (var value1 in value)
				bind.Write(value1, stream);
		}

		public List<User> Read(Segment stream)
		{
			var count = stream.ReadInt32();
			var value = new List<User>(count);
			if (count == 0) return value;
			var bind = new UserBind();
			for (int i = 0; i < count; i++)
				value.Add(bind.Read(stream));
			return value;
		}

		public void WriteValue(object value, Segment stream)
		{
			Write((List<User>)value, stream);
		}

		public object ReadValue(Segment stream)
		{
			return Read(stream);
		}
	}
}