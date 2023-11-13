using BasicTemplate.CodeBase.Services.Yandex;
using UnityEngine;
using UnityEngine.UI;

namespace BasicTemplate.CodeBase.AdsLogic
{
    public class OneShotRewardAds : MonoBehaviour
    {
        [SerializeField] private Button _adsButton;
        
        private IYandexRewardVideoService _yandexRewardVideoAds;

        public void Construct(IYandexRewardVideoService yandexRewardVideoService) => 
            _yandexRewardVideoAds = yandexRewardVideoService;

        private void OnEnable()
        {
#if YANDEX_GAMES && !UNITY_EDITOR
            _adsButton.onClick.AddListener(_yandexRewardVideoAds.ShowAds);
#endif
        }

        private void OnDisable()
        {
#if YANDEX_GAMES && !UNITY_EDITOR
            _adsButton.onClick.RemoveListener(_yandexRewardVideoAds.ShowAds);
#endif
        }
    }
}