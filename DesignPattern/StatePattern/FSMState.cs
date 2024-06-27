/*
 * 状态模式 - 状态
 */
using System;
namespace DesignPattern.StatePattern
{
    public class FSMState<T>
    {
        protected void ChangeState<S>(FSM<T> fsm) where S : FSMState<T>
        {
            fsm.ChangeState<S>();
        }

        /// <summary>
        /// 创建有限状态机时调用
        /// </summary>
        /// <param name="fsm"></param>
        public virtual void OnInit(FSM<T> fsm)
        {

        }

        /// <summary>
        /// 销毁有限状态机时调用
        /// </summary>
        /// <param name="fsm"></param>
        public virtual void OnDestroy(FSM<T> fsm)
        {

        }

        /// <summary>
        /// 进入本状态时调用
        /// </summary>
        /// <param name="fsm"></param>
        public virtual void OnEnter(FSM<T> fsm)
        {

        }

        /// <summary>
        /// 离开本状态时调用
        /// </summary>
        /// <param name="fsm"></param>
        /// <param name="isShutdown"></param>
        public virtual void OnLeave(FSM<T> fsm, bool isShutdown)
        {

        }

        /// <summary>
        /// 本状态被轮询时调用
        /// </summary>
        /// <param name="fsm"></param>
        /// <param name="elapseSeconds"></param>
        /// <param name="realElapseSeconds"></param>
        public virtual void OnUpdate(FSM<T> fsm, float elapseSeconds, float realElapseSeconds)
        {

        }
    }
}
