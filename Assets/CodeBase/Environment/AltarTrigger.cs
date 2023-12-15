using System;
using CodeBase.Enemy;
using CodeBase.Hero;
using CodeBase.Infrastructure.Factory;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Environment
{
    public class AltarTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject Fire;
        [SerializeField] private GameObject Fire1;
        [SerializeField] private GameObject Fire2;
        [SerializeField] private AudioSource FireDeath;
        [SerializeField] private AudioSource DeathExplosion;

        private IGameFactory _gameFactory;
        private bool _altarComplete;

        private void Awake() => 
            _gameFactory = AllServices.Container.Single<IGameFactory>();

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_gameFactory.Wizard1.IsDead && !_altarComplete)
            {
                Fire1.SetActive(false);
            }

            if (_gameFactory.Wizard2.IsDead && !_altarComplete)
            {
                Fire2.SetActive(false);
            }

            if (other.GetComponent<HeroSquat>().IsSquat && !_altarComplete)
            {
                _altarComplete = true;
                
                other.GetComponent<HeroMove>().enabled = false;
                other.GetComponent<HeroJump>().enabled = false;
                other.GetComponent<HeroSquat>().enabled = false;
                other.GetComponent<HeroFlipper>().enabled = false;
                other.GetComponent<HeroAttack>().enabled = false;

                if (!_gameFactory.Monah.IsDead && _gameFactory.Wizard1.IsDead && _gameFactory.Wizard2.IsDead)
                {
                    other.GetComponent<HeroAnimator>().PlayFinallyDeath();
                    Fire.SetActive(false);
                    FireDeath.Play();
                    EventBus.Instance.GoodGameOver?.Invoke();
                }
                else
                {
                    other.GetComponent<HeroAnimator>().PlayDeath();
                    DeathExplosion.Play();
                    EventBus.Instance.BadFireGameOver?.Invoke();
                }
            }
        }

        public void Reset()
        {
            _altarComplete = false;
            Fire.SetActive(false);
        }
    }
}