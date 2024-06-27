/*
 * 单例模式
 */
using System;
namespace DesignPattern.SingletonPattern
{
    /// <summary>
    /// 普通版
    /// </summary>
    public class SingletonA
    {
        private static SingletonA instance;

        public static SingletonA Instance
        {
            get
            {
                if (instance == null)
                    instance = new SingletonA();
                return instance;
            }
        }

        private SingletonA()
        {
        }
    }

    /// <summary>
    /// 线程安全版 懒汉式单例
    /// </summary>
    public class SingletonB
    {
        private static SingletonB instance;

        private static readonly object syncLock = new object();

        public static SingletonB Instance
        {
            get
            {
                //双重空判断 不会每次调用都lock
                if(instance == null)
                {
                    lock(syncLock)
                    {
                        //在第一个线程进入lock后会创建示例 这个再判空使得第二个线程不会创建示例
                        if(instance == null)
                        {
                            instance = new SingletonB();
                        }
                    }
                }
                return instance;
            }
        }

        private SingletonB()
        {

        }
    }

    /// <summary>
    /// 线程安全版 饿汉式单例
    /// </summary>
    public class SingletonC
    {
        //直接在类被加载时旧实例化 依赖公共语言运行库初始化变量
        //readonly意味着只能在静态初始化间或在类的构造函数中分配变量
        private static readonly SingletonC instance = new SingletonC();

        public static SingletonC Instance
        {
            get => instance;
        }

        private SingletonC()
        {

        }
    }
}
