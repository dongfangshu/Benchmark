using System.Collections.Generic;

namespace Hero
{
    public enum MyEnum
    {
        One,
        Two,
    }
    public class HeroInfo
    {
        public string Name;
        public List<int> SkillList;
        public int ID;
        public List<ItemInfo> itemInfos;
        public Dictionary<MyEnum, ItemInfo> KeyValuePairs;
		public int order;
    }
    public class ItemInfo
    {
        public in
    }
}