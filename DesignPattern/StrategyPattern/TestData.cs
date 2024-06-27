using System;
namespace DesignPattern.StrategyPattern
{
    public class Character
    {
        /// <summary>
        /// 星级 1-5
        /// </summary>
        private int star;
        public int Star
        {
            get { return star; }
            set
            {
                if (value < 0)
                    star = 0;
                else if (value > 5)
                    star = 5;
                else
                    star = value;
            }
        }

        /// <summary>
        /// 觉醒等级
        /// </summary>
        private int awakeLevel;
        public int AwakeLevel
        {
            get { return awakeLevel; }
            set
            {
                if (value < 0)
                    star = 0;
                else if (value > 30)
                    star = 30;
                else
                    star = value;
            }
        }

        /// <summary>
        /// 是否特殊英雄
        /// </summary>
        private bool isSpecial;
        public bool IsSpecial
        {
            get { return isSpecial; }
            set { isSpecial = value; }
        }

        public Character()
        {

        }
    }

    public class Item
    {
        /// <summary>
        /// 星级 1-5
        /// </summary>
        private int star;
        public int Star
        {
            get { return star; }
            set
            {
                if (value < 0)
                    star = 0;
                else if (value > 5)
                    star = 5;
                else
                    star = value;
            }
        }

        /// <summary>
        /// 物品类型
        /// </summary>
        private int itemType;
        public ITEM_TYPE ItemType
        {
            get { return (ITEM_TYPE)itemType; }
            set { itemType = ((int)value); }
        }
    }

    public enum ITEM_TYPE
    {
        NORMAL = 1,
        WEAPON = 2,
    }
}
