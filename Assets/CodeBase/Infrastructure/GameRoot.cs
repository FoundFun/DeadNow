using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.AdsLogic;
using CodeBase.Infrastructure.Services.Sound;
using CodeBase.Infrastructure.Services.Yandex;
using CodeBase.Infrastructure.SoundLogic;
using CodeBase.Infrastructure.Yandex;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameRoot : MonoBehaviour
    {
        [Header("YandexButtons")] [SerializeField]
        private List<OneShotRewardAds> _rewardAds;

        [SerializeField] private List<InterstitialAds> _interstitialAds;
        [SerializeField] private List<RewardCounterAds> _rewardCounterAds;

        [Space] [SerializeField] private YandexLeaderBoardView _leaderBoardView;
        [SerializeField] private YandexAuthorizationView _authorizationView;
        [SerializeField] private FocusObserver _focusObserver;
        [SerializeField] private SoundView _soundView;

        private IYandexLeaderBoardService _leaderBoardService;

        private void Awake()
        {
            ISoundService soundService = new SoundService(_soundView);
            IYandexAuthorizationService authorizationService = new YandexAuthorizationService(_authorizationView);
            IYandexInterstitialService interstitialService = new YandexInterstitialService(soundService);
            IYandexRewardVideoService rewardRewardVideoService = new YandexRewardVideoService(soundService);

            _leaderBoardService =
                new YandexLeaderBoardService(_leaderBoardView, authorizationService);
            
            PlayerData playerData = new PlayerData(_leaderBoardService);

            RewardInitialization(rewardRewardVideoService);
            InterstitialInitialization(interstitialService);

            _focusObserver.Construct(soundService);

            DontDestroyOnLoad(this);
        }

        private void InterstitialInitialization(IYandexInterstitialService interstitialService)
        {
            foreach (InterstitialAds interstitialAds in _interstitialAds)
                interstitialAds.Construct(interstitialService);
        }

        private void RewardInitialization(IYandexRewardVideoService rewardRewardVideoService)
        {
            foreach (OneShotRewardAds rewardAds in _rewardAds)
                rewardAds.Construct(rewardRewardVideoService);

            foreach (RewardCounterAds rewardCounterAds in _rewardCounterAds)
                rewardCounterAds.Construct(rewardRewardVideoService);
        }
    }
}