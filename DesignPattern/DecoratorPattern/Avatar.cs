/*
 * 装饰模式 - 装饰类
 */
using System;
namespace DesignPattern.DecoratorPattern
{
    // 重点在于装饰的是接口
    public interface IAvatar
    {
        public void ShowSkin();
    }

    /// <summary>
    /// 被装饰的类 - 角色形象
    /// </summary>
    public class Avatar : IAvatar
    {
        // 假设基础角色只有内衣裤穿在身上
        public void ShowSkin()
        {
            // 渲染一个人物的基本皮肤和内衣裤
            Console.Write("人 + 内衣裤");
        }
    }

    /// <summary>
    /// 装饰类的基类 - 继承被装饰对象是为了让外部通过装饰类也能访问到被装饰对象的所有方法属性
    /// </summary>
    public abstract class Decorate : IAvatar
    {
        protected Avatar avatar;

        public Decorate()
        {
        }

        /// <summary>
        /// 实现一个包装方法设置装饰的对象
        /// </summary>
        /// <param name="avatar"></param>
        public void Pack(Avatar avatar)
        {
            this.avatar = avatar;
        }

        public void ShowSkin() { }
    }

    /// <summary>
    /// 装饰类 - 装饰对象的ShowSkin方法
    /// </summary>
    public class Cap : Decorate
    {
        public Cap()
        {
        }

        public new void ShowSkin()
        {
            this.avatar.ShowSkin();
            Console.Write(" + 帽子");
        }
    }

    public class Jacket : Decorate
    {
        public Jacket()
        {
        }

        public new void ShowSkin()
        {
            this.avatar.ShowSkin();
            Console.Write(" + 夹克");
        }
    }

    public class Pants : Decorate
    {
        public Pants()
        {
        }

        public new void ShowSkin()
        {
            this.avatar.ShowSkin();
            Console.Write(" + 裤子");
        }
    }

    public class Suit : Decorate
    {
        public Suit()
        {
        }

        public new void ShowSkin()
        {
            this.avatar.ShowSkin();
            Console.Write(" + 西装");
        }
    }
}
