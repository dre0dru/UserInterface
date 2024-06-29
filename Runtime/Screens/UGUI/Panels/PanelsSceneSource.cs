using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dre0Dru.Screens.UGUI.Panels
{
    public class PanelsSceneSource<TPanelBase> : MonoBehaviour, IEnumerable<TPanelBase>
        where TPanelBase : Component
    {
        [SerializeField]
        private List<TPanelBase> _scenePanels;

        public TPanel Get<TPanel>()
            where TPanel : TPanelBase
        {
            return _scenePanels.Single(popup => popup.GetType() == typeof(TPanel)) as TPanel;
        }

        public IEnumerator<TPanelBase> GetEnumerator()
        {
            return ((IEnumerable<TPanelBase>)_scenePanels).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
