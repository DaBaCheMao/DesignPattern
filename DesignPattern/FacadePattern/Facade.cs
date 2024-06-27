using System;
namespace DesignPattern.FacadePattern
{
    public class Facade
    {
        private NetManager netManager = new NetManager();

        private DataManager dataManager = new DataManager();

        private UIManager uiManager = new UIManager();

        public void Shutdown()
        {
            netManager.Shutdown();
            dataManager.Shutdown();
            uiManager.Shutdown();
        }
    }
}
