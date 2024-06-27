/*
 * 策略模式 - 排序比较条件策略类，这里根据排序目标对象分类
 */

using System;
using System.Collections.Generic;
namespace DesignPattern.StrategyPattern
{
    public abstract class CompareModuleBase
    {

    }

    /// <summary>
    /// 排序策略类基类 自己继承自己是为了放进集合中
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CompareModuleBase<T> : CompareModuleBase 
    {
        public Dictionary<string, object> CompareValueDic;

        public CompareModuleBase()
        {
            CompareValueDic = new Dictionary<string, object>();
        }

        /// <summary>
        /// 设置比较值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetCompareValue(string key, object value)
        {
            if (CompareValueDic.ContainsKey(key))
                CompareValueDic[key] = value;
            else
                CompareValueDic.Add(key, value);
        }

        /// <summary>
        /// 默认条件函数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int DefaultCompare(T a, T b)
        {
            return 0;
        }

        /// <summary>
        /// 升序排序条件函数
        /// </summary>
        /// <returns></returns>
        public virtual Comparison<T> GetAscendSortCompareFunc(int type = 0)
        {
            return DefaultCompare;
        }

        /// <summary>
        /// 降序排序条件函数
        /// </summary>
        /// <returns></returns>
        public virtual Comparison<T> GetDescendSortCompareFunc(int type = 0)
        {
            return DefaultCompare;
        }
    }

    public class CompareModuleOfCharacter : CompareModuleBase<Character>
    {
        public enum TYPE
        {
            Star,
            AwakeLevel,
            IsSpecial,
        }

        public override Comparison<Character> GetAscendSortCompareFunc(int type = 0)
        {
            switch((TYPE)type)
            {
                case TYPE.Star:
                    return CompareByStar;
                case TYPE.AwakeLevel:
                    return CompareByAwakeLevel;
                case TYPE.IsSpecial:
                    return CompareByIsSpecial;
                default:
                    return DefaultCompare;
            }
        }

        public override Comparison<Character> GetDescendSortCompareFunc(int type = 0)
        {
            switch ((TYPE)type)
            {
                case TYPE.Star:
                    return CompareReverseByStar;
                case TYPE.AwakeLevel:
                    return CompareReverseByAwakeLevel;
                default:
                    return DefaultCompare;
            }
        }

        private int CompareByStar(Character a, Character b)
        {
            return a.Star.CompareTo(b.Star);
        }

        private int CompareReverseByStar(Character a, Character b)
        {
            return b.Star.CompareTo(a.Star);
        }

        private int CompareByAwakeLevel(Character a, Character b)
        {
            return a.AwakeLevel.CompareTo(b.AwakeLevel);
        }

        private int CompareReverseByAwakeLevel(Character a, Character b)
        {
            return b.AwakeLevel.CompareTo(a.AwakeLevel);
        }

        private int CompareByIsSpecial(Character a, Character b)
        {
            return a.IsSpecial.CompareTo(b.IsSpecial);
        }
    }

    public class CompareModuleOfItem : CompareModuleBase<Item>
    {
        public enum TYPE
        {
            Star,
            ItemType,
            Need_ItemTYpe,
        }

        public override Comparison<Item> GetAscendSortCompareFunc(int type = 0)
        {
            switch ((TYPE)type)
            {
                case TYPE.Star:
                    return CompareByStar;
                case TYPE.ItemType:
                    return CompareByItemType;
                case TYPE.Need_ItemTYpe:
                    return CompareByNeedItemType;
                default:
                    return DefaultCompare;
            }
        }

        public override Comparison<Item> GetDescendSortCompareFunc(int type = 0)
        {
            switch ((TYPE)type)
            {
                case TYPE.Star:
                    return CompareReverseByStar;
                case TYPE.ItemType:
                    return CompareReverseByItemType;
                default:
                    return DefaultCompare;
            }
        }

        private int CompareByStar(Item a, Item b)
        {
            return a.Star.CompareTo(b.Star);
        }

        private int CompareReverseByStar(Item a, Item b)
        {
            return b.Star.CompareTo(a.Star);
        }

        private int CompareByItemType(Item a, Item b)
        {
            return a.ItemType.CompareTo(b.ItemType);
        }

        private int CompareReverseByItemType(Item a, Item b)
        {
            return b.ItemType.CompareTo(a.ItemType);
        }

        private int CompareByNeedItemType(Item a, Item b)
        {
            if(CompareValueDic.TryGetValue("NeedItemType", out object value))
            {
                ITEM_TYPE needItemType = (ITEM_TYPE)value;
                if (a.ItemType == b.ItemType) return 0;
                if (a.ItemType == needItemType) return -1;
                if (b.ItemType == needItemType) return 1;
            }
            return 0;
        }
    }

}
