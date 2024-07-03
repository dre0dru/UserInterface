using System;
using System.Collections.Generic;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Popups
{
    /// <summary>
    /// Popup with disposable list to add presenters or other disposables
    /// </summary>
    public class DisposablePopupBase : PopupBase, IDisposable
    {
        private readonly List<IDisposable> _disposables = new();

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Dispose();
        }

        protected override void OnReturnToPool()
        {
            Dispose();
        }

        protected virtual void Dispose()
        {
            ((IDisposable)this).Dispose();
        }

        protected void AddDisposable(IDisposable disposable)
        {
            _disposables.Add(disposable);
        }

        void IDisposable.Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }

            _disposables.Clear();
        }
    }
}
