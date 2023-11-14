using BasicTemplate.CodeBase.Infrastructure;
using BasicTemplate.CodeBase.Services.Yandex;
using CodeBase.Infrastructure.Services.Load;
using CodeBase.Services;
using CodeBase.Services.Input;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Infrastructure.Infrastructure.GameBootstrapper
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