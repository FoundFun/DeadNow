using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CodeBase
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI _adKeyboard;
        [SerializeField] private TextMeshProUGUI _space;
        [SerializeField] private TextMeshProUGUI _lShift;
        
        private const int DurationAnimation = 2;

        private void Awake() =>
            Reset();

        private IEnumerator Start()
        {
            _adKeyboard.transform.DOScale(Vector3.one, DurationAnimation).SetEase(Ease.OutQuart);

            yield return new WaitForSeconds(DurationAnimation);
        
            _space.transform.DOScale(Vector3.one, DurationAnimation).SetEase(Ease.OutQuart);

            yield return new WaitForSeconds(DurationAnimation);
        
            _lShift.transform.DOScale(Vector3.one, DurationAnimation).SetEase(Ease.OutQuart);

            yield return new WaitForSeconds(DurationAnimation);
            
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        
            while (_canvasGroup.alpha != 0)
            {
                _canvasGroup.alpha -= 0.01f;

                yield return null;
            }
        }

        private void Reset()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            _adKeyboard.transform.localScale = Vector3.zero;
            _space.transform.localScale = Vector3.zero;
            _lShift.transform.localScale = Vector3.zero;
        }
    }
}