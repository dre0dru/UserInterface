using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Panels
{
    public interface IFirstPanelPresenter : IPresenter
    {
        void NextPanel();
    }

    public class FirstPanel : PanelBase, IPresentable<IFirstPanelPresenter>
    {
        [SerializeField]
        private Button _nextPanelButton;

        private IFirstPanelPresenter _presenter;

        private void Awake()
        {
            _nextPanelButton.onClick.AddListener(OnNextPanelButtonClick);
        }

        public void SetPresenter(IFirstPanelPresenter presenter)
        {
            _presenter = presenter;
        }

        private void OnNextPanelButtonClick()
        {
            _presenter.NextPanel();
        }
    }
}
