using System;
using System.Collections;
using CodeBase.GameOvers;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CodeBase
{
    public class WarGameOver : GameOverBase
    {
        [SerializeField] private AudioSource _war;
        [SerializeField] private AudioSource _main;
        [SerializeField] private TextMeshProUGUI _endingNumber;
        [SerializeField] private TextMeshProUGUI _theEnd;
        
        private const float Duration = 2f;

        private void OnEnable()
        {
            EventBus.Instance.WarGameOver += Open;
        }

        private void OnDisable()
        {
            EventBus.Instance.WarGameOver -= Open;
        }

        protected override void GameOverReset()
        {
            _war.volume = 0;
            _endingNumber.gameObject.transform.localScale = Vector3.zero;
            _theEnd.gameObject.transform.localScale = Vector3.zero;
        }

        protected override IEnumerator PlayGameOver()
        {
            StartCoroutine(OnDisableAudio(_main));
            StartCoroutine(OnEnableAudio(_war));
            
            yield return new WaitForSeconds(Duration);

            _endingNumber.transform.DOScale(Vector3.one, Duration).SetEase(Ease.OutQuart);

            yield return new WaitForSeconds(Duration);

            _theEnd.transform.DOScale(Vector3.one, Duration).SetEase(Ease.OutQuart);
        }
    }
}