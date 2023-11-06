using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroSpeaker : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _mapsChangeMessage;
        
        private const float TargetSize = 0.01f;
        private const int ShowTime = 4;
        private const int Duration = 1;

        private Coroutine _coroutine;
        
        public TextMeshProUGUI MapsChangeMessage => _mapsChangeMessage;

        private void Awake() => 
            Reset();

        public void Reset() => 
            _mapsChangeMessage.transform.DOScale(Vector3.zero, 0);

        public void ShowText(TextMeshProUGUI message)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                Reset();
            }

            _coroutine = StartCoroutine(OnShowText(message));
        }

        private IEnumerator OnShowText(TextMeshProUGUI message)
        {
            message.transform.DOScale(new Vector3(TargetSize, TargetSize, TargetSize), Duration).SetEase(Ease.OutQuart);

            yield return new WaitForSeconds(ShowTime);
        
            message.transform.DOScale(Vector3.zero, Duration).SetEase(Ease.OutQuart);
        }
    }
}