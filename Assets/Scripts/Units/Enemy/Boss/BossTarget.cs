using CodeBase.Enemy;
using System.Collections;
using UnityEngine;

public class BossTarget : Enemy
{
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private AudioSource _deathExplosion;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player hero))
        {
            hero.enabled = false;

            StartCoroutine(Attack(hero));
        }
    }

    private IEnumerator Attack(Player hero)
    {
        Debug.Log("Attack!");
        if (Enemies.Count != 0)
            yield break;
    }
}
