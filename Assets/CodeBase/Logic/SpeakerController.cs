using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Logic
{
    public class SpeakerController : MonoBehaviour
    {
        private Sequence _sequence;

        private void Start()
        {
            _sequence = DOTween.Sequence();
        }

        public void ResetTexts(List<SpeakerText> sayTexts)
        {
            if (sayTexts == null)
                return;

            _sequence.Kill();
            _sequence = DOTween.Sequence();

            foreach (var sayText in sayTexts)
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