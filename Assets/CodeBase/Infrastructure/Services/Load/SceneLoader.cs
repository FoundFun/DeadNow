using System.Collections;
using Agava.YandexGames;
using BasicTemplate.CodeBase.Services.Yandex;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BasicTemplate.CodeBase.Services.Load
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Canvas _hud;
        [SerializeField] private Slider _progressSlider;
        [SerializeField] private TextMeshProUGUI _loadingPercent;

        private AsyncOperation _load;
        private IYandexGameReadyService _gameReadyService;
        private int _descriptionCounter;
        private float _targetValueForDescription;

        private void Awake()
        {
            _gameReadyService = new YandexGameReadyService();

            Reset();
        }

        private void Reset()
        {
            _hud.gameObject.SetActive(false);
            _loadingPercent.text = "0 %";
            _progressSlider.value = 0;
        }

        public void LoadFirstLevel(string sceneName) =>
            StartCoroutine(LoadAsync(sceneName));

        private IEnumerator LoadAsync(string sceneName)
        {
            if (_load != null)
                yield break;

            _hud.gameObject.SetActive(true);

            _load = SceneManager.LoadSceneAsync(sceneName);
            _load.allowSceneActivation = false;

            while (_progressSlider.value < 1)
            {
                UpdateSlider();
                UpdatePercent();

                yield return null;
            }

#if YANDEX_GAMES
            yield return new WaitUntil(() => YandexGamesSdk.IsInitialized);
            _gameReadyService.GameReady();
#endif
            _load.allowSceneActivation = true;

            _hud.gameObject.SetActive(false);
            _load = null;
        }

        private void UpdateSlider() =>
            _progressSlider.value += Time.timeScale * 0.05f;

        private void UpdatePercent() =>
            _loadingPercent.text = $"{Mathf.RoundToInt(_progressSlider.value * 100)} %";
    }
}