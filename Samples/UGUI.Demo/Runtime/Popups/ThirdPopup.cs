using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Popups
{
    public interface IThirdPopupPresenter : IPresenter
    {

    }

    public class ThirdPopup : DisposablePopupBase, IPresentable<IThirdPopupPresenter>,
        IPresentable<ICounterViewPresenter>
    {
        [SerializeField]
        private Button _closeButton;

        [SerializeField]
        private CounterView _counterView;

        private IThirdPopupPresenter _presenter;

        private void Awake()
        {
            _closeButton.onClick.AddListener(() => Close());
        }

        public void SetPresenter(IThirdPopupPresenter presenter)
        {
            _presenter = presenter;
            AddDisposable(_presenter);
        }

        public void SetPresenter(ICounterViewPresenter presenter)
        {
            _counterView.SetPresenter(presenter);
            AddDisposable(presenter);
        }
    }
}
