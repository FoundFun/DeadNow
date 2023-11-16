using BasicTemplate.CodeBase.Infrastructure;
using BasicTemplate.CodeBase.Services.Yandex;
using Cinemachine;
using CodeBase.Infrastructure.Services.Load;
using CodeBase.Infrastructure.States;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, IYandexGameReadyService gameReadyService,
            LoadingCurtain loadingCurtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner, gameReadyService), loadingCurtain, new HeroInput(), AllServices.Container);
        }
    }
}