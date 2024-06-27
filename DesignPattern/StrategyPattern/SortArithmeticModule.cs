/*
 * 策略模式 - 算法策略类
 */

using System;
using System.Collections.Generic;
namespace DesignPattern.StrategyPattern
{
    public abstract class SortModuleBase
    {
        public abstract void SortArithmetic<T>(
            ref List<Comparison<T>> comparisons, ref List<T> sourceList, int arithmeticType = 0);
    }

    public enum SortArithmeticType
    {
        UNSTABLE, //不稳定排序
        STABLE, //稳定排序
    }

    public class SortModuleOfUnstable : SortModuleBase
    {
        public enum TYPE
        {
            ListSort,
            Other,
        }

        public override void SortArithmetic<T>(
            ref List<Comparison<T>> comparisons, ref List<T> sourceList, int arithmeticType = 0)
        {
            switch((TYPE)arithmeticType)
            {
                case TYPE.ListSort:
                    SortArithmeticByListSort(ref comparisons, ref sourceList);
                    break;
                case TYPE.Other:
                    break;
                default:
                    break;
            }
        }

        private void SortArithmeticByListSort<T>(ref List<Comparison<T>> comparisons, ref List<T> sourceList)
        {
            //使用List.sort 即二分排序和堆排序堆排序算法
        }
    }

    public class SortModuleOfStable : SortModuleBase
    {
        public enum TYPE
        {
            Merge,
            Other,
        }

        public override void SortArithmetic<T>(
            ref List<Comparison<T>> comparisons, ref List<T> sourceList, int arithmeticType = 0)
        {
            switch ((TYPE)arithmeticType)
            {
                case TYPE.Merge:
                    SortArithmeticByMergeSort(comparisons, ref sourceList);
                    break;
                case TYPE.Other:
                    break;
                default:
                    break;
            }
        }

        private void SortArithmeticByMergeSort<T>(List<Comparison<T>> comparisons, ref List<T> sourceList)
        {
            //使用归并排序算法
        }
    }
}
