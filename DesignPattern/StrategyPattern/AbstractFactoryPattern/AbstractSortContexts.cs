/*
 * 抽象工厂模式 - 这里假设角色排序必定依赖不稳定排序，物品排序必定依赖稳定排序 
 * 就是将一些列互相依赖的对象都放在一个具体工厂中生产，且这些对象都有一个不同的依赖项引起工厂的不同
 */
using System;
namespace DesignPattern.StrategyPattern.AbstractFactoryPattern
{
    /// <summary>
    /// 工厂抽象类
    /// </summary>
    public abstract class CompareModuleFactory
    {
        public abstract CompareModuleBase GetCompareModule();

        public abstract SortModuleBase GetSortModule();
    }

    /// <summary>
    /// 工厂具体类
    /// </summary>
    public class CharacterFactory : CompareModuleFactory
    {
        CompareModuleOfCharacter compare;
        public override CompareModuleBase GetCompareModule()
        {
            if (compare == null)
            {
                compare = new CompareModuleOfCharacter();
            }
            return compare;
        }

        SortModuleOfUnstable sort;
        public override SortModuleBase GetSortModule()
        {
            if (sort == null)
            {
                sort = new SortModuleOfUnstable();
            }
            return sort;
        }
    }

    /// <summary>
    /// 工厂具体类
    /// </summary>
    public class ItemFactory : CompareModuleFactory
    {
        CompareModuleOfItem compare;
        public override CompareModuleBase GetCompareModule()
        {
            if (compare == null)
            {
                compare = new CompareModuleOfItem();
            }
            return compare;
        }

        SortModuleOfStable sort;
        public override SortModuleBase GetSortModule()
        {
            if (sort == null)
            {
                sort = new SortModuleOfStable();
            }
            return sort;
        }
    }
}
