using DG.Tweening;
using UnityEngine;

namespace Screens.Animations.Common
{
    public class RectTransformTranslateAnimation : UIAnimation<RectTransform>
    {
        [SerializeField]
        private RectTransform _startPoint;

        [SerializeField]
        private RectTransform _endPoint;

        public override Tween Play()
        {
            _target.anchoredPosition = _startPoint.anchoredPosition;

            return _target.DOAnchorPos(_endPoint.anchoredPosition, _duration, true)
                .SetDefaultValues()
                .SetEase(_ease);
        }
    }
}
