using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Popups
{
    public interface ICounterViewPresenter : IPresenter
    {
        event Action<int> CountChanged;
        int Count { get; }

        void IncreaseCount();
        void DecreaseCount();
    }

    public class CounterView : MonoBehaviour, IPresentable<ICounterViewPresenter>, IDisposable
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

            SetCount(_presenter.Count);

            _presenter.CountChanged += OnCountChanged;
        }

        public void Dispose()
        {
            _presenter.CountChanged -= OnCountChanged;
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
            SetCount(count);
        }

        private void SetCount(int count)
        {
            _countText.text = count.ToString();
        }
    }
}
