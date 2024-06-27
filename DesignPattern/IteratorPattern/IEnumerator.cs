/*
 * 迭代器模式 - .Net提供的接口
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPattern.IteratorPattern
{

    public class Item
    {
        public string Name;
    }

    //////////////////////////////纯粹实现IEnumerable接口的示例

    /// <summary>
    /// 集合类 - IEnumerable接口就相当于一个集合接口，提供获取迭代器的方法
    /// </summary>
    public class AggregateB : IEnumerable
    {
        private ArrayList[] items = new ArrayList[10];

        /// <summary>
        /// 直接获取ArrayList的迭代器,所以在外部用foreach遍历这个类实际上就是在遍历items
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }

    /*IEnumerable<T>有两个同名但不同返回值的方法，出现二义性，但因为接口继承原创又必须都实现。
     * 解决办法是公开继承其中一个方法则必须将另一个方法冠上接口名，且冠上接口名的方法必须是私有的。*/

    /// <summary>
    /// 集合类 - 集合的泛型接口
    /// </summary>
    public class AggregateC : IEnumerable<Item>
    {
        private List<Item> items = new List<Item>();

        public IEnumerator<Item> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        // 或者这一种写法也可以
        //IEnumerator<Item> IEnumerable<Item>.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerator GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
    }

    //////////////////////////////自定义迭代器示例

    public class AggregateD : IEnumerable
    {
        private Item[] items;

        public AggregateD(Item[] items)
        {
            this.items = items;
        }

        public IEnumerator GetEnumerator()
        {
            return new IteratorD(items);
        }
    }

    public class IteratorD : IEnumerator
    {
        private Item[] aggregate;

        private int nextIndex = 0;

        private Item current;

        public IteratorD(Item[] aggregate)
        {
            this.aggregate = aggregate;
        }

        public object Current => current;

        public bool MoveNext()
        {
            if (nextIndex > aggregate.Length - 1)
            {
                Reset();
                return false;
            }
            else
            {
                current = aggregate[nextIndex];
                nextIndex++;
                return true;
            }
        }

        public void Reset()
        {
            nextIndex = 0;
        }
    }

    //////////////////////////////自定义泛型迭代器示例

    public class AggregateE : IEnumerable<Item>
    {
        private Item[] items;

        public AggregateE(Item[] items)
        {
            this.items = items;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new IteratorE(items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class IteratorE : IEnumerator<Item>
    {
        private Item[] aggregate;

        private int nextIndex = 0;

        private Item current;

        public IteratorE(Item[] aggregate)
        {
            this.aggregate = aggregate;
        }

        public Item Current => current;

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            aggregate = null;
            current = null;
        }

        public bool MoveNext()
        {
            if (nextIndex > aggregate.Length - 1)
            {
                Reset();
                return false;
            }
            else
            {
                current = aggregate[nextIndex];
                nextIndex++;
                return true;
            }
        }

        public void Reset()
        {
            nextIndex = 0;
        }
    }
}
