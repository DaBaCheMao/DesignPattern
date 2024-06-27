/*
 * 建造者模式
 */
using System;
namespace DesignPattern.BuilderPattern
{
    /// <summary>
    /// 建造者的指挥者 - 封装建造者的建造流程
    /// </summary>
    public class Director
    {
        public void Construct(UnitBuilder builder)
        {
            builder.BuildAtk();
            builder.BuildDef();
            builder.BuildHP();
        }
    }
}
