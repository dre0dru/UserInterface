using System.Collections.Generic;
using DG.Tweening;

namespace Screens.Animations
{
    public static class UIAnimationExtensions
    {
        public static Sequence AsSequence(this IEnumerable<UIAnimation> animations, object target = null)
        {
            var sequence = DOTween.Sequence().SetTarget(target);

            foreach (var animation in animations)
            {
                sequence.Append(animation.Play());
            }

            return sequence;
        }

        public static Sequence AsParallelSequence(this IEnumerable<UIAnimation> animations, object target = null)
        {
            var sequence = DOTween.Sequence().SetTarget(target);

            foreach (var animation in animations)
            {
                sequence.Join(animation.Play());
            }

            return sequence;
        }

        public static T SetDefaultValues<T>(this T tween)
            where T : Tween
        {
            return tween
                .SetUpdate(true)
                .SetRecyclable(true);
        }
    }
}
