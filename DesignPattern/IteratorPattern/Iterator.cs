/*
 * 迭代器模式 - 原始版本
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPattern.IteratorPattern
{
    /// <summary>
    /// 迭代器接口
    /// </summary>
    public interface IIterator
    {
        object Head();
        object MoveNext();
        bool IsCanMove();
        object Current();
    }

    /// <summary>
    /// 集合接口
    /// </summary>
    public interface IAggregate
    {
        /// <summary>
        /// 一个需要被遍历的集合应该提供获取迭代器的接口
        /// </summary>
        /// <returns></returns>
        IIterator CreateIterator();

        /// <summary>
        /// 一个需要被遍历的集合应当提供可遍历的下标
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        object this[int index]
        {
            get;set;
        }

        /// <summary>
        /// 一个需要被遍历的集合应当提供遍历的长度
        /// </summary>
        int Count
        {
            get;
        }
    }

    /// <summary>
    /// 迭代器A类型 - 按照下标从小到大遍历
    /// </summary>
    public class IteratorA : IIterator
    {
        /// <summary>
        /// 持有的集合 - 一个迭代器需要持有一个集合，然后主要的工作就是遍历它
        /// </summary>
        private IAggregate aggregate;

        /// <summary>
        /// 遍历集合的当前下标
        /// </summary>
        private int currentIndex = 0;

        public IteratorA(IAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public object Current()
        {
            return aggregate[currentIndex];
        }

        public object Head()
        {
            return aggregate[0];
        }

        public bool IsCanMove()
        {
            if(currentIndex >= aggregate.Count)
            {
                return false;
            }
            return true;
        }

        public object MoveNext()
        {
            if(IsCanMove())
            {
                currentIndex++;
                return aggregate[currentIndex];
            }
            return null;
        }
    }

    /// <summary>
    /// 迭代器B类型 - 按照下标从大到小遍历
    /// </summary>
    public class IteratorB : IIterator
    {
        /// <summary>
        /// 持有的集合 - 一个迭代器需要持有一个集合，然后主要的工作就是遍历它
        /// </summary>
        private IAggregate aggregate;

        /// <summary>
        /// 遍历集合的当前下标
        /// </summary>
        private int currentIndex = 0;

        public IteratorB(IAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public object Current()
        {
            return aggregate[currentIndex];
        }

        public object Head()
        {
            return aggregate[aggregate.Count - 1];
        }

        public bool IsCanMove()
        {
            if (currentIndex > 0)
            {
                return true;
            }
            return false;
        }

        public object MoveNext()
        {
            if (IsCanMove())
            {
                currentIndex--;
                return aggregate[currentIndex];
            }
            return null;
        }
    }

    /// <summary>
    /// 集合类
    /// </summary>
    public class AggregateA : IAggregate
    {
        private List<object> items = new List<object>();

        public object this[int index]
        {
            get => items[index];
            set => items.Insert(index, value);
        }

        public int Count {
            get => items.Count; }

        public IIterator CreateIterator()
        {
            return new IteratorA(this);
        }
    }
}
