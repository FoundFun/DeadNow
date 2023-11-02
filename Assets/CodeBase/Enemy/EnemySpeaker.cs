using System.Collections;
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

        public void ShowText(TextMeshProUGUI message)
        {
            if (_coroutine != null)
                StartCoroutine(OnShowTwoText(message));
            else
                _coroutine = StartCoroutine(OnShowText(message));
        }

        private IEnumerator OnShowText(TextMeshProUGUI message)
        {
            message.gameObject.LeanScale(new Vector3(TargetSize, TargetSize, TargetSize), 1).setEaseOutBounce();

            yield return new WaitForSeconds(ShowTime);

            message.gameObject.LeanScale(Vector3.zero, 1).setEaseOutBounce();
        }

        private IEnumerator OnShowTwoText(TextMeshProUGUI message)
        {
            message.gameObject.LeanScale(new Vector3(TargetSize, TargetSize, TargetSize), 1).setEaseOutBounce();

            yield return new WaitForSeconds(ShowTime);

            message.gameObject.LeanScale(Vector3.zero, 1).setEaseOutBounce();
        }
    }
}