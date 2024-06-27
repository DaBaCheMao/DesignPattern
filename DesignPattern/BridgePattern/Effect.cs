using System;
namespace DesignPattern.BridgePattern
{
    public interface IEffect
    {
        //实际上对英雄属性的改变
        void Operation();
    }

    /// <summary>
    /// 属性增益效果
    /// </summary>
    public class EffectA : IEffect
    {
        public void Operation()
        {
         
        }
    }

    /// <summary>
    /// 伤害效果
    /// </summary>
    public class EffectB : IEffect
    {
        public void Operation()
        {
      
        }
    }

    /// <summary>
    /// 增加普攻回合效果
    /// </summary>
    public class EffectC : IEffect
    {
        public void Operation()
        {
          
        }
    }

    /// <summary>
    /// 附着Buff效果
    /// </summary>
    public class EffectD : IEffect
    {
        public void Operation()
        {
           
        }
    }
}
