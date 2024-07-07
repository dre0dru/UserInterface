using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Popups
{
    public interface IFirstPopupPresenter : IPresenter
    {
        void OpenSecondPopup();
        void OpenThirdPopup();
    }

    public class FirstPopup : DisposablePopupBase, IPresentable<IFirstPopupPresenter>
    {
        [SerializeField]
        private Button _openSecondPopupButton;

        [SerializeField]
        private Button _openThirdPopupButton;

        [SerializeField]
        private Button _closeButton;

        private IFirstPopupPresenter _presenter;

        private void Awake()
        {
            _openSecondPopupButton.onClick.AddListener(OnOpenSecondButtonClick);
            _openThirdPopupButton.onClick.AddListener(OnOpenThirdButtonClick);
            _closeButton.onClick.AddListener(() => Close());
        }

        public void SetPresenter(IFirstPopupPresenter presenter)
        {
            _presenter = presenter;
            AddDisposable(_presenter);
        }

        private void OnOpenSecondButtonClick()
        {
            _presenter.OpenSecondPopup();
        }

        private void OnOpenThirdButtonClick()
        {
            _presenter.OpenThirdPopup();
        }
    }
}
