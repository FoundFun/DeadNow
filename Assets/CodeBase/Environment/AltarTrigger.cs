using System;
using CodeBase.Enemy;
using CodeBase.Hero;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Environment
{
    public class AltarTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _fire;
        [SerializeField] private GameObject _fire1;
        [SerializeField] private GameObject _fire2;
        [SerializeField] private AudioSource _fireDeath;
        [SerializeField] private AudioSource _deathExplosion;

        private IGameFactory _gameFactory;
        private bool _altarComplete;

        private void Awake() => 
            _gameFactory = AllServices.Container.Single<IGameFactory>();

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_gameFactory.Wizard1.IsDead && !_altarComplete)
            {
                _fire1.SetActive(false);
            }

            if (_gameFactory.Wizard2.IsDead && !_altarComplete)
            {
                _fire2.SetActive(false);
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
                    _fire.SetActive(false);
                    _fireDeath.Play();
                    EventBus.Instance.GoodGameOver?.Invoke();
                }
                else
                {
                    other.GetComponent<HeroAnimator>().PlayDeath();
                    _deathExplosion.Play();
                    EventBus.Instance.BadFireGameOver?.Invoke();
                }
            }
        }

        public void Reset()
        {
            _altarComplete = false;
            _fire.SetActive(false);
        }
    }
}