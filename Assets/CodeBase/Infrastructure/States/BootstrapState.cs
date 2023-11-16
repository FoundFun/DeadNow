using BasicTemplate.CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Load;
using CodeBase.Services;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly HeroInput _input;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, HeroInput input,
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

            _services.RegisterSingle(assets);
            _services.RegisterSingle(progressService);
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