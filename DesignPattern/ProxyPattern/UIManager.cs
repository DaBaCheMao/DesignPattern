/*
 * 代理模式 - 接口代理
 * 代理更多在于控制或完成额外的功能，装饰器更多是对原本功能的加强和修饰
 */
using System;
namespace DesignPattern.ProxyPattern
{
    /// <summary>
    /// UI管理器行为接口
    /// </summary>
    public interface IUIManagerBehavior
    {
        void OpenUI();

        void CloseUI();
    }

    /// <summary>
    /// 中心的UI管理器
    /// </summary>
    public class UIManager : IUIManagerBehavior
    {
        public UIManager()
        {
        }

        public void CloseUI()
        {
            //打开UI
        }

        public void OpenUI()
        {
            //关闭UI
        }
    }

    /// <summary>
    /// 子项目的UI管理器代理
    /// </summary>
    public class UIManagerProxy : IUIManagerBehavior
    {
        public UIManager manager;

        public UIManagerProxy(UIManager manager)
        {
            this.manager = manager;
        }

        public void CloseUI()
        {
            manager.CloseUI();
            Console.WriteLine("CloseUI!");
        }

        public void OpenUI()
        {
            manager.OpenUI();
            Console.WriteLine("OpenUI!");
        }
    }
}
