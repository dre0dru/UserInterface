using System;

namespace Dre0Dru.UI.Screens
{
    //TODO builder pattern or method chaining for setting
    //multiple different presenters to one screen

    //TODO AddTo() methods for disposing like in UniRX
    //both for disposable bag and gameObject destroy trigger
    public interface IPresenter : IDisposable
    {
        
    }

    public interface IPresentable<in TPresenter>
        where TPresenter : IPresenter
    {
        void SetPresenter(TPresenter presenter);
    }
}
