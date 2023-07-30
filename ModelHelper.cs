using MemoryPack;
using Net;
using Newtonsoft_X.Json.Linq;
using ProtoBuf;
using System.Reflection;
using System.Security.AccessControl;
using UnityEngine;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;

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
    static T MakeSingleObject<T>() where T : class, new()
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
        if (t == typeof(Vector3))
        {
            float v1 = (float)typeof(float).RandomValue(rand);
            float v2 = (float)typeof(float).RandomValue(rand);
            float v3 = (float)typeof(float).RandomValue(rand);
            return new Vector3() { x = v1, y = v2, z = v3 };
        }
        if (t == typeof(TimeSpan))
        {
            var bytes = new byte[8];
            rand.NextBytes(bytes);
            var secsOffset = BitConverter.ToInt64(bytes, 0);
            TimeSpan timeSpan = TimeSpan.FromTicks(secsOffset);
            return timeSpan;
        }
        if (t.IsArray)
        {
            //var arrType = t.MakeArrayType();
            int length = rand.Next(20);
            Array ret = Activator.CreateInstance(t, length) as Array;
            var elememtType = t.GetElementType();
            for (int i = 0; i < length; i++)
            {
                ret.SetValue(elememtType.RandomValue(rand, depth + 1), i);
            }
            return ret;
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
            //if (rand.Next(20) == 0 || depth >= 10)
            //{
            //    return null;
            //}

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
            //if (rand.Next(2) == 0 || depth >= 10)
            //{
            //    return null;
            //}

            var dic1 = t.GetDictionaryInterface();

            var keyType = dic1.GetGenericArguments()[0];
            var valueType = dic1.GetGenericArguments()[1];

            var retT = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);
            var ret = Activator.CreateInstance(retT);
            var add = retT.GetMethod("TryAdd");
            //Dictionary<int, int> dict = new Dictionary<int, int>();
            //dict.trya
            var len = 10;
            for (var i = 0; i < len; i++)
            {
                var key = keyType.RandomValue(rand, depth + 1);
                var value = valueType.RandomValue(rand, depth + 1);
                add.Invoke(ret, new object[] { key, value });
            }

            return ret;
        }
        if (t.IsQueue())
        {
            //if (rand.Next(2) == 0 || depth >= 10)
            //{
            //    return null;
            //}
            var queue = t.GetQueueInterface();
            var keyType = t.GetGenericArguments()[0];
            var ret = Activator.CreateInstance(queue);
            var enqueue = queue.GetMethod("Enqueue");
            var len = rand.Next(20);
            for (int i = 0; i < len; i++)
            {
                var element = keyType.RandomValue(rand);
                enqueue.Invoke(ret, new object[] { element });
            }
            return ret;
        }
        if (t.IsStack())
        {
            //if (rand.Next(2) == 0 || depth >= 10)
            //{
            //    return null;
            //}
            var stack = t.GetStackInterface();
            var keyType = t.GetGenericArguments()[0];
            var ret = Activator.CreateInstance(stack);
            var push = stack.GetMethod("Push");
            var len = rand.Next(20);
            for (int i = 0; i < len; i++)
            {
                var element = keyType.RandomValue(rand);
                push.Invoke(ret, new object[] { element });
            }
            return ret;
        }
        if (t.IsLinkedList())
        {
            //if (rand.Next(2) == 0 || depth >= 10)
            //{
            //    return null;
            //}
            //LinkedList<int> link;
            //link.AddLast(0);
            var keyType = t.GetGenericArguments()[0];
            var linkedList = t.GetLinkedInterface();
            var ret = Activator.CreateInstance(linkedList);
            MethodInfo[] methods = linkedList.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            var addLast = methods.Where(x => x.Name == "AddLast" && x.GetParameters()[0].ParameterType == keyType).First();
            //var addLast = linkedList.GetMethod("AddLast");
            var len = rand.Next(20);
            for (int i = 0; i < len; i++)
            {
                var element = keyType.RandomValue(rand);
                addLast.Invoke(ret, new object[] { element });
            }
            return ret;
        }
        var retObj = Activator.CreateInstance(t);
        foreach (var p in t.GetProperties())
        {
            //if (rand.Next(2) == 0) continue;

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
    public static Type GetDictionaryInterface(this Type t)
    {
        return
            (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IDictionary<,>)) ?
            t :
            t.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDictionary<,>));
    }
    public static bool IsQueue(this Type t)
    {
        return
            (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Queue<>)) ||
            t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(Queue<>));
    }
    public static Type GetQueueInterface(this Type t)
    {
        return
            (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Queue<>)) ?
            t :
            t.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(Queue<>));
    }
    public static bool IsStack(this Type t)
    {
        return
            (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Stack<>)) ||
            t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(Stack<>));
    }
    public static Type GetStackInterface(this Type t)
    {
        return
            (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Stack<>)) ?
            t :
            t.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(Stack<>));
    }
    public static bool IsLinkedList(this Type t)
    {
        return
            (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(LinkedList<>)) ||
            t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(LinkedList<>));
    }
    public static Type GetLinkedInterface(this Type t)
    {
        return
            (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(LinkedList<>)) ?
            t :
            t.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(LinkedList<>));
    }
    public static User GetTest1Data()
    {
        return Test1Data;
    }

    public static BenchMark.User UserToProtocol(User Value)
    {
        BenchMark.User user = new BenchMark.User();
        user.ID = Value.ID;
        user.Name = Value.Name;
        List<BenchMark.Resources> protocol = new List<BenchMark.Resources>();
        foreach (var item in Value.UserResources)
        {
            BenchMark.Resources resources = new BenchMark.Resources();
            resources.ResourceCount = item.ResourceCount;
            resources.ResourceName = item.ResourceName ?? string.Empty;
            resources.ResourceType = (BenchMark.EResourceType)item.ResourceType;
            protocol.Add(resources);
        }
        user.UserResources = protocol;
        user.UserResourcesDictionary = Value.UserResourcesDictionary;
        user.DateTime = Value.DateTime;
        user.IntArray = Value.IntArray ?? new int[0];
        user.SingleChar = Value.SingleChar;
        user.CharArray = Value.CharArray;
        user.Count = Value.Count;
        user.Str = Value.Str;
        user.Title = Value.Title;
        user.Tags = Value.Tags;
        user.BoolValue = Value.BoolValue;
        foreach (var item in Value.CommitDir)
        {
            BenchMark.Commit commit = new BenchMark.Commit();
            commit.ID = item.Value.ID;
            commit.Event = item.Value.Event ?? string.Empty;
            user.CommitDir.Add(item.Key, commit);
        }
        user.TimeSpan = Value.TimeSpan;
        user.Queue = Value.Queue;
        user.Stack = Value.Stack;
        user.LinkedList = Value.LinkedList;
        return user;
    }
}