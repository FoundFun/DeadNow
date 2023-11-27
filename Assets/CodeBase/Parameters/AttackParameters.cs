using UnityEngine;

[CreateAssetMenu(fileName = "AttackParameters", menuName = "CustomParameters/AttackParameters")]
public class AttackParameters : ScriptableObject
{
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _enemyMask;

    public float AttackRange => _attackRange;
    public LayerMask EnemyMask => _enemyMask;
}
