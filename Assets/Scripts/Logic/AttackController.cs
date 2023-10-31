using UnityEngine;

public class AttackController : MonoBehaviour, IAttacked
{
    [SerializeField] private float _triggerSize;
    [SerializeField] private Transform _triggerPos;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private int _damage;

    public bool IsAttack { get; private set; }

    private Coroutine _attackCoroutine;
    private Collider2D[] _enemyColldiers;

    private void Awake()
    {
        IsAttack = false;
    }

    public void Attack()
    {
        float collidersLength = 0.5f;

        if (_attackCoroutine != null || IsAttack)
            return;

        IsAttack = true;
        _enemyColldiers = Physics2D.OverlapCircleAll(_triggerPos.position, _triggerSize, _enemyMask);

        if (_enemyColldiers.Length > collidersLength)
        {
            foreach (var collider in _enemyColldiers)
            {
                if (collider.TryGetComponent(out Unit unit))
                {
                    unit.TakeDamage(_damage);
                    IsAttack = false;
                    return;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_triggerPos.position, _triggerSize);
    }
}
