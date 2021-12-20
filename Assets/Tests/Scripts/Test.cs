using Screens.Container;
using Tests.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField]
    private SceneScreensContainer _containerMono;

    [SerializeField]
    private InputField _screenName;
    
    private IScreensContainer<string, ScreenBase> _container;

    private void Awake()
    {
        _container = _containerMono;
    }

    public void Instantiate()
    {
        _container.Instantiate(_screenName.text);
    }
    
    public void Open()
    {
        _container.GetInstance(_screenName.text).Open();
    }

    public void Close()
    {
        _container.GetInstance(_screenName.text).Close();
    }
}
