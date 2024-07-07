using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.UI.Screens.UGUI.Demo.Popups
{
    /// <summary>
    /// Canvas per screen (https://unity.com/en/how-to/unity-ui-optimization-tips)
    /// is recommended by Unity, but feel free to use any approach.
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public class CanvasPopupBase : ScreenBase
    {
        [SerializeField]
        private Canvas _canvas;

        public Canvas Canvas => _canvas;

        protected virtual void OnValidate()
        {
            _canvas = GetComponent<Canvas>();
        }
    }
}
