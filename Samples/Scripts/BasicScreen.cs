using System;
using Dre0Dru.DestroyStrategy;
using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.UserInterface.Samples.Scripts
{
    public class BasicScreen : ScreenBase
    {
        [SerializeField]
        private Button _closeButton;

        private void Awake()
        {
            _closeButton.onClick.AddListener(() =>
            {
                ScreenStackPop.Pop();
            });
        }
    }
}
