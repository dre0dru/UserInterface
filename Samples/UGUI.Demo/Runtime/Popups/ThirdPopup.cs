using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Popups
{
    public interface IThirdPopupPresenter : IPresenter
    {

    }

    public class ThirdPopup : DisposablePopupBase, IPresentable<ICounterViewPresenter>
    {
        [SerializeField]
        private Button _closeButton;

        [SerializeField]
        private CounterView _counterView;

        private void Awake()
        {
            _closeButton.onClick.AddListener(() => Close());
        }

        public void SetPresenter(ICounterViewPresenter presenter)
        {
            _counterView.SetPresenter(presenter);
            AddDisposable(presenter);
        }
    }
}
