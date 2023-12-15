using System.Collections.Generic;
using Cinemachine;
using CodeBase.Enemy;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic.EnemySpawner;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressesReaders { get; }
        List<ISavedProgress> ProgressesWriters { get; }
        EnemyTrigger Wizard1 { get; }
        EnemyTrigger Wizard2 { get; }
        EnemyTrigger Monah { get; }
        EnemyTrigger Samurai { get; }
        EnemyTrigger FantasyKnight { get; }
        EnemyTrigger Knight { get; }
        EnemyTrigger Bandit { get; }
        EnemyTrigger Bringer { get; }
        GameObject CreateHero(GameObject at);
        CinemachineVirtualCamera CreateCameraFollow();
        void Cleanup();
        GameObject CreateEnemy(EnemyTypeId typeId, SpawnerPoint parent);
        void CreateSpawner(Vector3 at, string spawnerId, EnemyTypeId monsterTypeId);
    }
}