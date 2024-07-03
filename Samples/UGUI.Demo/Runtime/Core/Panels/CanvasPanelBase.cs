using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Panels
{
    /// <summary>
    /// Canvas per screen (https://unity.com/en/how-to/unity-ui-optimization-tips)
    /// is recommended by Unity, but feel free to use any approach.
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public class CanvasPanelBase : ScreenBase, ILockableScreen
    {
        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private GraphicRaycaster _graphicRaycaster;

        private int _lockCount = 0;

        public Canvas Canvas => _canvas;

        protected virtual void OnValidate()
        {
            _canvas = GetComponent<Canvas>();
        }

        public void Lock()
        {
            _lockCount++;
            SetGraphicRaycasterEnabled();
        }

        public void Unlock()
        {
            _lockCount = Mathf.Max(--_lockCount, 0);
            SetGraphicRaycasterEnabled();
        }

        private void SetGraphicRaycasterEnabled()
        {
            _graphicRaycaster.enabled = _lockCount == 0;
        }
    }
}
