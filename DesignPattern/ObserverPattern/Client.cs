using System;
namespace DesignPattern.ObserverPattern
{
    public class Client
    {
        public Client()
        {
        }

        public void AddObserver1()
        {
            SubjectA subjectA = new SubjectA();
            Observer observer = new Observer(subjectA);
            subjectA.EventHandler += observer.Update;
        }

        public void AddObserver2()
        {
            Listener listener = new Listener();
            EventManager.Ins.AddListener(EventName.UPDATE, listener.Update);
        }
    }
}
