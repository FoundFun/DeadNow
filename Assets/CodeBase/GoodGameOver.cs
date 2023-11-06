using System.Collections;
using Agava.YandexGames;
using CodeBase.GameOvers;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase
{
    public class GoodGameOver : GameOverBase
    {
        [SerializeField] private AudioSource _piano4;
        [SerializeField] private AudioSource _main;
        [SerializeField] private TextMeshProUGUI _endingNumber;
        [SerializeField] private TextMeshProUGUI _theEnd;
        
        private const float Duration = 2;

        protected override void GameOverReset()
        {
            _piano4.volume = 0;
            _endingNumber.gameObject.transform.localScale = Vector3.zero;
            _theEnd.gameObject.transform.localScale = Vector3.zero;
        }

        protected override IEnumerator PlayGameOver()
        {
            _piano4.Play();
            
            StartCoroutine(OnDisableAudio(_main));
            StartCoroutine(OnEnableAudio(_piano4));
            
            yield return new WaitForSeconds(Duration);

            _endingNumber.transform.DOScale(Vector3.one, Duration).SetEase(Ease.OutQuart);

            yield return new WaitForSeconds(Duration);

            _theEnd.transform.DOScale(Vector3.one, Duration).SetEase(Ease.OutQuart);
        }
    }
}