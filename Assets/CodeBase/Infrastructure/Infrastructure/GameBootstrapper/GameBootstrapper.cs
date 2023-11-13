using BasicTemplate.CodeBase.Services.Load;
using CodeBase.Services;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure.Infrastructure.GameBootstrapper
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private SceneLoader _sceneLoader;

        private HeroInput _input;
        private AllServices _services;

        private const string MainScene = "Level1";

        private void Awake()
        {
            _input = new HeroInput();
            _services = new AllServices();
            
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            _services.RegisterSingle(InputService());
            _sceneLoader.LoadFirstLevel(MainScene);
        }

        private IInputService InputService()
        {
            return Application.isEditor
                ? new StandaloneInputService(_input)
                : new MobileInputService();
        }
    }
}