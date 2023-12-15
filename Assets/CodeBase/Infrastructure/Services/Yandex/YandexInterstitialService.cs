using Agava.YandexGames;
using CodeBase.Infrastructure.Services.Sound;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Yandex
{
    public class YandexInterstitialService : IYandexInterstitialService
    {
        private readonly ISoundService _soundService;
        private bool _isChangedMusic;

        public YandexInterstitialService(ISoundService soundService) => 
            _soundService = soundService;

        public void Show() => 
            OnShowInterstitialButtonClick();

        private void OnShowInterstitialButtonClick() => 
            InterstitialAd.Show(StopGame, StartGame);

        private void StartGame(bool wasShow)
        {
            if (!wasShow)
                return;

            ResumeGame();
        }

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