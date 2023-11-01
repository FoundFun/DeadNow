using Agava.WebUtility;
using BasicTemplate.CodeBase.Services.Sound;
using UnityEngine;

namespace BasicTemplate.CodeBase.Infrastructure
{
    public class YandexBackgroundChanger : MonoBehaviour
    {
        private ISoundService _soundService;

        private bool _isChangedMusic;

        public void Construct(ISoundService soundService)
        {
            _soundService = soundService;
        }

        private void OnEnable() =>
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;

        private void OnDisable() =>
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;

        private void OnInBackgroundChange(bool inBackground)
        {
            if (inBackground)
            {
                Time.timeScale = 0;

                if (!_soundService.IsPlay)
                    return;

                _isChangedMusic = true;
                _soundService.StopMusic();
            }

            if (!inBackground)
            {
                Time.timeScale = 1;

                if (!_isChangedMusic)
                    return;

                _isChangedMusic = false;
                _soundService.PlayMusic();
            }
        }
    }
}