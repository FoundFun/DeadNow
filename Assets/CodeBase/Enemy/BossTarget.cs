using System;
using System.Collections;
using CodeBase;
using CodeBase.Hero;
using UnityEngine;

public class BossTarget : MonoBehaviour
{
    public EnemyTrigger FantasyKnight;
    public EnemyTrigger Knight;
    public EnemyTrigger Samurai;
    public EnemyTrigger Bandit;
    public EnemyTrigger Bringer;
    public EnemyAnimator Animator;
    
    private bool _isAttack;

    public event Action WarGameOver;
    public event Action BadGameOver;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out HeroAnimator animator) && !_isAttack)
        {
            _isAttack = true;

            animator.GetComponent<HeroMove>().enabled = false;
            animator.GetComponent<HeroJump>().enabled = false;
            animator.GetComponent<HeroTransfer>().enabled = false;
            animator.GetComponent<HeroFlipper>().enabled = false;

            StartCoroutine(Attack(animator));
        }
    }

    private IEnumerator Attack(HeroAnimator animator)
    {
        if (Samurai.IsDead && FantasyKnight.IsDead && Knight.IsDead && Bandit.IsDead && Bringer.IsDead)
        {
            animator.PlayFinallyDown();
            WarGameOver?.Invoke();
        }
        else
        {
            Animator.Death();

            yield return new WaitForSeconds(1f);
            
            BadGameOver?.Invoke();
        }
    }

    public void Reset() => 
        _isAttack = false;
}