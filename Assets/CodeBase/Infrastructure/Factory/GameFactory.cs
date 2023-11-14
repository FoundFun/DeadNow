using System.Collections.Generic;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;
using UnityEngine;

namespace BasicTemplate.CodeBase.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        public List<ISavedProgressReader> ProgressesReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressesWriters { get; } = new List<ISavedProgress>();

        private readonly IAssets _asset;

        private GameObject _hero;

        public GameFactory(IAssets asset)
        {
            _asset = asset;
        }

        public GameObject CreateHero(GameObject at) => 
            InstantiateRegistered(AssetPath.Hero, at.transform.position);

        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            _hero = _asset.Instantiate(prefabPath, at);

            return _hero;
        }
        
        public void Cleanup()
        {
            ProgressesReaders.Clear();
            ProgressesWriters.Clear();
        }
    }
}