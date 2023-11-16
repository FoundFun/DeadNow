using BasicTemplate.CodeBase.Infrastructure;
using BasicTemplate.CodeBase.Services.Yandex;
using Cinemachine;
using CodeBase.Infrastructure.Infrastructure;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;
using CodeBase.Infrastructure.States;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.GameBootstrapper
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _curtainPrefab;
       
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, AllServices.Container.Single<IYandexGameReadyService>(),
                Instantiate(_curtainPrefab));

            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}