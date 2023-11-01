using System.Collections;
using BasicTemplate.CodeBase.Services.Yandex;
using Lean.Localization;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BasicTemplate.CodeBase.Infrastructure.GameBootstrapper
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private YandexInitialization _yandexInitialization;
        [SerializeField] private LeanLocalization _leanLocalization;
        private IYandexGameReadyService _gameReadyService;

        private const string MainScene = "Main";

        private void Awake()
        {
            _gameReadyService = new YandexGameReadyService();
            _yandexInitialization.Construct(_leanLocalization);

            DontDestroyOnLoad(this);
        }

        private IEnumerator Start()
        {
#if YANDEX_GAMES
            yield return new WaitUntil(() => _yandexInitialization.IsInitialized);

            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(MainScene);
            
            yield return new WaitUntil(() => loadSceneAsync.isDone);
            
            _gameReadyService.GameReady();
#else
            SceneManager.LoadSceneAsync(MainScene);
#endif
            yield break;
        }
    }
}