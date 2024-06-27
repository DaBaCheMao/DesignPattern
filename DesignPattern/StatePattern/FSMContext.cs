/*
 * 状态模式 - 有限状态机工厂
 */
using System;
using System.Collections.Generic;

namespace DesignPattern.StatePattern
{
    public class FSMContext
    {
        private Dictionary<Type, Dictionary<string, object>> _ownerFsmDic = new Dictionary<Type, Dictionary<string, object>>();

        public FSMContext()
        {
        }

        public void CreateFSM<T>(T owner, params FSMState<T>[] states)
        {
            CreateFSM<T>(string.Empty, owner, states);
        }

        public void CreateFSM<T>(string name, T owner, params FSMState<T>[] states)
        {
            Type type = typeof(T);
            if(!_ownerFsmDic.TryGetValue(type, out Dictionary<string, object> fsmDic))
            {
                fsmDic = new Dictionary<string, object>();
                _ownerFsmDic.Add(type, fsmDic);
            }

            if(fsmDic.ContainsKey(name))
            {
                
                Console.WriteLine("已存在同名状态机");
            }
            else
            {
                FSM<T> newFsm = new FSM<T>(name, owner, states);
                newFsm.OnInit();
                fsmDic.Add(name, newFsm);
            }
        }

        public void DestoryFSM<T>()
        {
            DestoryFSM<T>(string.Empty);
        }

        public void DestoryFSM<T>(string name)
        {
            if (_ownerFsmDic.TryGetValue(typeof(T), out Dictionary<string, object> fsmDic))
            {
                if(fsmDic.TryGetValue(name, out object fsm))
                {
                    (fsm as FSM<T>).OnDestroy();
                }
            }
        }

        public bool HasFSM<T>()
        {
            return HasFSM<T>(string.Empty);
        }

        public bool HasFSM<T>(string name)
        {
            if (_ownerFsmDic.TryGetValue(typeof(T), out Dictionary<string, object> fsmDic))
            {
                if (fsmDic.TryGetValue(name, out object fsm))
                {
                    return true;
                }
            }
            return false;
        }

        public FSM<T> GetFSM<T>()
        {
            return GetFSM<T>(string.Empty);
        }

        public FSM<T> GetFSM<T>(string name)
        {
            if (_ownerFsmDic.TryGetValue(typeof(T), out Dictionary<string, object> fsmDic))
            {
                if (fsmDic.TryGetValue(name, out object fsm))
                {
                    return fsm as FSM<T>;
                }
            }
            return null;
        }
    }
}
