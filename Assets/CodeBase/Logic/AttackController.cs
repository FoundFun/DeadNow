using UnityEngine;

public class AttackController : MonoBehaviour, IEventActivation, IEventDeactivation
{
    [SerializeField] private Transform _attackPos;
    [SerializeField] private AttackParameters _attackParameters;

    private Collider2D _enemyCollider;

    public void Activate()
    {
        if (!enabled)
            return;

        Attack();
    }

    public void Deactivate()
    {
        this.enabled = false;
    }

    private void Attack()
    {
        _enemyCollider =  Physics2D.OverlapCircle(_attackPos.position, _attackParameters.AttackRange, _attackParameters.EnemyMask);

        if (_enemyCollider != null)
        {
            EventController.ActivateEvent<Death>(_enemyCollider.gameObject);
            _enemyCollider = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPos.transform.position, _attackParameters.AttackRange);
    }
}
