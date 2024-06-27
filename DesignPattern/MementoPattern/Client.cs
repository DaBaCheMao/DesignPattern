/*
 * 备忘录模式
 */
using System;
namespace DesignPattern.MementoPattern
{
    public class Client
    {
        public void ChangeState()
        {
            Unit unit = new Unit();
            unit.Atk = 10;
            unit.Def = 10;
            unit.HP = 100;

            Caretaker caretaker = new Caretaker();
            caretaker.Memento1 = unit.CreateMemento();

            //改变状态
            unit.HP = 80;

            //还原状态
            unit.SetMemento(caretaker.Memento1);
        }
    }
}
