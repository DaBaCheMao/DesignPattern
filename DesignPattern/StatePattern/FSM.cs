/*
 * 状态模式 - 有限状态机
 */
using System;
using System.Collections.Generic;

namespace DesignPattern.StatePattern
{
    /// <summary>
    /// 有限状态机
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FSM<T>
    {
        /// <summary>
        /// 状态机名称
        /// </summary>
        private string _name;
        public string Name
        {
            get => _name;
        }

        /// <summary>
        /// 状态机持有者
        /// </summary>
        private T _owner;
        public T Owner
        {
            get => _owner;
        }

        /// <summary>
        /// 有限状态机的状态集合
        /// </summary>
        private Dictionary<Type, FSMState<T>> _statesDic = new Dictionary<Type, FSMState<T>>();

        /// <summary>
        /// 当前状态
        /// </summary>
        private FSMState<T> _current;

        /// <summary>
        /// 缓存数据
        /// </summary>
        public Dictionary<Type, Dictionary<string, object>> _dataDic = new Dictionary<Type, Dictionary<string, object>>();


        public FSM()
        {

        }

        public FSM(string name, T owner, params FSMState<T> [] states)
        {
            this._name = name;
            this._owner = owner;
            for(int i=0;i<states.Length;i++)
            {
                _statesDic.Add(states[i].GetType(), states[i]);
            }
        }

        public void OnInit()
        {
            foreach(var kvp in _statesDic)
            {
                kvp.Value.OnInit(this);
            }
        }

        public void OnDestroy()
        {
            if (_current != null)
            {
                _current.OnLeave(this, true);
                _current = null;
            }
            foreach (var kvp in _statesDic)
            {
                kvp.Value.OnDestroy(this);
            }
            _statesDic.Clear();
        }

        public void Update(float elapseSeconds, float realElapseSeconds)
        {
            if(_current != null)
            {
                _current.OnUpdate(this, elapseSeconds, realElapseSeconds);
            }
        }

        public void Start<S>() where S : FSMState<T>
        {
            if(_statesDic.TryGetValue(typeof(S), out FSMState<T> state))
            {
                _current = state;
                _current.OnEnter(this);
            }
            Console.WriteLine("状态机中不包含此状态");
        }

        public bool HasState<S>() where S : FSMState<T>
        {
            if (_statesDic.TryGetValue(typeof(S), out FSMState<T> state))
            {
                return true;
            }
            return false;
        }

        public FSMState<T> GetState<S>() where S : FSMState<T>
        {
            if (_statesDic.TryGetValue(typeof(S), out FSMState<T> state))
            {
                return state;
            }
            return null;
        }

        public void ChangeState<S>() where S : FSMState<T>
        {
            if(_current != null)
            {
                _current.OnLeave(this, false);
            }
            if (_statesDic.TryGetValue(typeof(S), out FSMState<T> state))
            {
                _current = state;
                _current.OnEnter(this);
            }
            Console.WriteLine("状态机中不包含此状态");
        }

        public void SetData(string key, object data)
        {
            Type type = data.GetType();
            if(!_dataDic.TryGetValue(type, out Dictionary<string, object> keepDatasDic))
            {
                keepDatasDic = new Dictionary<string, object>();
                _dataDic.Add(type, keepDatasDic);
            }

            if(keepDatasDic.TryGetValue(key, out object keepData))
            {
                Console.WriteLine("已经包含此key的数据");
            }
            else
            {
                keepDatasDic.Add(key, data);
            }
        }

        public R GetData<R>(string key)
        {
            Type type = typeof(R);
            if (_dataDic.TryGetValue(type, out Dictionary<string, object> keepDatasDic))
            {
                if (keepDatasDic.TryGetValue(key, out object keepData))
                {
                    return (R)keepData;
                }
            }
            return default(R);
        }
    }
}
