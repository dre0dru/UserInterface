using Dre0Dru.UI.Screens.UGUI.Panels;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Panels
{
    public interface ILockablePanelsService<TPanelBase> : IPanelsService<TPanelBase>
        where TPanelBase : ILockableScreen, IScreen, ISelfOpenableScreen, ISelfCloseableScreen
    {

    }

    public interface IPanelsService : ILockablePanelsService<PanelBase>
    {
        void Lock<TPanel>()
            where TPanel : PanelBase;

        void Unlock<TPanel>()
            where TPanel : PanelBase;

        void LockAll();

        void UnlockAll();
    }

    public class PanelsService : PanelsService<PanelBase, PanelsSceneSource>, IPanelsService
    {
        protected virtual void Awake()
        {
            SetOpenCloseHandles();
        }

        protected void SetOpenCloseHandles()
        {
            foreach (var panel in this)
            {
                var handle = new ScreenOpenCloseHandle<PanelBase>(panel, this);
                panel.OpenHandle = handle;
                panel.CloseHandle = handle;
            }
        }

        public void Lock<TPanel>()
            where TPanel : PanelBase
        {
            Get<TPanel>().Lock();
        }

        public void Unlock<TPanel>()
            where TPanel : PanelBase
        {
            Get<TPanel>().Unlock();
        }

        public void LockAll()
        {
            foreach (var panel in this)
            {
                panel.Lock();
            }
        }

        public void UnlockAll()
        {
            foreach (var panel in this)
            {
                panel.Unlock();
            }
        }
    }
}
