using BasicTemplate.CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.Load;
using CodeBase.Services;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure.Infrastructure.GameBootstrapper
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
            IAssets assets = new AssetProvider();
            IPersistentProgressService progressService = new PersistentProgressService();

            _services.RegisterSingle(assets);
            _services.RegisterSingle(progressService);
            _services.RegisterSingle(InputService());
            _services.RegisterSingle<IGameFactory>(new GameFactory(assets));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(progressService,
                _services.Single<IGameFactory>()));
        }

        private IInputService InputService()
        {
            return Application.isEditor
                ? new StandaloneInputService(_input)
                : new MobileInputService();
        }
    }
}