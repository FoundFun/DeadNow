using CodeBase.Infrastructure.Load;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Yandex;
using CodeBase.Infrastructure.States;
using CodeBase.UI;

namespace CodeBase.Infrastructure.GameBootstrapper
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            ISceneLoader sceneLoader = new SceneLoader(coroutineRunner, AllServices.Container.Single<IYandexGameReadyService>());
            AllServices.Container.RegisterSingle(sceneLoader);
            StateMachine = new GameStateMachine(sceneLoader, loadingCurtain, new HeroInput(), AllServices.Container);
        }
    }
}