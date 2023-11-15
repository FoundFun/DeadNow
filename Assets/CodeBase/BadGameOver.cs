using System;
using System.Collections;
using CodeBase.GameOvers;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CodeBase
{
    public class BadGameOver : GameOverBase
    {
        [SerializeField] private AudioSource _piano1;
        [SerializeField] private AudioSource _main;
        [SerializeField] private AudioSource _war;
        [SerializeField] private TextMeshProUGUI _endingNumber;
        [SerializeField] private TextMeshProUGUI _theEnd;
        
        private const float Duration = 2;

        private void OnEnable()
        {
            EventBus.Instance.BadGameOver += Open;
        }

        private void OnDisable()
        {
            EventBus.Instance.BadGameOver -= Open;
        }

        protected override void GameOverReset()
        {
            _piano1.volume = 0;
            _endingNumber.gameObject.transform.localScale = Vector3.zero;
            _theEnd.gameObject.transform.localScale = Vector3.zero;
        }

        protected override IEnumerator PlayGameOver()
        {
            _piano1.Play();
            
            StartCoroutine(OnDisableAudio(_war));
            StartCoroutine(OnDisableAudio(_main));
            StartCoroutine(OnEnableAudio(_piano1));
            
            yield return new WaitForSeconds(Duration);

            _endingNumber.transform.DOScale(Vector3.one, Duration).SetEase(Ease.OutQuart);

            yield return new WaitForSeconds(Duration);

            _theEnd.transform.DOScale(Vector3.one, Duration).SetEase(Ease.OutQuart);
            
        }
    }
}