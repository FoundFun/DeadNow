using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class KnightController : MonoBehaviour
    {
        [SerializeField] private GameObject _deadKnight;

        private IGameFactory _gameFactory;

        private void Awake() => 
            _gameFactory = AllServices.Container.Single<IGameFactory>();

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!_gameFactory.Knight.IsDead)
            {
                _gameFactory.Knight.gameObject.SetActive(false);
                _deadKnight.SetActive(true);
            }
            
            gameObject.SetActive(false);
        }
    }
}