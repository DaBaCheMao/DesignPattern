/*
 * 建造者模式
 */
using System;
namespace DesignPattern.BuilderPattern
{
    /// <summary>
    /// 战斗单位建造者基类
    /// </summary>
    public abstract class UnitBuilder
    {
        protected BattleUnit unit = new BattleUnit();

        public abstract void BuildHP();

        public abstract void BuildAtk();

        public abstract void BuildDef();

        public abstract BattleUnit GetResult();
    }

    /// <summary>
    /// 我方单位建造者
    /// </summary>
    public class HeroBuilder : UnitBuilder
    {
        public override void BuildAtk()
        {
            //atk的计算可能是需要许多不同对象参与的一系列复制过程
            unit.Atk = 10;
        }

        public override void BuildDef()
        {
            unit.Def = 10;
        }

        public override void BuildHP()
        {
            unit.HP = 100;
        }

        public override BattleUnit GetResult()
        {
            return unit;
        }
    }

    /// <summary>
    /// 敌方单位建造者
    /// </summary>
    public class EnemyBuilder : UnitBuilder
    {
        public override void BuildAtk()
        {
            unit.Atk = 8;
        }

        public override void BuildDef()
        {
            unit.Def = 8;
        }

        public override void BuildHP()
        {
            unit.HP = 100;
        }

        public override BattleUnit GetResult()
        {
            return unit;
        }
    }
}
