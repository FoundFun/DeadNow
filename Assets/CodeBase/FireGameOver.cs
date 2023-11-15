using System;
using System.Collections;
using CodeBase.GameOvers;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CodeBase
{
    public class FireGameOver : GameOverBase
    {
        [SerializeField] private AudioSource _piano5;
        [SerializeField] private AudioSource _main;
        [SerializeField] private AudioSource _war;
        [SerializeField] private TextMeshProUGUI _endingNumber;
        [SerializeField] private TextMeshProUGUI _theEnd;
        
        private const float Duration = 2;

        private void OnEnable()
        {
            EventBus.Instance.BadFireGameOver += Open;
        }

        private void OnDisable()
        {
            EventBus.Instance.BadFireGameOver -= Open;
        }

        protected override void GameOverReset()
        {
            _piano5.volume = 0;
            _endingNumber.gameObject.transform.localScale = Vector3.zero;
            _theEnd.gameObject.transform.localScale = Vector3.zero;
        }

        protected override IEnumerator PlayGameOver()
        {
            _piano5.Play();

            StartCoroutine(OnDisableAudio(_war));
            StartCoroutine(OnDisableAudio(_main));
            StartCoroutine(OnEnableAudio(_piano5));
            
            yield return new WaitForSeconds(Duration);

            _endingNumber.transform.DOScale(Vector3.one, Duration).SetEase(Ease.OutQuart);

            yield return new WaitForSeconds(Duration);

            _theEnd.transform.DOScale(Vector3.one, Duration).SetEase(Ease.OutQuart);
        }
    }
}