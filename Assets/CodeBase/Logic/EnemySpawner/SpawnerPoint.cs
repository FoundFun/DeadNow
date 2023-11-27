using CodeBase.Data;
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
        private EnemyDeath _enemyDeath;
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

            _enemyDeath = monster.GetComponent<EnemyDeath>();
            _enemyDeath.OnDeath += Slay;
        }

        private void Slay()
        {
            if (_enemyDeath != null)
                _enemyDeath.OnDeath -= Slay;
            
            _slain = true;
        }
    }
}