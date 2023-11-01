using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Enemy
{
    public class EnemySpeaker : MonoBehaviour
    {
        [SerializeField] private Text _dead;
        [SerializeField] private Text _tutorial;
        
        private const float TargetSize = 0.01f;
        private const int ShowTime = 4;

        private Coroutine _coroutine;

        public Text Dead => _dead;
        public Text Tutorial => _tutorial;

        public void ShowText(Text text)
        {
            if (_coroutine != null)
                StartCoroutine(OnShowTwoText(text));
            else
                _coroutine = StartCoroutine(OnShowText(text));
        }

        private IEnumerator OnShowText(Text text)
        {
            text.gameObject.LeanScale(new Vector3(TargetSize, TargetSize, TargetSize), 1).setEaseOutBounce();

            yield return new WaitForSeconds(ShowTime);

            text.gameObject.LeanScale(Vector3.zero, 1).setEaseOutBounce();
        }

        private IEnumerator OnShowTwoText(Text text)
        {
            text.gameObject.LeanScale(new Vector3(TargetSize, TargetSize, TargetSize), 1).setEaseOutBounce();

            yield return new WaitForSeconds(ShowTime);

            text.gameObject.LeanScale(Vector3.zero, 1).setEaseOutBounce();
        }
    }
}