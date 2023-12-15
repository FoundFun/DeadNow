using System;
using System.Collections;
using CodeBase.Infrastructure.Load;
using CodeBase.Infrastructure.Services;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.GameOvers
{
    public abstract class GameOverBase : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private CanvasGroup _restartCanvasGroup;
        [SerializeField] private TextMeshProUGUI _thanks;
        [SerializeField] private Button _restartButton;

        private const float Delay = 5;
        private const int TargetThanksPositionY = 3000;
        private const int ThanksAnimationTime = 40;

        private ISceneLoader _sceneLoader;

        private void Awake()
        {
            Reset();
            _sceneLoader = AllServices.Container.Single<ISceneLoader>();
            _restartButton.onClick.AddListener(Restart);
        }

        private void OnDestroy() => _restartButton.onClick.RemoveListener(Restart);

        protected virtual void Reset()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
            _restartCanvasGroup.alpha = 0;
            _restartCanvasGroup.interactable = false;
            _restartCanvasGroup.blocksRaycasts = false;

            GameOverReset();
        }

        protected void Open() =>
            StartCoroutine(OnOpen());

        protected IEnumerator OnEnableAudio(AudioSource currentAudio)
        {
            while (currentAudio.volume < 1)
            {
                currentAudio.volume += 0.01f;
                yield return null;
            }
        }

        protected IEnumerator OnDisableAudio(AudioSource currentAudio)
        {
            while (currentAudio.volume > 0)
            {
                currentAudio.volume -= 0.01f;
                yield return null;
            }
        }

        protected abstract void GameOverReset();

        protected abstract IEnumerator PlayGameOver();

        private void Restart()
        {
            _thanks.transform.DOKill();
            _sceneLoader.Restart();
        }

        private IEnumerator OnOpen()
        {
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            
            StartCoroutine(PlayGameOver());

            while (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += 0.002f;
                yield return null;
            }

            yield return new WaitForSeconds(Delay);

            _thanks.transform.DOMoveY(TargetThanksPositionY, ThanksAnimationTime).SetLoops(-1, LoopType.Restart);

            yield return new WaitForSeconds(Delay);
                
            _restartCanvasGroup.interactable = true;
            _restartCanvasGroup.blocksRaycasts = true;
            
            while (_restartCanvasGroup.alpha < 1)
            {
                _restartCanvasGroup.alpha += 0.002f;
                yield return null;
            }
        }
    }
}