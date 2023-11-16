using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Static Data/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        [SerializeField] private string _triggerText;
        [SerializeField] private string _deathText;

        public GameObject Prefab;
        
        public EnemyTypeId EnemyTypeId;

        public string TriggerText => _triggerText;
        public string DeathText => _deathText;
    }
}
