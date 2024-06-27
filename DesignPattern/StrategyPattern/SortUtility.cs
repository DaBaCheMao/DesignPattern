using System;
using System.Collections.Generic;
namespace DesignPattern.StrategyPattern
{
    public class SortUtility
    {
        public SortUtility()
        {
        }

        /// <summary>
        /// 英雄背包主界面使用的排序 - 简单工厂
        /// </summary>
        public void SortForHeroMainPanel(ref List<Character> characters)
        {
            var comModele = SortContext.Ins.GetCompareModule<Character>();
            var comparisions = SortContext.Ins.GetNewComparisonsOfCharacter(
                comModele.GetAscendSortCompareFunc((int)CompareModuleOfCharacter.TYPE.IsSpecial),
                comModele.GetDescendSortCompareFunc((int)CompareModuleOfCharacter.TYPE.Star),
                comModele.GetDescendSortCompareFunc((int)CompareModuleOfCharacter.TYPE.AwakeLevel)
                );
            var sortArithmetic = SortContext.Ins.GetSortModule(SortArithmeticType.UNSTABLE);
            sortArithmetic.SortArithmetic(ref comparisions, ref characters);
        }

        /// <summary>
        /// 物品背包主界面使用的排序 - 简单工厂
        /// </summary>
        /// <param name="items"></param>
        public void SortForItemMainPanel1(ref List<Item> items)
        { 
            var comModele = SortContext.Ins.GetCompareModule<Item>();
            comModele.SetCompareValue("NeedItemType", ITEM_TYPE.WEAPON);
            var comparisions = SortContext.Ins.GetNewComparisonsOfItem(
                comModele.GetAscendSortCompareFunc((int)CompareModuleOfItem.TYPE.Need_ItemTYpe),
                comModele.GetDescendSortCompareFunc((int)CompareModuleOfItem.TYPE.Star)
                );
            var sortArithmetic = SortContext.Ins.GetSortModule(SortArithmeticType.STABLE);
            sortArithmetic.SortArithmetic(ref comparisions, ref items);
        }

        /// <summary>
        /// 物品背包主界面使用的排序 - 工厂方法
        /// </summary>
        /// <param name="items"></param>
        public void SortForItemMainPanel2(ref List<Item> items)
        {
            var compareFactory = new CompareModuleOfItemFactory();
            var compare = (CompareModuleOfItem)compareFactory.GetCompareModule();

            var comparisions = SortContext.Ins.GetNewComparisonsOfItem(
                compare.GetAscendSortCompareFunc((int)CompareModuleOfItem.TYPE.Need_ItemTYpe),
                compare.GetDescendSortCompareFunc((int)CompareModuleOfItem.TYPE.Star)
                );

            var sortFactory = new SortModuleOfUnstableFactory();
            var sort = (SortModuleOfUnstable)sortFactory.GetSortModule();
            sort.SortArithmetic(ref comparisions, ref items);
        }
    }
}
