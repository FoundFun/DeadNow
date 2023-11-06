using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemySpeaker : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dead;
        [SerializeField] private TextMeshProUGUI _tutorial;

        private const float TargetSize = 0.01f;
        private const int ShowTime = 4;
        private const int Duration = 1;

        private Coroutine _coroutine;

        public TextMeshProUGUI Dead => _dead;
        public TextMeshProUGUI Tutorial => _tutorial;

        private void Start() => 
            Reset();

        public void Reset()
        {
            _dead.transform.DOScale(Vector3.zero, Duration);
            _tutorial.transform.DOScale(Vector3.zero, Duration);
        }

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