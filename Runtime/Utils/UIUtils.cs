using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

namespace Dre0Dru.UI.Utils
{
    public static class UIUtils
    {
        public static bool IsPointerOverUI(EventSystem eventSystem)
        {
            var pointerEventData = new PointerEventData(eventSystem);
            ListPool<RaycastResult>.Get(out var raycastResults);
            raycastResults.Clear();

            eventSystem.RaycastAll(pointerEventData, raycastResults);
            var isOverUI = raycastResults.Count > 0;

            ListPool<RaycastResult>.Release(raycastResults);

            return isOverUI;
        }
    }
}
