using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class EqualsExtension
{
    public static bool TryListEquals<T>(this List<T> a, List<T> b)
    {
        if (a.Count != b.Count)
        {
            return false;
        }
        for (int i = 0; i < a.Count; i++)
        {
            if (!a[i].Equals(b[i]))
            {
                return false;
            }
        }
        return true;
    }
    public static bool TryDictionaryEquals<T, V>(this Dictionary<T, V> a, Dictionary<T, V> b)
    {
        if (a.Count != b.Count)
        {
            return false;
        }
        foreach (var k in a)
        {
            if (!b.TryGetValue(k.Key, out var bv)) return false;
            if (!k.Value.Equals(bv)) return false;
        }
        return true;
    }
    public static bool TryArrayEquals<T>(this T[] a, T[] b)
    {
        if (a == null && b == null)
        {
            return true;
        }
        if (a == null && b != null)
        {
            return false;
        }
        if (a != null && b == null)
        {
            return false;
        }
        if (a.Length != b.Length)
        {
            return false;
        }
        for (int i = 0; i < a.Length; i++)
        {
            if (!a[i].Equals(b[i]))
            {
                return false;
            }
        }
        return true;
    }
    public static bool TryQueueEquals<T>(this Queue<T> a, Queue<T> b)
    {
        if (a == null && b == null)
        {
            return true;
        }
        if (a  == null && b!= null)
        {
            return false;
        }
        if (a!=null && b == null)
        {
            return false;
        }
        if (a.Count != b.Count)
        {
            return false;
        }
        while (a.Count > 0)
        {
            var va = a.Dequeue();
            var vb = b.Dequeue();
            if (!va.Equals(vb))
            {
                return false;
            }
        }
        return true;
    }
    public static bool TryStackEquals<T>(this Stack<T> a, Stack<T> b)
    {
        if (a.Count != b.Count)
        {
            return false;
        }
        while (a.Count > 0)
        {
            var va = a.Pop();
            var vb = b.Pop();
            if (!va.Equals(vb))
            {
                return false;
            }
        }
        return true;
    }
    public static bool TryLinkedListEquals<T>(this LinkedList<T> a, LinkedList<T> b)
    {
        if (a.Count != b.Count)
        {
            return false;
        }
        var nodea = a.First;
        var nodeb = b.First;
        while (nodea != null)
        {
            var va = nodea.Value;
            var vb = nodeb.Value;
            if (!va.Equals(vb))
            {
                return false;
            }
            nodea = nodea.Next;
            nodeb = nodeb.Next;
        }
        return true;
    }


}
