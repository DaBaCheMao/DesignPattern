/*
 * 观察者模式 - 实用版本,观察者和被观察者谁也不知道谁
 */
using System;
using System.Collections.Generic;

namespace DesignPattern.ObserverPattern
{
    public class EventManager
    {
        private Dictionary<string, Action> listenerDict;

        private static EventManager ins;
        public static EventManager Ins
        {
            get
            {
                if (ins == null)
                    ins = new EventManager();
                return ins;
            }
        }

        private EventManager()
        {
        }

        public void AddListener(string eventName, Action listener)
        {
            if(!listenerDict.ContainsKey(eventName))
            {
                listenerDict[eventName] = listener;
            }
            else
            {
                listenerDict[eventName] -= listener;
                listenerDict[eventName] += listener;
            }
        }

        public void RemoveListener(string eventName, Action listener)
        {
            if (listenerDict.ContainsKey(eventName))
            {
                listenerDict[eventName] -= listener;
            }
        }

        public void Notify(string eventName)
        {
            if (listenerDict.ContainsKey(eventName))
            {
                listenerDict[eventName]();
            }
        }
    }

    public static class EventName
    {
        public const string UPDATE = "UPDATE";
    }

    public class Target
    {
        public void Update()
        {
            EventManager.Ins.Notify(EventName.UPDATE);
        }
    }

    public class Listener
    {
        public void Update()
        {
            
        }
    }
}
