using Dre0Dru.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Dre0Dru.UserInterface.Samples.Scripts
{
    public class PayloadedScreen : ScreenBase, IPayloadedScreen<string>
    {
        [SerializeField]
        private Text _text;
        
        public void SetPayload(string payload)
        {
            _text.text = payload;
        }
    }
}
