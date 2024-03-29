using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using CoreLib;
namespace Hero
{
	/** This is an automatically generated class by Protocol. Please do not modify it. **/
	public enum MyEnum
	{
		One = 0,
		Two = 1,
	}
	public class HeroInfo:Protocol
	{
		public string Name;
		public List<int> SkillList;
		public int ID;
		public List<ItemInfo> itemInfos;
		public Dictionary<Hero.MyEnum,ItemInfo> KeyValuePairs;
		public int order;
		public HeroInfo()
		{
			Name = string.Empty;
			SkillList = new List<int>();
			ID = default(int);
			itemInfos = new List<ItemInfo>();
			KeyValuePairs = new Dictionary<Hero.MyEnum,ItemInfo>();
			order = default(int);
		}
		public override void Read(byte[] data, ref int offset)
		{
			Name = ByteBuffer.ReadString(data,ref offset);
						{
				List<int> SkillList_temp_list =new List<int>();
				int SkillList_temp_list_count = ByteBuffer.ReadInt(data,ref offset);
				for(int SkillList_index = 0;SkillList_index<SkillList_temp_list_count;SkillList_index++ )
				{
					int SkillList_list_element = default(int);
					SkillList_list_element= ByteBuffer.ReadInt(data,ref offset);
					SkillList_temp_list.Add(SkillList_list_element);
				}
				SkillList.AddRange(SkillList_temp_list);
			}

			ID= ByteBuffer.ReadInt(data,ref offset);
						{
				List<ItemInfo> itemInfos_temp_list =new List<ItemInfo>();
				int itemInfos_temp_list_count = ByteBuffer.ReadInt(data,ref offset);
				for(int itemInfos_index = 0;itemInfos_index<itemInfos_temp_list_count;itemInfos_index++ )
				{
					ItemInfo itemInfos_list_element = new ItemInfo();
									itemInfos_list_element.Read(data,ref offset);

					itemInfos_temp_list.Add(itemInfos_list_element);
				}
				itemInfos.AddRange(itemInfos_temp_list);
			}

						{
				int KeyValuePairs_count= ByteBuffer.ReadInt(data,ref offset);
				for(int KeyValuePairs_index =0;KeyValuePairs_index<KeyValuePairs_count;KeyValuePairs_index++)
				{
					Hero.MyEnum KeyValuePairs_key = default(Hero.MyEnum);
					KeyValuePairs_key = (Hero.MyEnum)ByteBuffer.ReadInt(data,ref offset);
					ItemInfo KeyValuePairs_value = new ItemInfo();
									KeyValuePairs_value.Read(data,ref offset);

					KeyValuePairs.Add(KeyValuePairs_key,KeyValuePairs_value);
				}
			}

			order= ByteBuffer.ReadInt(data,ref offset);
		}
		public override void Write(byte[] data, ref int offset)
		{
			ByteBuffer.WriteString(Name,data,ref offset);
						{
				int SkillList_count = SkillList.Count;
				ByteBuffer.WriteInt(SkillList_count,data,ref offset);
				for(int SkillList_index =0;SkillList_index<SkillList_count;SkillList_index++)
				{
					int SkillList_list_element=SkillList[SkillList_index];
					ByteBuffer.WriteInt(SkillList_list_element,data,ref offset);
				}
			}

			ByteBuffer.WriteInt(ID,data,ref offset);
						{
				int itemInfos_count = itemInfos.Count;
				ByteBuffer.WriteInt(itemInfos_count,data,ref offset);
				for(int itemInfos_index =0;itemInfos_index<itemInfos_count;itemInfos_index++)
				{
					ItemInfo itemInfos_list_element=itemInfos[itemInfos_index];
					itemInfos_list_element.Write(data,ref offset);
				}
			}

						{
				int KeyValuePairs_count = KeyValuePairs.Count;
				ByteBuffer.WriteInt(KeyValuePairs_count,data,ref offset);
				foreach(var KeyValuePairs_item in KeyValuePairs)
				{
					Hero.MyEnum KeyValuePairs_key = KeyValuePairs_item.Key;
					ByteBuffer.WriteInt((int)KeyValuePairs_key,data,ref offset);
					ItemInfo KeyValuePairs_value = KeyValuePairs_item.Value;
					KeyValuePairs_value.Write(data,ref offset);
				}
			}

			ByteBuffer.WriteInt(order,data,ref offset);
		}
	}
	public class ItemInfo:Protocol
	{
		public int id;
		public ItemInfo()
		{
			id = default(int);
		}
		public override void Read(byte[] data, ref int offset)
		{
			id= ByteBuffer.ReadInt(data,ref offset);
		}
		public override void Write(byte[] data, ref int offset)
		{
			ByteBuffer.WriteInt(id,data,ref offset);
		}
	}
}
