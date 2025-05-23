﻿//------------------------------------------------------------------------------
//  此代码版权声明为全文件覆盖，如有原作者特别声明，会在下方手动补充
//  此代码版权（除特别声明外的代码）归作者本人Diego所有
//  源代码使用协议遵循本仓库的开源协议及附加协议
//  Gitee源代码仓库：https://gitee.com/diego2098/ThingsGateway
//  Github源代码仓库：https://github.com/kimdiego2098/ThingsGateway
//  使用文档：https://thingsgateway.cn/
//  QQ群：605534569
//------------------------------------------------------------------------------

using System.Collections;

namespace ThingsGateway.List;

/// <summary>
/// 线程安全的List，其基本操作和List一致。
/// </summary>
/// <typeparam name="T"></typeparam>
[ThingsGateway.DependencyInjection.SuppressSniffer]
public class ConcurrentList<T> : IList<T>, IReadOnlyList<T>
{
    private readonly List<T> m_list;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="collection"></param>
    public ConcurrentList(IEnumerable<T> collection)
    {
        m_list = new List<T>(collection);
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    public ConcurrentList()
    {
        m_list = new List<T>();
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="capacity"></param>
    public ConcurrentList(int capacity)
    {
        m_list = new List<T>(capacity);
    }

    /// <summary>
    /// 获取或设置容量
    /// </summary>
    public int Capacity
    {
        get
        {
            lock (((ICollection)m_list).SyncRoot)
            {
                return m_list.Capacity;
            }
        }
        set
        {
            lock (((ICollection)m_list).SyncRoot)
            {
                m_list.Capacity = value;
            }
        }
    }

    /// <summary>
    /// 元素数量
    /// </summary>
    public int Count
    {
        get
        {
            lock (((ICollection)m_list).SyncRoot)
            {
                return m_list.Count;
            }
        }
    }

    /// <summary>
    /// 是否为只读
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// 获取索引元素
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T this[int index]
    {
        get
        {
            lock (((ICollection)m_list).SyncRoot)
            {
                return m_list[index];
            }
        }
        set
        {
            lock (((ICollection)m_list).SyncRoot)
            {
                m_list[index] = value;
            }
        }
    }

    /// <summary>
    /// 添加元素
    /// </summary>
    /// <param name="item"></param>
    public void Add(T item)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.Add(item);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.AddRange(IEnumerable{T})"/>
    /// </summary>
    /// <param name="collection"></param>
    public void AddRange(IEnumerable<T> collection)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.AddRange(collection);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.BinarySearch(T)"/>
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int BinarySearch(T item)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.BinarySearch(item);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.BinarySearch(T, IComparer{T})"/>
    /// </summary>
    /// <param name="item"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public int BinarySearch(T item, IComparer<T> comparer)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.BinarySearch(item, comparer);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.BinarySearch(int, int, T, IComparer{T})"/>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="count"></param>
    /// <param name="item"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.BinarySearch(index, count, item, comparer);
        }
    }

