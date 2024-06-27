/*
 * 观察者模式 - 原始版本，观察者和被观察者有潜在的相互引用
 */
using System;
namespace DesignPattern.ObserverPattern
{
    /// <summary>
    /// 被观察对象接口
    /// </summary>
    public interface Subject
    {
        object State { get; set; }

        void Notify();
    }

    /// <summary>
    /// 被观察者
    /// </summary>
    public class SubjectA : Subject
    {
        private object param;

        public object State
        {
            get { return param; }
            set { param = value; }
        }

        public Action EventHandler;

        public void Notify()
        {
            EventHandler();
        }
    }

    /// <summary>
    /// 观察者
    /// </summary>
    public class Observer
    {
        private Subject subject;

        public Observer(Subject subject)
        {
            this.subject = subject;
        }

        public void Update()
        {
            //Action
        }
    }
}
