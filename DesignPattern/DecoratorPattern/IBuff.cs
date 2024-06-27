/*
 * 装饰模式 - 装饰接口
 * 代理更多在于控制或完成额外的功能，装饰器更多是对原本功能的加强和修饰
 */
using System;
namespace DesignPattern.DecoratorPattern
{
    /// <summary>
    /// 被装饰的接口
    /// </summary>
    public interface IBuff
    {
        int[] Values { get; set; }

        float GetEffectValue();
    }

    /// <summary>
    /// 装饰类的基类 - 继承被装饰接口是为了让外部通过装饰类也能访问到被装饰接口的所有方法属性
    /// </summary>
    public class BuffExtend : IBuff 
    {
        public int[] Values { get => character.Values; set{ } }

        public CharacterController character;

        /// <summary>
        /// 实现一个包装方法设置装饰的对象
        /// </summary>
        /// <param name="character"></param>
        public void Pack(CharacterController character)
        {
            this.character = character;
        }

        public float GetEffectValue()
        {
            return character.GetEffectValue();
        }
    }

    /// <summary>
    /// 装饰类 - 装饰对象的GetEffectValue方法
    /// </summary>
    public class WeakBuff : BuffExtend
    {
        public new float GetEffectValue()
        {
            return character.GetEffectValue() * 0.6f;
        }
    }

    public class StrongBuff : BuffExtend
    {
        public new float GetEffectValue()
        {
            return character.GetEffectValue() * 1.2f;
        }
    }
}
