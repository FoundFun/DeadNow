using System;
using System.Collections;
using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class BossTarget : MonoBehaviour
    {
        public EnemyDeath FantasyKnight;
        public EnemyDeath Knight;
        public EnemyDeath Samurai;
        public EnemyDeath Bandit;
        public EnemyDeath Bringer;
        public EnemyDeath Monah;
        public EnemyAnimator Animator;
        public AudioSource DeathExplosion;

        private bool _isAttack;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out HeroAnimator animator) && !_isAttack)
            {
                _isAttack = true;

                animator.GetComponent<HeroMove>().enabled = false;
                animator.GetComponent<HeroJump>().enabled = false;
                animator.GetComponent<HeroSquat>().enabled = false;
                animator.GetComponent<HeroFlipper>().enabled = false;
                animator.GetComponent<HeroAttack>().enabled = false;

                if (Monah.IsDead && Samurai.IsDead && FantasyKnight.IsDead && Knight.IsDead && Bandit.IsDead &&
                    Bringer.IsDead)
                    StartCoroutine(OpenWarGameOver(animator));
                else
                    StartCoroutine(OpenBadGameOver(animator));
            }
        }

        public void Reset() =>
            _isAttack = false;

        private IEnumerator OpenWarGameOver(HeroAnimator animator)
        {
            yield return new WaitForSeconds(3f);

            animator.PlayFinallyDown();

            yield return new WaitForSeconds(3f);

            EventBus.Instance.WarGameOver?.Invoke();
        }

        private IEnumerator OpenBadGameOver(HeroAnimator animator)
        {
            yield return new WaitForSeconds(3f);

            Animator.Death();
            
            yield return new WaitForSeconds(1f);

            animator.PlayDeath();
            DeathExplosion.Play();

            yield return new WaitForSeconds(3f);

            EventBus.Instance.BadGameOver?.Invoke();
        }
    }
}