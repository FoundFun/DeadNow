using System.Collections.Generic;
using Cinemachine;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;
using UnityEngine;

namespace BasicTemplate.CodeBase.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        public List<ISavedProgressReader> ProgressesReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressesWriters { get; } = new List<ISavedProgress>();

        private readonly IAssets _assets;

        private GameObject _hero;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject at) => 
            InstantiateRegistered(AssetPath.Hero, at.transform.position);

        public CinemachineVirtualCamera CreateCameraFollow() => 
            InstantiateRegistered(AssetPath.CameraFollow);

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