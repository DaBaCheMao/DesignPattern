/*
 * 简单工厂模式 + 策略模式
 */

using System;
using System.Collections.Generic;
namespace DesignPattern.StrategyPattern
{
    /// <summary>
    /// 排序策略类生产工厂 - 生产排序比较策略类｜生产算法策略类
    /// </summary>
    public class SortContext
    {
        private static SortContext ins;
        public static SortContext Ins
        {
            get
            {
                if (ins == null)
                    ins = new SortContext();
                return ins;
            }
        }

        private SortModuleOfUnstable sortModuleOfUnstable;
        
        private SortModuleOfStable sortModuleOfStable;

        private Dictionary<string, CompareModuleBase> comModuleDict;

        private List<Comparison<Character>> comparisonsCharacter;

        private List<Comparison<Item>> comparisonsItem;

        public SortContext()
        {
            comModuleDict = new Dictionary<string, CompareModuleBase>();

            sortModuleOfUnstable = new SortModuleOfUnstable();
            sortModuleOfStable = new SortModuleOfStable();

            comparisonsCharacter = new List<Comparison<Character>>();
            comparisonsItem = new List<Comparison<Item>>();
        }

        /// <summary>
        /// 生产排序比较策略类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public CompareModuleBase<T> GetCompareModule<T>()
        {
            Type type = typeof(T);
            if (!comModuleDict.TryGetValue(type.Name, out CompareModuleBase comModule))
            {
                if(type == typeof(Character))
                {
                    comModule = new CompareModuleOfCharacter();
                }
                else if(type == typeof(Item))
                {
                    comModule = new CompareModuleOfItem();
                }
                comModuleDict.Add(type.Name, comModule);
            }
            return comModule as CompareModuleBase<T>;
        }

        /// <summary>
        /// 生产算法策略类
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public SortModuleBase GetSortModule(SortArithmeticType type)
        {
            switch(type)
            {
                case SortArithmeticType.UNSTABLE:
                    return sortModuleOfUnstable;
                case SortArithmeticType.STABLE:
                    return sortModuleOfStable;
                default:
                    return sortModuleOfUnstable;
            }
        }

        public List<Comparison<Character>> GetNewComparisonsOfCharacter(params Comparison<Character>[] arr)
        {
            comparisonsCharacter.Clear();
            for(int i=0;i<arr.Length;i++)
            {
                comparisonsCharacter.Add(arr[i]);
            }
            return comparisonsCharacter;
        }

        public List<Comparison<Item>> GetNewComparisonsOfItem(params Comparison<Item>[] arr)
        {
            comparisonsItem.Clear();
            for (int i = 0; i < arr.Length; i++)
            {
                comparisonsItem.Add(arr[i]);
            }
            return comparisonsItem;
        }
    }
}
