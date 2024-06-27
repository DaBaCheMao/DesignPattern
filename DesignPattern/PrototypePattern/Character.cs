/*
 * 原型模式
 */
using System;
using System.Collections.Generic;

namespace DesignPattern.PrototypePattern
{
    public class Buff : ICloneable
    {
        public int Id;

        public List<int> Effects = new List<int>();

        /// <summary>
        /// 浅克隆
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// 深克隆
        /// </summary>
        /// <returns></returns>
        public Buff DeepClone()
        {
            Buff temp = (Buff)this.MemberwiseClone();
            temp.Effects = new List<int>();
            temp.Effects.AddRange(Effects);
            return temp;
        }
    }

    public class Character : ICloneable
    {
        public int Id;

        public string Name;

        public float Score;

        public Buff Buff;

        /// <summary>
        /// 浅克隆(不复制引用对象)
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            /*方法含义：创建当前对象的浅表副本。即创建一个新对象，并复制当前对象的非静态字段。
             * 如果字段是值类型，则逐位复制；如果是引用类型，则复制引用但不复制引用的对象。*/
            return this.MemberwiseClone();
        }

        /// <summary>
        /// 深克隆(复制引用对象)
        /// </summary>
        /// <returns></returns>
        public Character DeepClone()
        {
            var temp = (Character)this.MemberwiseClone();
            temp.Buff = Buff.DeepClone();
            return temp;
        }
    }
}
