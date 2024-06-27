using System;
namespace DesignPattern.DecoratorPattern
{
    /// <summary>
    /// 对Avatar进行装饰
    /// </summary>
    public partial class CharacterController
    {
        private Avatar avatar;

        public CharacterController()
        {
            avatar = new Avatar();
        }

        /// <summary>
        /// 展示普通皮肤
        /// </summary>
        public void NormalSkin()
        {
            avatar.ShowSkin();
        }

        /// <summary>
        /// 展示派对皮肤
        /// </summary>
        public void ShowPartySkin()
        {
            Suit suit = new Suit();

            //装饰
            suit.Pack(avatar); //穿西装
            suit.ShowSkin();
        }

        /// <summary>
        /// 展示豪华皮肤
        /// </summary>
        public void ShowLuxurySkin()
        {
            Cap cap = new Cap();
            Jacket jacket = new Jacket();
            Pants pants = new Pants();

            //装饰
            jacket.Pack(avatar); //穿夹克
            pants.Pack(jacket); //穿裤子
            cap.Pack(pants); //戴帽子
            cap.ShowSkin();
        }

        /// <summary>
        /// 获取豪华版人物形象
        /// </summary>
        /// <returns></returns>
        public Avatar GetLuxuryAvatar()
        {
            Cap cap = new Cap();
            Jacket jacket = new Jacket();
            Pants pants = new Pants();

            //装饰
            jacket.Pack(avatar); //穿夹克
            pants.Pack(jacket); //穿裤子
            cap.Pack(pants); //戴帽子
            cap.ShowSkin();
            return cap;
        }
    }

    public partial class CharacterController : IBuff
    {
        public int[] Values
        {
            get => new int[3] { 1, 2, 3 };
            set { }
        }

        public float GetEffectValue()
        {
            //普通计算伤害
            float acount = 0;
            for (int i = 0; i < Values.Length; i++)
            {
                acount += Values[i];
            }
            return acount;
        }
    }
}
