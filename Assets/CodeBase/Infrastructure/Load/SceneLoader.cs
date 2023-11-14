using System;
using System.Collections;
using Agava.YandexGames;
using BasicTemplate.CodeBase.Infrastructure;
using BasicTemplate.CodeBase.Services.Yandex;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Services.Load
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IYandexGameReadyService _gameReadyService;

        public SceneLoader(ICoroutineRunner coroutineRunner, IYandexGameReadyService gameReadyService)
        {
            _coroutineRunner = coroutineRunner;
            _gameReadyService = gameReadyService;
        }

        public void Load(string nextScene, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadAsync(nextScene, onLoaded));

        private IEnumerator LoadAsync(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

#if YANDEX_GAMES
            yield return new WaitUntil(() => YandexGamesSdk.IsInitialized);
#endif

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            yield return new WaitUntil(() => waitNextScene.isDone);

#if YANDEX_GAMES
            _gameReadyService.GameReady();
#endif
            onLoaded?.Invoke();
        }
    }
}