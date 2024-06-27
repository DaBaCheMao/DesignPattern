/*
 * 适配器模式 - 只适用于在既有代码无法改变且需要复用的情况下,使用适配器去适配新代码;或者使用适配器去适配不同的第三者库
 */
using System;
namespace DesignPattern.AdapterPattern
{
    /// <summary>
    /// 旧代码
    /// </summary>
    public class OldHero
    {
        /// <summary>
        /// 旧代码的攻击接口
        /// </summary>
        public void Hit() { }

        /// <summary>
        /// 旧代码的防御接口
        /// </summary>
        public void Runaway() { }
    }

    /// <summary>
    /// 新代码接口
    /// </summary>
    public interface Unit
    {
        void Attack();

        void Defend();
    }

    /// <summary>
    /// 新代码
    /// </summary>
    public class Hero : Unit
    {
        public void Attack()
        {
           
        }

        public void Defend()
        {
        
        }
    }

    /// <summary>
    /// 旧代码的适配器,以适配新代码
    /// </summary>
    public class UnitAdapter : Unit
    {
        private OldHero target;

        public UnitAdapter(OldHero target)
        {
            this.target = target;
        }

        public void Attack()
        {
            target.Hit();
        }

        public void Defend()
        {
            target.Runaway();
        }
    }
}
