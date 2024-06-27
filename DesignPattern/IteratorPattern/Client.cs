using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPattern.IteratorPattern
{
    public class Client
    {
        public Client()
        {
        }

        /// <summary>
        /// 原始版本迭代器遍历
        /// </summary>
        public void Iterator_A()
        {
            AggregateA aggregate = new AggregateA();
            aggregate[0] = 1;
            aggregate[1] = 2;

            IIterator iterator = aggregate.CreateIterator();

            while(iterator.IsCanMove())
            {
                Console.WriteLine(iterator.Current());
                iterator.MoveNext();
            }
        }

        /// <summary>
        /// 使用foreach遍历集合类
        /// </summary>
        public void Iterator_B()
        {
            AggregateB aggregate = new AggregateB();

            foreach(var item in aggregate)
            {
                Console.WriteLine(((Item)item).Name);
            }
        }

        /// <summary>
        /// 使用foreach遍历集合泛型类
        /// </summary>
        public void Iterator_C()
        {
            AggregateC aggregate = new AggregateC();

            foreach(var item in aggregate)
            {
                Console.WriteLine(item.Name);
            }
        }

        /// <summary>
        /// 使用自定义迭代器类遍历集合类
        /// </summary>
        public void Iterator_D()
        {
            Item[] items = new Item[10];
            AggregateD aggregate = new AggregateD(items);
            IEnumerator iterator = aggregate.GetEnumerator();

            while(iterator.MoveNext())
            {
                Console.WriteLine(((Item)iterator.Current).Name);
            }
        }

        /// <summary>
        /// 使用自定义泛型迭代器遍历泛型集合类
        /// </summary>
        public void Iterator_E()
        {
            Item[] items = new Item[10];
            AggregateE aggregate = new AggregateE(items);
            IEnumerator<Item> iterator = aggregate.GetEnumerator();

            while(iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current.Name);
            }
        }
    }
}
