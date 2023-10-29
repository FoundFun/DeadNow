using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CodeBase
{
    public class GameOverCanvas : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private AudioSource[] _audioSources;
        [SerializeField] private TextMeshProUGUI[] _texts;
        [SerializeField] private float _canvasFadeDuration;
        [SerializeField] private float _textFadeExpectation;
        [SerializeField] private float _textFadeDuration;
        [SerializeField] private float _volumeFadeDiration;

        private Sequence _sequence;

        private void Start()
        {
            _sequence = DOTween.Sequence();
        }

        public void Open()
        {
            foreach (var audio in _audioSources)
                _sequence.Append(audio.DOFade(1, _volumeFadeDiration));

            _sequence.Append(_canvasGroup.DOFade(1, _canvasFadeDuration)).OnComplete(() =>
            {
                foreach (var text in _texts)
                    _sequence.PrependInterval(1).Append(text.DOFade(1, _textFadeDuration));
            });

        }

        private void OnDestroy()
        {
            _sequence.Kill();
        }
    }
}