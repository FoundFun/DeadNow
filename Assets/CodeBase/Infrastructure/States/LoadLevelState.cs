using BasicTemplate.CodeBase.Infrastructure;
using Cinemachine;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Infrastructure;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;
using CodeBase.Infrastructure.Services.Load;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        private const string InitialPointTag = "InitialPoint";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IPersistentProgressService _progress;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain,
            IGameFactory gameFactory, IPersistentProgressService progress)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _progress = progress;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _gameFactory.Cleanup();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressesReaders)
                progressReader.LoadProgress(_progress.Progress);
        }

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            GameObject hero = InitHero();

            InitCameraFollow(hero);
        }

        private GameObject InitHero() =>
            _gameFactory.CreateHero(GameObject.FindWithTag(InitialPointTag));

        private void InitCameraFollow(GameObject hero)
        {
            CinemachineVirtualCamera cameraFollow = _gameFactory.CreateCameraFollow();

            cameraFollow.Follow = hero.transform;
        }
    }
}