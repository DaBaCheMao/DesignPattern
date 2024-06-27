/*
 * 桥接模式 - 将抽象的部分和实现部分分离，使得它们可以独立的变化，例如Effect组合成Skill,将抽象的Skill和具体的实现Effect分离
 */
using System;
using System.Collections.Generic;

namespace DesignPattern.BridgePattern
{
    public abstract class Skill
    {
        protected List<IEffect> effects = new List<IEffect>();

        public void AddEffect(IEffect effect)
        {
            effects.Add(effect);
        }

        public abstract void Operation();
    }

    public class SkillA : Skill
    {
        public override void Operation()
        {
            foreach(var e in effects)
            {
                e.Operation();
            }
        }
    }
}
