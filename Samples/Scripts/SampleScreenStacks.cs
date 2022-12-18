using Dre0Dru.Factory;
using Dre0Dru.Screens;
using Dre0Dru.Screens.Stacks;
using NaughtyAttributes;
using UnityEngine;

namespace Dre0Dru.UserInterface.Samples.Scripts
{
    public class SampleScreenStacks : MonoBehaviour, IScreenStacks, ICovariantFactory<ScreenBase>
    {
        [SerializeField]
        private Transform _mainStackRoot;

        [SerializeField]
        private Transform _overlayStackRoot;

        [SerializeField]
        private ScreenBase[] _prefabs;
        
        private IScreenStacks _screenStacks;

        private ICovariantFactory<ScreenBase> _screensFactory;

        private void Awake()
        {
            _screenStacks = new ScreenStacks();
            _screensFactory = new CovariantScreenFactory<ScreenBase>(_prefabs);
            
            AddStack(new MainScreenStack(_mainStackRoot));
            AddStack(new OverlayScreenStack(_overlayStackRoot));
        }

        public TResult Create<TResult>() where TResult : ScreenBase
        {
            return _screensFactory.Create<TResult>();
        }

        public void AddStack<TScreenStack>(TScreenStack screenStack) where TScreenStack : class, IScreenStack
        {
            _screenStacks.AddStack(screenStack);
        }

        public TScreenStack Get<TScreenStack>() where TScreenStack : class, IScreenStack
        {
            return _screenStacks.Get<TScreenStack>();
        }

        public void RemoveStack<TScreenStack>(TScreenStack screenStack) where TScreenStack : class, IScreenStack
        {
            _screenStacks.RemoveStack(screenStack);
        }

        [SerializeField]
        private string _payload;

        [Button()]
        private void PushBasicMain()
        {
            this.CreateAndPush<BasicScreen, MainScreenStack>();
        }

        [Button()]
        private void PushPayloadedMain()
        {
            this.CreateAndPush<PayloadedScreen, MainScreenStack>().PassPayload(_payload);
        }
        
        [Button()]
        private void PushBasicOverlay()
        {
            this.CreateAndPush<BasicScreen, OverlayScreenStack>();
        }
        
        [Button()]
        private void PushPayloadedOverlay()
        {
            this.CreateAndPush<PayloadedScreen, OverlayScreenStack>().PassPayload(_payload);
        }

        [Button()]
        private void PopMain()
        {
            Get<MainScreenStack>().Pop();
        }
        
        [Button()]
        private void PopAllMain()
        {
            Get<MainScreenStack>().PopAll();
        }
        
        [Button()]
        private void PopOverlay()
        {
            Get<OverlayScreenStack>().Pop();
        }
        
        [Button()]
        private void PopAllOverlay()
        {
            Get<OverlayScreenStack>().PopAll();
        }
    }
}
