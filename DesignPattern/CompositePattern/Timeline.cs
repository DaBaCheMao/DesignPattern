/*
 * 组合模式 - 改进版本，类中不会有无用的函数
 */
using System;
using System.Collections.Generic;

namespace DesignPattern.CompositePattern
{
    public class Timeline
    {
        public Timeline()
        {
        }
    }

    /// <summary>
    /// 时间片 - 树叶
    /// </summary>
    public class TimeClip
    {
        protected string name;

        public TimeClip(string name)
        {
            this.name = name;
        }

        public void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " 叶子深度" + depth);
        }
    }

    /// <summary>
    /// 时间片段组 - 树枝
    /// </summary>
    public class TimeClipGroup : TimeClip
    {
        private List<TimeClip> children = new List<TimeClip>();

        public TimeClipGroup(string name)
            : base(name)
        {

        }

        public void Add(TimeClip component)
        {
            children.Add(component);
        }

        public void Remove(TimeClip component)
        {
            children.Remove(component);
        }

        /// <summary>
        /// new字段显式的隐藏基类的方法
        /// </summary>
        /// <param name="depth"></param>
        public new void Display(int depth)
        {
            foreach (var c in children)
            {
                c.Display(depth + 1);
            }
        }
    }
}
