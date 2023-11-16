using BasicTemplate.CodeBase.Infrastructure;
using Cinemachine;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Infrastructure;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Load;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        private readonly IStaticDataService _staticData;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain,
            IGameFactory gameFactory, IPersistentProgressService progress, IStaticDataService staticData)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _progress = progress;
            _staticData = staticData;
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
            InitSpawners();
            
            GameObject hero = InitHero();

            InitCameraFollow(hero);
        }
        
        private void InitSpawners()
        {
            string sceneKey = SceneManager.GetActiveScene().name;

            LevelStaticData levelData = _staticData.ForLevel(sceneKey);
            
            foreach (EnemySpawnerData spawnerData in levelData.EnemySpawners)
                _gameFactory.CreateSpawner(spawnerData.Position, spawnerData.Id, spawnerData.MonsterTypeId);
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