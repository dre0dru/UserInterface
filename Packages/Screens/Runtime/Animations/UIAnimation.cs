using DG.Tweening;
using UnityEngine;

namespace Screens.Animations
{
    public abstract class UIAnimation : MonoBehaviour
    {
        public abstract Tween Play();
        
        public abstract void Stop(bool complete);

    }

    public abstract class UIAnimation<TTarget> : UIAnimation where TTarget : Component
    {
        [SerializeField]
        protected TTarget _target;

        [SerializeField]
        protected float _duration = 1.0f;

        [SerializeField]
        protected Ease _ease = Ease.Linear;

        public float Duration => _duration;

        private void OnDestroy()
        {
            Stop(false);
        }

        public override void Stop(bool complete)
        {
            _target.DOKill(complete);
        }
    }
}