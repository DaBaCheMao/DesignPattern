/*
 * 模版方法模式
 */
using System;
namespace DesignPattern.TemplateMethodPattern
{
    /// <summary>
    /// 模版 - 固定的流程，但一些细节滞留到子类实现
    /// </summary>
    public class UIBase
    {
        public UIBase()
        {
            OnInit();
        }

        public void Show()
        {
            OnShow();
        }

        public void Hide()
        {
            OnHide();
        }

        public void Dispose()
        {
            OnDispose();
        }

        public virtual void OnInit() { }

        public virtual void OnShow() { }

        public virtual void OnHide() { }

        public virtual void OnDispose() { }
    }

    public class MainPanel : UIBase
    {
        public override void OnDispose()
        {
      
        }

        public override void OnHide()
        {
           
        }

        public override void OnInit()
        {
          
        }

        public override void OnShow()
        {
          
        }
    }
}
