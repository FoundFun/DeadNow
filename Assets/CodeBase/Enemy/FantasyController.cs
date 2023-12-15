using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class FantasyController : MonoBehaviour
    {
        [SerializeField] private GameObject _idleFantasyWarrior;
        
        private IGameFactory _gameFactory;

        private void Awake() => 
            _gameFactory = AllServices.Container.Single<IGameFactory>();

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!_gameFactory.FantasyKnight.IsDead)
            {
                _gameFactory.FantasyKnight.gameObject.SetActive(false);
                _idleFantasyWarrior.SetActive(true);
            }
            
            gameObject.SetActive(false);
        }
    }
}