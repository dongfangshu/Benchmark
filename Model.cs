using MemoryPack;

namespace TestConsole
{
    [MemoryPackable]
    public partial class User
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public List<Resources> UserResources { get; set; }
        public Dictionary<string, string> UserResourcesDictionary { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime? DateTime1 { get; set; }
        public int[] IntArray { get; set; }
        public char SingleChar { get; set; }
        public char[] CharArray { get; set; }
        public int Count { get; set; }
        public string Str { get; set; }
        public string Title { get; set; }
        public List<string> Tags { get; set; }
        public bool BoolValue { get; set; }
        public List<List<int>> DoubleList { get; set; }
    }
    [MemoryPackable]
    public partial class Resources
    {
        public EResourceType ResourceType;
        public string ResourceName;
        public int ResourceCount;
    }
    public enum EResourceType
    {
        Type1,
        Type2,
        Type3,
        Type4,
        Type5,
    }
    public static class ModelHelper
    {
        static readonly char[] ASCII;
        static User Test1Data;
        static Random Rand;
        static ModelHelper()
        {
            Rand = new Random(314159265);
            var cs = new List<char>();

            //for (var i = 0; i <= byte.MaxValue; i++)
            for (var i = 32; i <= 122; i++)
            {
                var c = (char)i;
                if (char.IsControl(c)) continue;

                cs.Add(c);
            }

            ASCII = cs.ToArray();
            Test1Data = MakeSingleObject<User>();
        }
        static T MakeSingleObject<T>() where T:class,new()
        {
            var ret = new T();
            Type t = typeof(T);
            foreach (var p in t.GetProperties())
            {
                var propType = p.PropertyType;
                var val = propType.RandomValue(Rand);

                p.SetValue(ret, val);
            }

            return ret;
        }
        public static object RandomValue(this Type t, Random rand, int depth = 0)
        {
            if (t.IsPrimitive)
            {
                if (t == typeof(byte))
                {
                    return (byte)(rand.Next(byte.MaxValue - byte.MinValue + 1) + byte.MinValue);
                }

                if (t == typeof(sbyte))
                {
                    return (sbyte)(rand.Next(sbyte.MaxValue - sbyte.MinValue + 1) + sbyte.MinValue);
                }

                if (t == typeof(short))
                {
                    return (short)(rand.Next(short.MaxValue - short.MinValue + 1) + short.MinValue);
                }

                if (t == typeof(ushort))
                {
                    return (ushort)(rand.Next(ushort.MaxValue - ushort.MinValue + 1) + ushort.MinValue);
                }

                if (t == typeof(int))
                {
                    var bytes = new byte[4];
                    rand.NextBytes(bytes);

                    return BitConverter.ToInt32(bytes, 0);
                }

                if (t == typeof(uint))
                {
                    var bytes = new byte[4];
                    rand.NextBytes(bytes);

                    return BitConverter.ToUInt32(bytes, 0);
                }

                if (t == typeof(long))
                {
                    var bytes = new byte[8];
                    rand.NextBytes(bytes);

                    return BitConverter.ToInt64(bytes, 0);
                }

                if (t == typeof(ulong))
                {
                    var bytes = new byte[8];
                    rand.NextBytes(bytes);

                    return BitConverter.ToUInt64(bytes, 0);
                }

                if (t == typeof(float))
                {
                    var bytes = new byte[4];
                    rand.NextBytes(bytes);

                    return BitConverter.ToSingle(bytes, 0);
                }

                if (t == typeof(double))
                {
                    var bytes = new byte[8];
                    rand.NextBytes(bytes);

                    return BitConverter.ToDouble(bytes, 0);
                }

                if (t == typeof(char))
                {
                    var roll = rand.Next(ASCII.Length);

                    return ASCII[roll];
                }

                if (t == typeof(bool))
                {
                    return (rand.Next(2) == 1);
                }

                throw new InvalidOperationException();
            }

            if (t == typeof(string))
            {
                var len = rand.Next(500);
                var c = new char[len];
                for (var i = 0; i < c.Length; i++)
                {
                    c[i] = (char)typeof(char).RandomValue(rand, depth + 1);
                }

                return new string(c);
            }

            if (t == typeof(DateTime))
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

                var bytes = new byte[4];
                rand.NextBytes(bytes);

                var secsOffset = BitConverter.ToInt32(bytes, 0);

                var retDate = epoch.AddSeconds(secsOffset);

                return retDate;
            }

            if (t.IsNullable())
            {
                // leave it unset
                if (rand.Next(2) == 0)
                {
                    // null!
                    return Activator.CreateInstance(t);
                }

                var underlying = Nullable.GetUnderlyingType(t);
                var val = underlying.RandomValue(rand, depth + 1);

                var cons = t.GetConstructor(new[] { underlying });

                return cons.Invoke(new object[] { val });
            }

            if (t.IsEnum)
            {
                var allValues = Enum.GetValues(t);
                var ix = rand.Next(allValues.Length);

                return allValues.GetValue(ix);
            }

            if (t.IsList())
            {
                if (rand.Next(2) == 0 || depth >= 10)
                {
                    return null;
                }

                var listI = t.GetListInterface();

                var valType = listI.GetGenericArguments()[0];

                var retT = typeof(List<>).MakeGenericType(valType);
                var ret = Activator.CreateInstance(retT);
                var add = retT.GetMethod("Add");

                var len = rand.Next(20);
                for (var i = 0; i < len; i++)
                {
                    var elem = valType.RandomValue(rand, depth + 1);
                    add.Invoke(ret, new object[] { elem });
                }

                return ret;
            }
            if (t.IsDictionary())
            {
                if (rand.Next(2) == 0 || depth >= 10)
                {
                    return null;
                }

                var dic1 = t.GetListInterface();

                var keyType = dic1.GetGenericArguments()[0];
                var valueType = dic1.GetGenericArguments()[1];

                var retT = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);
                var ret = Activator.CreateInstance(retT);
                var add = retT.GetMethod("TryAdd");
                //Dictionary<int, int> dict = new Dictionary<int, int>();
                //dict.trya
                var len = rand.Next(20);
                for (var i = 0; i < len; i++)
                {
                    var key = keyType.RandomValue(rand, depth + 1);
                    var value = valueType.RandomValue(rand, depth + 1);
                    add.Invoke(ret, new object[] { key, value });
                }

                return ret;
            }
            var retObj = Activator.CreateInstance(t);
            foreach (var p in t.GetProperties())
            {
                if (rand.Next(2) == 0) continue;

                var propType = p.PropertyType;

                p.SetValue(retObj, propType.RandomValue(rand, depth + 1));
            }

            return retObj;
        }
        public static bool IsNullable(this Type t)
        {
            return Nullable.GetUnderlyingType(t) != null;
        }
        public static bool IsList(this Type t)
        {
            return
                (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>)) ||
                t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IList<>));
        }

        public static Type GetListInterface(this Type t)
        {
            return
                (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>)) ?
                t :
                t.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IList<>));
        }
        public static bool IsDictionary(this Type t)
        {
            return
                (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IDictionary<,>)) ||
                t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDictionary<,>));
        }
        public static User GetTest1Data()
        {
            return Test1Data;
        }
    }
}
