using System;
using System.Collections;
using CodeBase.Infrastructure.Services.Yandex;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Load
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IYandexGameReadyService _gameReadyService;

        private bool _isGameReady;

        public SceneLoader(ICoroutineRunner coroutineRunner, IYandexGameReadyService gameReadyService)
        {
            _coroutineRunner = coroutineRunner;
            _gameReadyService = gameReadyService;
        }

        public void Load(string nextScene, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadAsync(nextScene, onLoaded));

        public void Restart()
        {
            SceneManager.LoadScene("Level1");
        }

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
            if (!_isGameReady)
            {
                _gameReadyService.GameReady();
                _isGameReady = true;
            }
#endif
            onLoaded?.Invoke();
        }
    }
}