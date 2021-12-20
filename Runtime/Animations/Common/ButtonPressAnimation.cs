using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Screens.Animations.Common
{
    public class ButtonPressAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]
        private Vector3 _pressedScale = new Vector3(0.94f, 0.94f, 0.94f);

        [SerializeField]
        private float _inDuration = 0.15f;

        [SerializeField]
        private float _outDuration = 0.15f * 0.5f;

        private Button _button;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _rectTransform = _button.GetComponent<RectTransform>();
        }

        private void OnDestroy()
        {
            KillTween();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_button.IsInteractable())
            {
                _rectTransform.DOScale(_pressedScale, _inDuration)
                    .SetDefaultValues();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_button.IsInteractable())
            {
                KillTween();
                _rectTransform.DOScale(Vector3.one, _outDuration)
                    .SetDefaultValues();
            }
        }

        private void KillTween()
        {
            _rectTransform.DOKill(false);
        }
    }
}