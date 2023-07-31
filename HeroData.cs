
using System.Collections.Generic;
namespace JsonBenchMark
{


    public class Data1
    {
        public string str1 { get; set; }
        public bool b1 { get; set; }
        public int i1 { get; set; }
        public int i2
        {
            get; set;
        }
        public Data2 d2 { get; set; }
        public Data3 d3 { get; set; }
        public List<Data4> d4 { get; set; }
        public Data5 d5 { get; set; }
        public Data7 d7 { get; set; }
        public List<Data8> d8 { get; set; }
        public int i3 { get; set; }
        public bool b2 { get; set; }
    }
    public class Data2
    {
        public int i1 { get; set; }
        public int i2 { get; set; }
        public int i3 { get; set; }
        public Data9 d9 { get; set; }

        public int i4 { get; set; }
        public int i5 { get; set; }
        public int i6 { get; set; }
        public int i7 { get; set; }
        public int i8 { get; set; }

        //升级的所有属性加成
        public int i9 { get; set; }
        public int i10 { get; set; }
        public int i11 { get; set; }
        public int i12 { get; set; }
        public int i13 { get; set; }
    }
    public class Data4
    {
        public string str1 { get; set; } // id
        public string str2 { get; set; } // 配置表id
        public bool b1 { get; set; } // 锁定状态
        public int i1 { get; set; } // 等级
        public string str3 { get; set; } // 角色id
    }
    public class Data3
    {
        public Vector3 v1 { get; set; }
        public Vector3 v2 { get; set; }
        public Vector3 v3 { get; set; }
        public Vector3 v4 { get; set; }
        public Vector3 v5 { get; set; }

        public int i1 { get; set; }
        public int i2 { get; set; }
        public int i3 { get; set; }
        public int i4 { get; set; }
        public int i5 { get; set; }
    }
    public class Vector3
    {
        public float X { get; set; }
        public float Y
        {
            get; set;
        }
        public float Z
        {
            get; set;
        }
    }
    public class Data5
    {
        public string str1;
        public string str2;
        public bool b1
        {
            get; set;
        }
        public int i1
        {
            get; set;
        }
        public int i2
        {
            get; set;
        }
        public int i3
        {
            get; set;
        }
        public string str3;

        public int i4
        {
            get; set;
        }
        public bool b2
        {
            get; set;
        }
        public long l1
        {
            get; set;
        }
        public int i5
        {
            get; set;
        }
        public int i6
        {
            get; set;
        }
        public Data6 d6;

    }
    public class Data6
    {
        public string s1;
        public string s2;
        public string s3;
        public string s4;
        public string s5;
        public string s6;

    }
    public class Data7
    {
        public string str1;
        public List<string> list1;
        public List<string> list2;
        public List<string> list3;
        public List<string> list4;
        public List<string> list5;
    }
    public class Data8
    {
        public int i1
        {
            get; set;
        }
        public int i2
        {
            get; set;
        }
        public float f1
        {
            get; set;
        }
        public float f2
        {
            get; set;
        }
    }
    public class Data9
    {
        public DataType1 e1
        {
            get; set;
        }
        public string s1;
        public string s2;
        public long l1
        {
            get; set;
        }
    }
    public enum DataType1
    {
        t1 = 0,
        t2 = 1,
        t3 = 2,
        t4 = 3,
        t5 = 4,
        t6 = 5,
        t7 = 6,
        t8 = 7,
    }


}