using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Components
{
    public class BlockerRaycastFilter : MonoBehaviour, ICanvasRaycastFilter
    {
        public void SetIsBlocking(bool isBlocking)
        {
            enabled = isBlocking;
        }

        public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
        {
            return isActiveAndEnabled;
        }
    }
}
