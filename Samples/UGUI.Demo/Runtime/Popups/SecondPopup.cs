using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Popups
{
    public interface ISecondPopupPresenter : IPresenter
    {
        void OpenThirdPopup();
    }

    public class SecondPopup : DisposablePopupBase, IPresentable<ISecondPopupPresenter>,
        IPresentable<ICounterViewPresenter>
    {
        [SerializeField]
        private Button _openThirdPopupButton;

        [SerializeField]
        private Button _closeButton;

        [SerializeField]
        private CounterView _counterView;

        private ISecondPopupPresenter _presenter;

        private void Awake()
        {
            _openThirdPopupButton.onClick.AddListener(OnOpenThirdButtonClick);
            _closeButton.onClick.AddListener(() => Close());
        }

        public void SetPresenter(ISecondPopupPresenter presenter)
        {
            _presenter = presenter;
            AddDisposable(_presenter);
        }

        public void SetPresenter(ICounterViewPresenter presenter)
        {
            _counterView.SetPresenter(presenter);
            AddDisposable(presenter);
        }

        private void OnOpenThirdButtonClick()
        {
            _presenter.OpenThirdPopup();
        }
    }
}
