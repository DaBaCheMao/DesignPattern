/*
 * 组合模式 - 原始版本
 */
using System;
using System.Collections.Generic;

namespace DesignPattern.CompositePattern
{
    public abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract void Display(int depth);
    }

    /// <summary>
    /// 树枝
    /// </summary>
    public class Branch : Component
    {
        private List<Component> children = new List<Component>();

        public Branch(string name)
            :base(name)
        {

        }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int depth)
        {
            foreach(var c in children)
            {
                c.Display(depth + 1);
            }
        }
    }

    /// <summary>
    /// 树叶
    /// </summary>
    public class Leaf : Component
    {
        public Leaf(string name)
            :base(name)
        {

        }

        public override void Add(Component component)
        {
            //这个方法在叶子节点中没有用
            throw new NotImplementedException();
        }

        public override void Remove(Component component)
        {
            //这个方法在叶子节点中没有用
            throw new NotImplementedException();
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " 叶子深度" + depth);
        }
    }

}
