/*
 * 备忘录模式
 */
using System;
namespace DesignPattern.MementoPattern
{
    public class Unit
    {
        public int Atk;

        public int Def;

        public int HP;

        public Memento CreateMemento()
        {
            return new Memento(Atk, Def, HP);
        }

        public void SetMemento(Memento memento)
        {
            Atk = memento.Atk;
            Def = memento.Def;
            HP = memento.HP;
        }
    }

    /// <summary>
    /// 备忘录
    /// </summary>
    public class Memento
    {
        public int Atk;

        public int Def;

        public int HP;

        public Memento(int atk, int def, int hp)
        {
            Atk = atk;
            Def = def;
            HP = hp;
        }
    }

    /// <summary>
    /// 备忘录看守者
    /// </summary>
    public class Caretaker
    {
        private Memento memento1;

        public Memento Memento1
        {
            get => memento1;
            set => memento1 = value;
        }
    }
}
