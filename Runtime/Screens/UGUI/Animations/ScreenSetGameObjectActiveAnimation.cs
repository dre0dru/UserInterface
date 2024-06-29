using System;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Animations
{
    public class ScreenSetGameObjectActiveAnimation : ScreenAnimation
    {
        [SerializeField]
        private GameObject _root;

        private void Awake()
        {
            if (_root == null)
            {
                _root = gameObject;
            }
        }

        public override void PlayOpenAnimation(Action onComplete)
        {
            _root.SetActive(true);
            onComplete?.Invoke();
        }

        public override void PlayCloseAnimation(Action onComplete)
        {
            _root.SetActive(false);
            onComplete?.Invoke();
        }

        public override void InterruptCurrentAnimation(bool complete = true)
        {
        }
    }
}
