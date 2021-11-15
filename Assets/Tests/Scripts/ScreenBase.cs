using UnityEngine;

namespace Tests.Scripts
{
    public class ScreenBase : MonoBehaviour
    {
        [SerializeField]
        private Canvas _canvas;

        public Canvas Canvas => _canvas;

        public void Open()
        {
            _canvas.enabled = true;
        }

        public void Close()
        {
            _canvas.enabled = false;
        }
    }
}