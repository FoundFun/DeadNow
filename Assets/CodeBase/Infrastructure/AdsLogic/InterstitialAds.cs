using CodeBase.Infrastructure.Services.Yandex;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.AdsLogic
{
    public class InterstitialAds : MonoBehaviour
    {
        [SerializeField] private Button _adsButton;
        
        private IYandexInterstitialService _yandexInterstitial;

        public void Construct(IYandexInterstitialService yandexInterstitial) => 
            _yandexInterstitial = yandexInterstitial;

        private void OnEnable()
        {
#if YANDEX_GAMES && !UNITY_EDITOR
            _adsButton.onClick.AddListener(_yandexInterstitial.Show);
#endif
        }

        private void OnDisable()
        {
#if YANDEX_GAMES && !UNITY_EDITOR
            _adsButton.onClick.RemoveListener(_yandexInterstitial.Show);
#endif
        }
    }
}