using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using CoreLib;
namespace CollectionsTest
{
	/** This is an automatically generated class by Protocol. Please do not modify it. **/
	public class ListTest:Protocol
	{
		public List<int> list1;
		public List<List<int>> list2;
		public Dictionary<int,int> dic1;
		public Dictionary<int,Dictionary<int,int>> dic2;
		public List<Dictionary<int,int>> list3;
		public Dictionary<int,List<Dictionary<int,int>>> dic4;
		public ListTest()
		{
			list1 = new List<int>();
			list2 = new List<List<int>>();
			dic1 = new Dictionary<int,int>();
			dic2 = new Dictionary<int,Dictionary<int,int>>();
			list3 = new List<Dictionary<int,int>>();
			dic4 = new Dictionary<int,List<Dictionary<int,int>>>();
		}
		public override void Read(byte[] data, ref int offset)
		{
						{
				List<int> list1_temp_list =new List<int>();
				int list1_temp_list_count = ByteBuffer.ReadInt(data,ref offset);
				for(int list1_index = 0;list1_index<list1_temp_list_count;list1_index++ )
				{
					int list1_list_element = default(int);
					list1_list_element= ByteBuffer.ReadInt(data,ref offset);
					list1_temp_list.Add(list1_list_element);
				}
				list1.AddRange(list1_temp_list);
			}

						{
				List<List<int>> list2_temp_list =new List<List<int>>();
				int list2_temp_list_count = ByteBuffer.ReadInt(data,ref offset);
				for(int list2_index = 0;list2_index<list2_temp_list_count;list2_index++ )
				{
					List<int> list2_list_element = new List<int>();
									{
					List<int> list2_list_element_temp_list =new List<int>();
					int list2_list_element_temp_list_count = ByteBuffer.ReadInt(data,ref offset);
					for(int list2_list_element_index = 0;list2_list_element_index<list2_list_element_temp_list_count;list2_list_element_index++ )
					{
						int list2_list_element_list_element = default(int);
						list2_list_element_list_element= ByteBuffer.ReadInt(data,ref offset);
						list2_list_element_temp_list.Add(list2_list_element_list_element);
					}
					list2_list_element.AddRange(list2_list_element_temp_list);
				}

					list2_temp_list.Add(list2_list_element);
				}
				list2.AddRange(list2_temp_list);
			}

						{
				int dic1_count= ByteBuffer.ReadInt(data,ref offset);
				for(int dic1_index =0;dic1_index<dic1_count;dic1_index++)
				{
					int dic1_key = default(int);
					dic1_key= ByteBuffer.ReadInt(data,ref offset);
					int dic1_value = default(int);
					dic1_value= ByteBuffer.ReadInt(data,ref offset);
					dic1.Add(dic1_key,dic1_value);
				}
			}

						{
				int dic2_count= ByteBuffer.ReadInt(data,ref offset);
				for(int dic2_index =0;dic2_index<dic2_count;dic2_index++)
				{
					int dic2_key = default(int);
					dic2_key= ByteBuffer.ReadInt(data,ref offset);
					Dictionary<int,int> dic2_value = new Dictionary<int,int>();
									{
					int dic2_value_count= ByteBuffer.ReadInt(data,ref offset);
					for(int dic2_value_index =0;dic2_value_index<dic2_value_count;dic2_value_index++)
					{
						int dic2_value_key = default(int);
						dic2_value_key= ByteBuffer.ReadInt(data,ref offset);
						int dic2_value_value = default(int);
						dic2_value_value= ByteBuffer.ReadInt(data,ref offset);
						dic2_value.Add(dic2_value_key,dic2_value_value);
					}
				}

					dic2.Add(dic2_key,dic2_value);
				}
			}

						{
				List<Dictionary<int,int>> list3_temp_list =new List<Dictionary<int,int>>();
				int list3_temp_list_count = ByteBuffer.ReadInt(data,ref offset);
				for(int list3_index = 0;list3_index<list3_temp_list_count;list3_index++ )
				{
					Dictionary<int,int> list3_list_element = new Dictionary<int,int>();
									{
					int list3_list_element_count= ByteBuffer.ReadInt(data,ref offset);
					for(int list3_list_element_index =0;list3_list_element_index<list3_list_element_count;list3_list_element_index++)
					{
						int list3_list_element_key = default(int);
						list3_list_element_key= ByteBuffer.ReadInt(data,ref offset);
						int list3_list_element_value = default(int);
						list3_list_element_value= ByteBuffer.ReadInt(data,ref offset);
						list3_list_element.Add(list3_list_element_key,list3_list_element_value);
					}
				}

					list3_temp_list.Add(list3_list_element);
				}
				list3.AddRange(list3_temp_list);
			}

						{
				int dic4_count= ByteBuffer.ReadInt(data,ref offset);
				for(int dic4_index =0;dic4_index<dic4_count;dic4_index++)
				{
					int dic4_key = default(int);
					dic4_key= ByteBuffer.ReadInt(data,ref offset);
					List<Dictionary<int,int>> dic4_value = new List<Dictionary<int,int>>();
									{
					List<Dictionary<int,int>> dic4_value_temp_list =new List<Dictionary<int,int>>();
					int dic4_value_temp_list_count = ByteBuffer.ReadInt(data,ref offset);
					for(int dic4_value_index = 0;dic4_value_index<dic4_value_temp_list_count;dic4_value_index++ )
					{
						Dictionary<int,int> dic4_value_list_element = new Dictionary<int,int>();
											{
						int dic4_value_list_element_count= ByteBuffer.ReadInt(data,ref offset);
						for(int dic4_value_list_element_index =0;dic4_value_list_element_index<dic4_value_list_element_count;dic4_value_list_element_index++)
						{
							int dic4_value_list_element_key = default(int);
							dic4_value_list_element_key= ByteBuffer.ReadInt(data,ref offset);
							int dic4_value_list_element_value = default(int);
							dic4_value_list_element_value= ByteBuffer.ReadInt(data,ref offset);
							dic4_value_list_element.Add(dic4_value_list_element_key,dic4_value_list_element_value);
						}
					}

						dic4_value_temp_list.Add(dic4_value_list_element);
					}
					dic4_value.AddRange(dic4_value_temp_list);
				}

					dic4.Add(dic4_key,dic4_value);
				}
			}

		}
		public override void Write(byte[] data, ref int offset)
		{
						{
				int list1_count = list1.Count;
				ByteBuffer.WriteInt(list1_count,data,ref offset);
				for(int list1_index =0;list1_index<list1_count;list1_index++)
				{
					int list1_list_element=list1[list1_index];
					ByteBuffer.WriteInt(list1_list_element,data,ref offset);
				}
			}

						{
				int list2_count = list2.Count;
				ByteBuffer.WriteInt(list2_count,data,ref offset);
				for(int list2_index =0;list2_index<list2_count;list2_index++)
				{
					List<int> list2_list_element=list2[list2_index];
								{
				int list2_list_element_count = list2_list_element.Count;
				ByteBuffer.WriteInt(list2_list_element_count,data,ref offset);
				for(int list2_list_element_index =0;list2_list_element_index<list2_list_element_count;list2_list_element_index++)
				{
					int list2_list_element_list_element=list2_list_element[list2_list_element_index];
					ByteBuffer.WriteInt(list2_list_element_list_element,data,ref offset);
				}
			}

				}
			}

						{
				int dic1_count = dic1.Count;
				ByteBuffer.WriteInt(dic1_count,data,ref offset);
				foreach(var dic1_item in dic1)
				{
					int dic1_key = dic1_item.Key;
					ByteBuffer.WriteInt(dic1_key,data,ref offset);
					int dic1_value = dic1_item.Value;
					ByteBuffer.WriteInt(dic1_value,data,ref offset);
				}
			}

						{
				int dic2_count = dic2.Count;
				ByteBuffer.WriteInt(dic2_count,data,ref offset);
				foreach(var dic2_item in dic2)
				{
					int dic2_key = dic2_item.Key;
					ByteBuffer.WriteInt(dic2_key,data,ref offset);
					Dictionary<int,int> dic2_value = dic2_item.Value;
								{
				int dic2_value_count = dic2_value.Count;
				ByteBuffer.WriteInt(dic2_value_count,data,ref offset);
				foreach(var dic2_value_item in dic2_value)
				{
					int dic2_value_key = dic2_value_item.Key;
					ByteBuffer.WriteInt(dic2_value_key,data,ref offset);
					int dic2_value_value = dic2_value_item.Value;
					ByteBuffer.WriteInt(dic2_value_value,data,ref offset);
				}
			}

				}
			}

						{
				int list3_count = list3.Count;
				ByteBuffer.WriteInt(list3_count,data,ref offset);
				for(int list3_index =0;list3_index<list3_count;list3_index++)
				{
					Dictionary<int,int> list3_list_element=list3[list3_index];
								{
				int list3_list_element_count = list3_list_element.Count;
				ByteBuffer.WriteInt(list3_list_element_count,data,ref offset);
				foreach(var list3_list_element_item in list3_list_element)
				{
					int list3_list_element_key = list3_list_element_item.Key;
					ByteBuffer.WriteInt(list3_list_element_key,data,ref offset);
					int list3_list_element_value = list3_list_element_item.Value;
					ByteBuffer.WriteInt(list3_list_element_value,data,ref offset);
				}
			}

				}
			}

						{
				int dic4_count = dic4.Count;
				ByteBuffer.WriteInt(dic4_count,data,ref offset);
				foreach(var dic4_item in dic4)
				{
					int dic4_key = dic4_item.Key;
					ByteBuffer.WriteInt(dic4_key,data,ref offset);
					List<Dictionary<int,int>> dic4_value = dic4_item.Value;
								{
				int dic4_value_count = dic4_value.Count;
				ByteBuffer.WriteInt(dic4_value_count,data,ref offset);
				for(int dic4_value_index =0;dic4_value_index<dic4_value_count;dic4_value_index++)
				{
					Dictionary<int,int> dic4_value_list_element=dic4_value[dic4_value_index];
								{
				int dic4_value_list_element_count = dic4_value_list_element.Count;
				ByteBuffer.WriteInt(dic4_value_list_element_count,data,ref offset);
				foreach(var dic4_value_list_element_item in dic4_value_list_element)
				{
					int dic4_value_list_element_key = dic4_value_list_element_item.Key;
					ByteBuffer.WriteInt(dic4_value_list_element_key,data,ref offset);
					int dic4_value_list_element_value = dic4_value_list_element_item.Value;
					ByteBuffer.WriteInt(dic4_value_list_element_value,data,ref offset);
				}
			}

				}
			}

				}
			}

		}
	}
}
