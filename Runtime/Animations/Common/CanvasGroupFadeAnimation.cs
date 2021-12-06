using DG.Tweening;
using UnityEngine;

namespace Screens.Animations.Common
{
    public class CanvasGroupFadeAnimation : UIAnimation<CanvasGroup>
    {
        [SerializeField]
        private float _startingAlpha;

        [SerializeField]
        private float _targetAlpha;

        [SerializeField]
        private bool _disableRaycasts;

        public override Tween Play()
        {
            if (_disableRaycasts)
            {
                _target.blocksRaycasts = false;
            }

            _target.alpha = _startingAlpha;

            var tween = _target.DOFade(_targetAlpha, _duration)
                .SetDefaultValues()
                .SetEase(_ease);

            if (_disableRaycasts)
            {
                tween.OnComplete(() => _target.blocksRaycasts = true);
            }

            //returning as a sequence so it's impossible to accidentally overwrite onComplete callback
            return DOTween.Sequence(_target).Append(tween);
        }
    }
}
