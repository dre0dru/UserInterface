using DG.Tweening;
using UnityEngine;

namespace Screens.Animations.Common
{
    public class RectTransformRotateAnimation : UIAnimation<RectTransform>
    {
        [SerializeField]
        private Vector3 _targetRotation;

        [SerializeField]
        private RotateMode _rotateMode = RotateMode.Fast;
        
        [SerializeField]
        private int _loops = -1;
        
        public override Tween Play()
        {
            return _target.DORotate(_targetRotation, _duration, _rotateMode)
                .SetDefaultValues()
                .SetLoops(_loops)
                .SetEase(_ease);
        }
    }
}
