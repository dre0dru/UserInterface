using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.UI.Screens.UGUI.Components
{
    public class MisstapCatcher<TScreenBase> : Button
        where TScreenBase : ISelfCloseableScreen<TScreenBase>
    {
        [SerializeField]
        private TScreenBase _screen;

        [SerializeField]
        private bool _skipAnimation;

        protected override void Awake()
        {
            base.Awake();
            onClick.AddListener(Close);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            onClick.RemoveAllListeners();
        }

        private void Close()
        {
            _screen.Close(_skipAnimation);
        }
    }
}
