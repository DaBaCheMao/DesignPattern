/*
 * 工厂方法模式 - 遵守严格的开闭原则：简单工厂在添加产品的时候需要修改工厂代码;工厂方法模式只需要扩展类
 */
using System;
namespace DesignPattern.StrategyPattern
{
    /// <summary>
    /// 排序比较策略类工厂抽象类
    /// </summary>
    public abstract class CompareModuleFactory
    {
        public abstract CompareModuleBase GetCompareModule();
    }

    /// <summary>
    /// 角色比较策略类工厂
    /// </summary>
    public class CompareModuleOfCharacterFactory : CompareModuleFactory
    {
        CompareModuleOfCharacter compare;
        public override CompareModuleBase GetCompareModule()
        {
            if(compare == null)
            {
                compare = new CompareModuleOfCharacter();
            }
            return compare;
        }
    }

    /// <summary>
    /// 物品比较策略类工厂
    /// </summary>
    public class CompareModuleOfItemFactory : CompareModuleFactory
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
    }

    /// <summary>
    /// 算法策略类工厂抽象类
    /// </summary>
    public abstract class SortModuleFactory
    {
        public abstract SortModuleBase GetSortModule();
    }

    /// <summary>
    /// 不稳定算法策略类工厂
    /// </summary>
    public class SortModuleOfUnstableFactory : SortModuleFactory
    {
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
    /// 稳定算法策略类工厂
    /// </summary>
    public class SortModuleOfStableFactory : SortModuleFactory
    {
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
