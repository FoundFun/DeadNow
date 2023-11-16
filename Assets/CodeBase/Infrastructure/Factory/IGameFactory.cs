using System.Collections.Generic;
using BasicTemplate.CodeBase.Infrastructure;
using Cinemachine;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;
using CodeBase.Logic.EnemySpawner;
using CodeBase.Services;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressesReaders { get; }
        List<ISavedProgress> ProgressesWriters { get; }
        GameObject CreateHero(GameObject at);
        CinemachineVirtualCamera CreateCameraFollow();
        void Cleanup();
        GameObject CreateEnemy(EnemyTypeId typeId, SpawnerPoint parent);
        void CreateSpawner(Vector3 at, string spawnerId, EnemyTypeId monsterTypeId);
    }
}