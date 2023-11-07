using BasicTemplate.CodeBase.SoundLogic;
using UnityEngine;

namespace BasicTemplate.CodeBase.Services.Sound
{
    public class SoundService : ISoundService
    {
        private readonly SoundView _soundView;
        
        private float _currentVolume;

        public bool IsPlay => AudioListener.volume == 1;

        public SoundService(SoundView soundView)
        {
            _soundView = soundView;

            _soundView.ChangedMusic += ChangeMusic;
        }

        ~SoundService() => 
            _soundView.ChangedMusic -= ChangeMusic;

        public void PlayMusic() => 
            AudioListener.volume = 0;

        public void StopMusic() => 
            AudioListener.volume = 1;

        private void ChangeMusic(bool isEnabled)
        {
            if (isEnabled)
                StopMusic();
            else
                PlayMusic();
        }
    }
}