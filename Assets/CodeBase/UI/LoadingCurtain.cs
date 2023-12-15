using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Slider _progressSlider;
        [SerializeField] private TextMeshProUGUI _loadingPercent;
        
        private const string StartLoadingPercentText = "0 %";

        private void Awake()
        {
            Reset();
            DontDestroyOnLoad(this);
        }

        private void Reset()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            _loadingPercent.text = StartLoadingPercentText;
            _progressSlider.value = 0;
        }

        public void Show() => 
            StartCoroutine(DoShowIn());

        public void Hide() =>
            StartCoroutine(DoFadeIn());

        private IEnumerator DoShowIn()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            
            while (_progressSlider.value < 1)
            {
                UpdateSlider();
                UpdatePercent();

                yield return null;
            }
        }
        private IEnumerator DoFadeIn()
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= 0.01f;
                
                yield return new WaitForSeconds(0.01f);
            }
      
            gameObject.SetActive(false);
        }

        private void UpdateSlider() =>
            _progressSlider.value += Time.timeScale * 0.0001f;

        private void UpdatePercent() =>
            _loadingPercent.text = $"{Mathf.RoundToInt(_progressSlider.value * 100)} %";
    }
}