using System;
using Agava.YandexGames;
using CodeBase.Infrastructure.Services.Sound;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Yandex
{
    public class YandexRewardVideoService : IYandexRewardVideoService
    {
        private readonly ISoundService _soundService;
        
        private bool _isChangedMusic;

        public event Action Reward; 

        public YandexRewardVideoService(ISoundService soundService) => 
            _soundService = soundService;

        public void ShowAds() => 
            VideoAd.Show(StopGame,AddReward, ResumeGame);

        private void AddReward() => 
            Reward?.Invoke();

        private void StopGame()
        {
            Time.timeScale = 0;

            if (!_soundService.IsPlay)
                return;
            
            _soundService.StopMusic();
            _isChangedMusic = true;
        }

        private void ResumeGame()
        {
            Time.timeScale = 1;

            if (!_isChangedMusic) 
                return;
            
            _soundService.PlayMusic();
            _isChangedMusic = false;
        }
    }
}