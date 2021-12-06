using System;
using System.Collections.Generic;
using System.Linq;
using Screens.Container;
using Shared.Sources.ScriptableDatabase;
using UnityEngine;

namespace Tests.Scripts
{
    [CreateAssetMenu(fileName = "ScreensSource", menuName = "SO/ScreensSource")]
    public class SoScreensSource : KvpScriptableDatabase<string, ScreenBase>
    {
     
    }
}
