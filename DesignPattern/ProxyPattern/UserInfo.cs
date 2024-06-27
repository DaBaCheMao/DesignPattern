/*
 * 代理模式 - 类代理
 */
using System;
using System.Collections.Generic;

namespace DesignPattern.ProxyPattern
{
    /// <summary>
    /// 被代理的类
    /// </summary>
    public class UserInfo
    {
        public int Id = 1001;

        public int Area = 2;

        public int Sex = 1;

        /// <summary>
        /// 每个赛季的分数集合
        /// </summary>
        public List<float> Score = new List<float>() { 3.2f, 4.6f, 8.8f};
    }

    /// <summary>
    /// 代理类
    /// </summary>
    public class UserInfoProxy
    {
        private UserInfo userInfo;

        public UserInfoProxy(UserInfo userInfo)
        {
            this.userInfo = userInfo;
        }

        public int GetId()
        {
            return userInfo.Id;
        }

        public string GetArea()
        {
            switch (userInfo.Sex)
            {
                case 0:
                    return "中国";
                case 1:
                    return "越南";
                case 2:
                    return "美国";
                default:
                    return string.Empty;
            }
        }

        public string GetSex()
        {
            switch (userInfo.Sex)
            {
                case 0:
                    return "男";
                case 1:
                    return "女";
                default:
                    return string.Empty;
            }
        }

        public float GetTotalScore()
        {
            float total = 0;
            for (int i = 0; i < userInfo.Score.Count; i++)
            {
                total += userInfo.Score[i];
            }
            return total;
        }

        public float GetSeasonScore(int season)
        {
            return userInfo.Score[season];
        }
    }
}
