using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Logic
{
    public class SpeakerController : MonoBehaviour, IEventActivation, IEventDeactivation
    {
        [SerializeField] private List<SpeakerText> _sayTexts;

        private Sequence _sequence;

        private void Start()
        {
            ResetTexts();
            _sequence = DOTween.Sequence();
        }

        public void Activate()
        {
            _sequence.Kill();
            _sequence = DOTween.Sequence();
            foreach (var sayText in _sayTexts)
                ShowText(sayText);
        }

        public void Deactivate()
        {
            ResetTexts();
            _sequence.Kill();
        }

        public void ResetTexts()
        {
            _sequence.Kill();
            foreach (var sayText in _sayTexts)
                _sequence.Append(sayText.Text.transform.DOScale(Vector3.zero, sayText.DurationTextShow));
        }

        public void ShowText(SpeakerText message)
        {
            _sequence.Append(message.Text.transform.DOScale(message.TargetTextSize, message.DurationTextShow).SetEase(Ease.OutQuart));
            _sequence.AppendInterval(message.TimeTextShow);

            if (message.DurationTextShow == -1)
                return;

            _sequence.Append(message.Text.transform.DOScale(Vector3.zero, message.DurationTextShow).SetEase(Ease.OutQuart));
        }

        private void OnDestroy()
        {
            _sequence.Kill();
        }
    }
}