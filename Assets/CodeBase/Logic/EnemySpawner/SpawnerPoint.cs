using CodeBase.Data;
using CodeBase.Enemy;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Logic.EnemySpawner
{
    public class SpawnerPoint : MonoBehaviour, ISavedProgress
    {
        public EnemyTypeId EnemyTypeId;

        private IGameFactory _gameFactory;
        private EnemyTrigger _enemyTrigger;
        private bool _slain;

        public string Id { get; set; }

        public void Construct(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        public void LoadProgress(PlayerProgress progress)
        {
            if (progress.KillData.ClearedSpawners.Contains(Id))
                _slain = true;
            else
                Spawn();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            if (_slain)
                progress.KillData.ClearedSpawners.Add(Id);
        }

        private void Spawn()
        {
            GameObject monster = _gameFactory.CreateEnemy(EnemyTypeId, this);

            _enemyTrigger = monster.GetComponent<EnemyTrigger>();
            _enemyTrigger.Happened += Slay;
        }

        private void Slay()
        {
            if (_enemyTrigger != null)
                _enemyTrigger.Happened -= Slay;
            
            _slain = true;
        }
    }
}