    /// <summary>
    /// 清空所有元素
    /// </summary>
    public void Clear()
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.Clear();
        }
    }

    /// <summary>
    /// 是否包含某个元素
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Contains(T item)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.Contains(item);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.ConvertAll{TOutput}(Converter{T, TOutput})"/>
    /// </summary>
    /// <typeparam name="TOutput"></typeparam>
    /// <param name="converter"></param>
    /// <returns></returns>
    public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.ConvertAll(converter);
        }
    }

    /// <summary>
    /// 复制到
    /// </summary>
    /// <param name="array"></param>
    /// <param name="arrayIndex"></param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.CopyTo(array, arrayIndex);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.Find(Predicate{T})"/>
    /// </summary>
    /// <param name="match"></param>
    /// <returns></returns>
    public T Find(Predicate<T> match)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.Find(match);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.FindAll(Predicate{T})"/>
    /// </summary>
    /// <param name="match"></param>
    /// <returns></returns>
    public List<T> FindAll(Predicate<T> match)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.FindAll(match);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.FindIndex(int, int, Predicate{T})"/>
    /// </summary>
    /// <param name="startIndex"></param>
    /// <param name="count"></param>
    /// <param name="match"></param>
    /// <returns></returns>
    public int FindIndex(int startIndex, int count, Predicate<T> match)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.FindIndex(startIndex, count, match);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.FindIndex(int, Predicate{T})"/>
    /// </summary>
    /// <param name="startIndex"></param>
    /// <param name="match"></param>
    /// <returns></returns>
    public int FindIndex(int startIndex, Predicate<T> match)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.FindIndex(startIndex, match);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.FindIndex(Predicate{T})"/>
    /// </summary>
    /// <param name="match"></param>
    /// <returns></returns>
    public int FindIndex(Predicate<T> match)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.FindIndex(match);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.FindLast(Predicate{T})"/>
    /// </summary>
    /// <param name="match"></param>
    /// <returns></returns>
    public T FindLast(Predicate<T> match)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.FindLast(match);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.FindLastIndex(int, int, Predicate{T})"/>
    /// </summary>
    /// <param name="startIndex"></param>
    /// <param name="count"></param>
    /// <param name="match"></param>
    /// <returns></returns>
    public int FindLastIndex(int startIndex, int count, Predicate<T> match)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.FindLastIndex(startIndex, count, match);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.FindLastIndex(int, Predicate{T})"/>
    /// </summary>
    /// <param name="startIndex"></param>
    /// <param name="match"></param>
    /// <returns></returns>
    public int FindLastIndex(int startIndex, Predicate<T> match)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.FindLastIndex(startIndex, match);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.FindLastIndex(Predicate{T})"/>
    /// </summary>
    /// <param name="match"></param>
    /// <returns></returns>
    public int FindLastIndex(Predicate<T> match)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.FindLastIndex(match);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.ForEach(Action{T})"/>
    /// </summary>
    /// <param name="action"></param>
    public void ForEach(Action<T> action)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.ForEach(action);
        }
    }

    /// <summary>
    /// 返回迭代器
    /// </summary>
    /// <returns></returns>
    public IEnumerator<T> GetEnumerator()
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.ToList().GetEnumerator();
        }
    }

    /// <summary>
    /// 返回迭代器组合
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.GetRange(int, int)"/>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<T> GetRange(int index, int count)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.GetRange(index, count);
        }
    }

    /// <summary>
    /// 索引
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int IndexOf(T item)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.IndexOf(item);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.IndexOf(T, int)"/>
    /// </summary>
    /// <param name="item"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public int IndexOf(T item, int index)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.IndexOf(item, index);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.IndexOf(T, int, int)"/>
    /// </summary>
    /// <param name="item"></param>
    /// <param name="index"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public int IndexOf(T item, int index, int count)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.IndexOf(item, index, count);
        }
    }

    /// <summary>
    /// 插入
    /// </summary>
    /// <param name="index"></param>
    /// <param name="item"></param>
    public void Insert(int index, T item)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.Insert(index, item);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.InsertRange(int, IEnumerable{T})"/>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="collection"></param>
    public void InsertRange(int index, IEnumerable<T> collection)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.InsertRange(index, collection);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.LastIndexOf(T)"/>
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int LastIndexOf(T item)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.IndexOf(item);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.LastIndexOf(T, int)"/>
    /// </summary>
    /// <param name="item"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public int LastIndexOf(T item, int index)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.LastIndexOf(item, index);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.LastIndexOf(T, int, int)"/>
    /// </summary>
    /// <param name="item"></param>
    /// <param name="index"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public int LastIndexOf(T item, int index, int count)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.LastIndexOf(item, index, count);
        }
    }

    /// <summary>
    /// 移除元素
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Remove(T item)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.Remove(item);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.RemoveAll(Predicate{T})"/>
    /// </summary>
    /// <param name="match"></param>
    public void RemoveAll(Predicate<T> match)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.RemoveAll(match);
        }
    }

    /// <summary>
    /// 按索引移除
    /// </summary>
    /// <param name="index"></param>
    public void RemoveAt(int index)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            if (index < m_list.Count)
            {
                m_list.RemoveAt(index);
            }
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.RemoveRange(int, int)"/>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="count"></param>
    public void RemoveRange(int index, int count)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.RemoveRange(index, count);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.Reverse()"/>
    /// </summary>
    public void Reverse()
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.Reverse();
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.Reverse(int, int)"/>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="count"></param>
    public void Reverse(int index, int count)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.Reverse(index, count);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.Sort()"/>
    /// </summary>
    public void Sort()
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.Sort();
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.Sort(Comparison{T})"/>
    /// </summary>
    /// <param name="comparison"></param>
    public void Sort(Comparison<T> comparison)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.Sort(comparison);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.Sort(IComparer{T})"/>
    /// </summary>
    /// <param name="comparer"></param>
    public void Sort(IComparer<T> comparer)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.Sort(comparer);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.Sort(int, int, IComparer{T})"/>
    /// </summary>
    /// <param name="index"></param>
    /// <param name="count"></param>
    /// <param name="comparer"></param>
    public void Sort(int index, int count, IComparer<T> comparer)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.Sort(index, count, comparer);
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.ToArray"/>
    /// </summary>
    /// <returns></returns>
    public T[] ToArray()
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.ToArray();
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.TrimExcess"/>
    /// </summary>
    public void TrimExcess()
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            m_list.TrimExcess();
        }
    }

    /// <summary>
    /// <inheritdoc cref="List{T}.TrueForAll(Predicate{T})"/>
    /// </summary>
    /// <param name="match"></param>
    /// <returns></returns>
    public bool TrueForAll(Predicate<T> match)
    {
        lock (((ICollection)m_list).SyncRoot)
        {
            return m_list.TrueForAll(match);
        }
    }
}
