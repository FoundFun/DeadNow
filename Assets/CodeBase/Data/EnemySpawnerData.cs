using System;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Data
{
    [Serializable]
    public class EnemySpawnerData
    {
        public string Id;
        public EnemyTypeId MonsterTypeId;
        public Vector3 Position;

        public EnemySpawnerData(string id, EnemyTypeId monsterTypeId, Vector3 position)
        {
            Id = id;
            MonsterTypeId = monsterTypeId;
            Position = position;
        }
    }
}