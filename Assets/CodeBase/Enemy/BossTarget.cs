using CodeBase.Hero;
using CodeBase.Logic.EnemySpawner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class BossTarget : MonoBehaviour
    {
        [SerializeField] private List<SpawnerPoint> _deathUnits;
        [SerializeField] private EnemyAnimator _animator;
        [SerializeField] private AudioSource _deathExplosion;

        /*
        public EnemyDeath FantasyKnight;
        public EnemyDeath Knight;
        public EnemyDeath Samurai;
        public EnemyDeath Bandit;
        public EnemyDeath Bringer;
        public EnemyDeath Monah;
        */

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
                
                foreach (var unit in _deathUnits)
                {
                    if (!unit.Enemy.IsDead)
                    {
                        StartCoroutine(OpenBadGameOver(animator));
                        return;
                    }
                }

                StartCoroutine(OpenWarGameOver(animator));
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

            _animator.Death();
            
            yield return new WaitForSeconds(1f);

            animator.PlayDeath();
            _deathExplosion.Play();

            yield return new WaitForSeconds(3f);

            EventBus.Instance.BadGameOver?.Invoke();
        }
    }
}