using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CodeBase.GameOvers
{
    public abstract class GameOverBase : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI _thanks;

        private const float DelayThanksText = 5;
        private const int TargetThanksPositionY = 3000;
        private const int ThanksAnimationTime = 40;

        private void Awake() =>
            Reset();

        protected virtual void Reset()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;

            GameOverReset();
        }

        public void Open() =>
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

            yield return new WaitForSeconds(DelayThanksText);

            _thanks.transform.DOMoveY(TargetThanksPositionY, ThanksAnimationTime).SetLoops(-1, LoopType.Restart);
        }
    }
}