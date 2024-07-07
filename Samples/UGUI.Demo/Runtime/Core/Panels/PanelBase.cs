using System;
using UnityEngine;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Panels
{
    public class PanelBase : CanvasPanelBase, ISelfOpenableScreen, ISelfCloseableScreen
    {
        [SerializeField]
        private bool _setAnimationToStateOnStart;

        public IOpenHandle OpenHandle { private get; set; }

        public ICloseHandle CloseHandle { private get; set; }

        protected virtual void Start()
        {
            if (_setAnimationToStateOnStart)
            {
                if (this.IsClosedOrClosing())
                {
                    Animation.PlayCloseAnimation(null);
                    Animation.InterruptCurrentAnimation();
                }

                if (this.IsOpenedOrOpening())
                {
                    Animation.PlayOpenAnimation(null);
                    Animation.InterruptCurrentAnimation();
                }
            }
        }

        public void Open(bool skipAnimation = false)
        {
            OpenHandle.Open(skipAnimation);
        }

        public void Close(bool skipAnimation = false)
        {
            CloseHandle.Close(skipAnimation);
        }
    }
}
