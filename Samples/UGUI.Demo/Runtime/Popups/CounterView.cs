using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Popups
{
    public interface ICounterViewPresenter : IPresenter
    {
        event Action<int> CountChanged;

        void IncreaseCount();
        void DecreaseCount();
    }

    public class CounterView : MonoBehaviour, IPresentable<ICounterViewPresenter>
    {
        [SerializeField]
        private Button _increaseCountButton;

        [SerializeField]
        private Button _decreaseCountButton;

        [SerializeField]
        private Text _countText;

        private ICounterViewPresenter _presenter;

        private void Awake()
        {
            _increaseCountButton.onClick.AddListener(OnIncreaseCount);
            _decreaseCountButton.onClick.AddListener(OnDecreaseCount);
        }

        public void SetPresenter(ICounterViewPresenter presenter)
        {
            _presenter = presenter;

            _presenter.CountChanged += OnCountChanged;
        }

        private void OnIncreaseCount()
        {
            _presenter.IncreaseCount();
        }

        private void OnDecreaseCount()
        {
            _presenter.DecreaseCount();
        }

        private void OnCountChanged(int count)
        {
            _countText.text = count.ToString();
        }
    }
}
