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
        
        private Coroutine _coroutine;

        public TextMeshProUGUI Dead => _dead;
        public TextMeshProUGUI Tutorial => _tutorial;

        private void Start() => 
            Reset();

        public void Reset()
        {
            _dead.transform.DOScale(Vector3.zero, 0);
            _tutorial.transform.DOScale(Vector3.zero, 0);
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
            message.transform.DOScale(new Vector3(TargetSize, TargetSize, TargetSize), 1).SetEase(Ease.OutQuart);

            yield return new WaitForSeconds(ShowTime);

            message.transform.DOScale(Vector3.zero, 1).SetEase(Ease.OutQuart);
        }
    }
}