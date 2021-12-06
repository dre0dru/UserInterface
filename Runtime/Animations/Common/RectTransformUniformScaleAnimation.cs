using DG.Tweening;
using UnityEngine;

namespace Screens.Animations.Common
{
    public class RectTransformUniformScaleAnimation: UIAnimation<RectTransform>
    {
        [SerializeField]
        private bool _useRectTransformScale;
    
        [SerializeField]
        private float _startingScale;

        [SerializeField]
        private float _targetScale;
        
        public override Tween Play()
        {
            if (_useRectTransformScale == false)
            {
                _target.localScale = new Vector3(_startingScale, _startingScale, _startingScale);
            }

            return _target.DOScale(_targetScale, _duration)
                .SetDefaultValues()
                .SetEase(_ease);
        }
    }
}