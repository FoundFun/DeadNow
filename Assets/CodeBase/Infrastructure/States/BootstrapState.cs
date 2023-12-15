using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Load;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.Yandex;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";

        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly HeroInput _input;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader, HeroInput input,
            AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _input = input;
            _services = services;

            _input.Enable();

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadProgressState>();
        }

        private void RegisterServices()
        {
            IStaticDataService staticData = RegisterStaticDataService();
            
            IAssets assets = new AssetProvider();
            IPersistentProgressService progressService = new PersistentProgressService();
            IYandexGameReadyService gameReadyService = new YandexGameReadyService();

            _services.RegisterSingle(assets);
            _services.RegisterSingle(progressService);
            _services.RegisterSingle(gameReadyService);
            _services.RegisterSingle(InputService());
            _services.RegisterSingle<IGameFactory>(new GameFactory(assets, staticData));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(progressService,
                _services.Single<IGameFactory>()));
        }
        
        private IStaticDataService RegisterStaticDataService()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterSingle(staticData);

            return staticData;
        }

        private IInputService InputService()
        {
            return Application.isEditor
                ? new StandaloneInputService(_input)
                : new MobileInputService();
        }
    }
}