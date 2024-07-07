using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Panels
{
    public interface ISecondPanelPresenter : IPresenter
    {
        void PreviousPanel();
        void OpenFirstPopup();
        void OpenThirdPopup();
    }

    public class SecondPanel : PanelBase, IPresentable<ISecondPanelPresenter>
    {
        [SerializeField]
        private Button _previousPanelButton;

        [SerializeField]
        private Button _openFirstPopupButton;

        [SerializeField]
        private Button _openThirdPopupButton;

        private ISecondPanelPresenter _presenter;

        private void Awake()
        {
            _previousPanelButton.onClick.AddListener(OnPreviousPanelButtonClick);
            _openFirstPopupButton.onClick.AddListener(OnOpenFirstPopupButtonClick);
            _openThirdPopupButton.onClick.AddListener(OnOpenThirdPopupButtonClick);
        }

        public void SetPresenter(ISecondPanelPresenter presenter)
        {
            _presenter = presenter;
        }

        private void OnOpenFirstPopupButtonClick()
        {
            _presenter.OpenFirstPopup();
        }

        private void OnOpenThirdPopupButtonClick()
        {
            _presenter.OpenThirdPopup();
        }

        private void OnPreviousPanelButtonClick()
        {
            _presenter.PreviousPanel();
        }
    }
}
