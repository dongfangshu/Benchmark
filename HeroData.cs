
using System.Collections.Generic;
namespace JsonBenchMark
{


    public class Data1
    {
        public string str1;
        public bool b1;
        public int i1;
        public int i2;
        public Data2 d2;
        public Data3 d3;
        public List<Data4> d4;
        public Data5 d5;
        public Data7 d7;
        public List<Data8> d8;
        public int i3;
        public bool b2;
    }
    public class Data2
    {
        public int i1;
        public int i2;
        public int i3;
        public Data9 d9;

        public int i4;
        public int i5;
        public int i6;
        public int i7;
        public int i8;

        //升级的所有属性加成
        public int i9;
        public int i10;
        public int i11;
        public int i12;
        public int i13;
    }
    public class Data4
    {
        public string str1; // id
        public string str2; // 配置表id
        public bool b1; // 锁定状态
        public int i1; // 等级
        public string str3; // 角色id
    }
    public class Data3
    {
        public Vector3 v1;
        public Vector3 v2;
        public Vector3 v3;
        public Vector3 v4;
        public Vector3 v5;

        public int i1;
        public int i2;
        public int i3;
        public int i4;
        public int i5;
    }
    public class Vector3
    {
        public float X;
        public float Y;
        public float Z;
    }
    public class Data5
    {
        public string str1;
        public string str2;
        public bool b1;
        public int i1;
        public int i2;
        public int i3;
        public string str3;

        public int i4;
        public bool b2;
        public long l1;
        public int i5;
        public int i6;
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
        public int i1;
        public int i2;
        public float f1;
        public float f2;
    }
    public class Data9
    {
        public DataType1 e1;
        public string s1;
        public string s2;
        public long l1;
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