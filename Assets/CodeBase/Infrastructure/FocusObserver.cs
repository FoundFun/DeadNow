using Agava.WebUtility;
using CodeBase.Infrastructure.Services.Sound;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class FocusObserver : MonoBehaviour
    {
        private ISoundService _soundService;

        private bool _isChangedMusic;

        public void Construct(ISoundService soundService) =>
            _soundService = soundService;

        private void OnEnable()
        {
            Application.focusChanged += OnInBackgroundChange;
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
        }

        private void OnDisable()
        {
            Application.focusChanged -= OnInBackgroundChange;
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        }

        private void OnInBackgroundChange(bool inBackground)
        {
            PauseGame(inBackground);
            MuteAudio();
        }

        private static void PauseGame(bool value) =>
            Time.timeScale = value ? 0 : 1;

        private void MuteAudio()
        {
            if (_soundService.IsPlay)
            {
                _isChangedMusic = true;
                _soundService.StopMusic();
                
                return;
            }

            if (!_isChangedMusic)
                return;
            
            _isChangedMusic = false;
            _soundService.PlayMusic();
        }
    }
}