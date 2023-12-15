using System.Collections;
using CodeBase.Hero;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class BossTarget : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _animator;
        [SerializeField] private AudioSource _deathExplosion;

        private bool _isAttack;
        private IGameFactory _gameFactory;

        private void Awake() => 
            _gameFactory = AllServices.Container.Single<IGameFactory>();

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

                if (_gameFactory.Monah.IsDead
                    && _gameFactory.Samurai.IsDead 
                    && _gameFactory.FantasyKnight.IsDead
                    && _gameFactory.Knight.IsDead 
                    && _gameFactory.Bandit.IsDead
                    && _gameFactory.Bringer.IsDead)
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

            _animator.Death();
            
            yield return new WaitForSeconds(1f);

            animator.PlayDeath();
            _deathExplosion.Play();

            yield return new WaitForSeconds(3f);

            EventBus.Instance.BadGameOver?.Invoke();
        }
    }
}