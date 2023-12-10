using System.Collections.Generic;
using BasicTemplate.CodeBase.Infrastructure;
using Cinemachine;
using CodeBase.Enemy;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic.EnemySpawner;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        public List<ISavedProgressReader> ProgressesReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressesWriters { get; } = new List<ISavedProgress>();

        private readonly IAssets _assets;
        private readonly IStaticDataService _staticData;

        private GameObject _hero;

        public GameFactory(IAssets assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        public GameObject CreateHero(GameObject at) => 
            InstantiateRegistered(AssetPath.Hero, at.transform.position);

        public CinemachineVirtualCamera CreateCameraFollow() => 
            InstantiateRegistered(AssetPath.CameraFollow);

        public GameObject CreateEnemy(EnemyTypeId typeId, SpawnerPoint parent)
        {
            EnemyStaticData enemyData = _staticData.ForMonster(typeId);

            GameObject enemy =
                Object.Instantiate(enemyData.Prefab, parent.transform.position, Quaternion.identity, parent.transform);

            EnemySpeaker enemySpeaker = enemy.GetComponent<EnemySpeaker>();
            
            enemySpeaker.Tutorial.text = enemyData.TriggerText;
            enemySpeaker.Dead.text = enemyData.DeathText;

            return enemy;
        }
        
        public void CreateSpawner(Vector3 at, string spawnerId, EnemyTypeId monsterTypeId)
        {
            SpawnerPoint spawnerPoint = InstantiateRegistered(AssetPath.Spawner, at)
                .GetComponent<SpawnerPoint>();

            spawnerPoint.Construct(this);
            spawnerPoint.Id = spawnerId;
            spawnerPoint.EnemyTypeId = monsterTypeId;
        }

        public void Cleanup()
        {
            ProgressesReaders.Clear();
            ProgressesWriters.Clear();
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at);
            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        private CinemachineVirtualCamera InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath);
            RegisterProgressWatchers(gameObject);

            CinemachineVirtualCamera cameraFollow = gameObject.GetComponent<CinemachineVirtualCamera>();

            return cameraFollow;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriters)
                ProgressesWriters.Add(progressWriters);

            ProgressesReaders.Add(progressReader);
        }
    }
}