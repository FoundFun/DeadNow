using CodeBase.Infrastructure.Services.Yandex;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.AdsLogic
{
    public class RewardCounterAds : MonoBehaviour
    {
        [SerializeField] private Button _adsButton;
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _scoreText;

        private const int TargetCount = 3;
        private const string Slash = "/";

        private IYandexRewardVideoService _yandexRewardVideoAds;
        private int _counter;

        public void Construct(IYandexRewardVideoService yandexRewardVideoService) =>
            _yandexRewardVideoAds = yandexRewardVideoService;

        private void OnEnable()
        {
#if YANDEX_GAMES && !UNITY_EDITOR
            _adsButton.onClick.AddListener(_yandexRewardVideoAds.ShowAds);
            _yandexRewardVideoAds.Reward += MoveReward;
#endif
        }

        private void OnDisable()
        {
#if YANDEX_GAMES && !UNITY_EDITOR
            _adsButton.onClick.RemoveListener(_yandexRewardVideoAds.ShowAds);
            _yandexRewardVideoAds.Reward -= MoveReward;
#endif
        }

        private void MoveReward()
        {
            if (_counter >= TargetCount)
                Reward();
            else
                _counter++;

            _scoreText.text = $"{_counter} {Slash} {TargetCount}";
        }

        private void Reward()
        {
        }
    }
}