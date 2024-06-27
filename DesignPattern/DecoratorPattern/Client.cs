using System;
namespace DesignPattern.DecoratorPattern
{
    public class Client
    {
        CharacterController character;

        public Client()
        {
            character = new CharacterController();
        }

        public float NormalBuffCaculate()
        {
           return  character.GetEffectValue();
        }

        /// <summary>
        /// 对IBuff接口进行装饰
        /// </summary>
        /// <returns></returns>
        public float WeakBuffCaculate()
        {
            WeakBuff weakBuff = new WeakBuff();
            weakBuff.Pack(character);
            return weakBuff.GetEffectValue();
        }
    }
}
