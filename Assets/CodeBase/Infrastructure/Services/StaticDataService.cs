using System.Collections.Generic;
using System.Linq;
using BasicTemplate.CodeBase.Infrastructure;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyTypeId, EnemyStaticData> _monsters;
        private Dictionary<string, LevelStaticData> _levels;

        public void Load()
        {
            _monsters = Resources
                .LoadAll<EnemyStaticData>(AssetPath.EnemyDataPath)
                .ToDictionary(x => x.EnemyTypeId, x => x);
            
            _levels = Resources
                .LoadAll<LevelStaticData>(AssetPath.LevelStaticData)
                .ToDictionary(x => x.LevelKey, x => x);
        }

        public EnemyStaticData ForMonster(EnemyTypeId typeId) =>
            _monsters.TryGetValue(typeId, out EnemyStaticData staticData)
                ? staticData
                : null;

        public LevelStaticData ForLevel(string sceneKey) =>
            _levels.TryGetValue(sceneKey, out LevelStaticData levelStaticData)
                ? levelStaticData
                : null;
    }
}