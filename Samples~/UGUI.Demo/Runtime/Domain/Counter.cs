using System;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Domain
{
    public class Counter
    {
        public event Action<int> CountChanged;

        private int _count;

        public int Count => _count;

        public void IncreaseCount()
        {
            _count++;
            CountChanged?.Invoke(_count);
        }

        public void DecreaseCount()
        {
            _count--;
            CountChanged?.Invoke(_count);
        }
    }
}
