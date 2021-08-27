using UnityEngine;

namespace ScreensService.Containers
{
    public abstract class SceneScreenKey<TScreenKey> : MonoBehaviour
    {
        public abstract TScreenKey ScreenKey { get; }
    }
}