using System;
using Dre0Dru.UI.Screens.UGUI.Demo.Domain;
using Dre0Dru.UI.Screens.UGUI.Demo.Popups;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Application.Popups
{
    public class CounterViewPresenter : ICounterViewPresenter
    {
        private readonly Counter _counter;

        public event Action<int> CountChanged;

        public CounterViewPresenter(Counter counter)
        {
            _counter = counter;

            _counter.CountChanged += OnCountChanged;
        }

        public virtual void IncreaseCount()
        {
            _counter.IncreaseCount();
        }

        public virtual void DecreaseCount()
        {
            _counter.DecreaseCount();
        }

        void IDisposable.Dispose()
        {
            _counter.CountChanged -= OnCountChanged;
        }

        private void OnCountChanged(int count)
        {
            CountChanged?.Invoke(count);
        }
    }

    //We can put custom logic in presenters that modify domain behaviour
    public class CounterViewMultiplierPresenter : CounterViewPresenter
    {
        private readonly int _multiplier;

        public CounterViewMultiplierPresenter(Counter counter, int multiplier)
            : base(counter)
        {
            _multiplier = multiplier;
        }

        public override void IncreaseCount()
        {
            for (int i = 0; i < _multiplier; i++)
            {
                base.IncreaseCount();
            }
        }

        public override void DecreaseCount()
        {
            for (int i = 0; i < _multiplier; i++)
            {
                base.DecreaseCount();
            }
        }
    }
}
