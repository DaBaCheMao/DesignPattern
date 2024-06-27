using System;
namespace DesignPattern.BuilderPattern
{
    public class Client
    {
        Director director = new Director();

        public BattleUnit GetHeroUnit()
        {
            UnitBuilder h = new HeroBuilder();
            director.Construct(h);
            return h.GetResult();
        }

        public BattleUnit GetEnemyUnit()
        {
            UnitBuilder e = new EnemyBuilder();
            director.Construct(e);
            return e.GetResult();
        }
    }
}
