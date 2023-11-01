using BasicTemplate.CodeBase.SoundLogic;

namespace BasicTemplate.CodeBase.Services.Sound
{
    public class SoundService : ISoundService
    {
        private const string MasterVolume = "MasterVolume";
        private const float EnableVolume = 0;
        private const float DisableVolume = -80f;

        private readonly SoundView _soundView;
        
        private float _currentVolume;

        public bool IsPlay => _currentVolume == EnableVolume;

        public SoundService(SoundView soundView)
        {
            _soundView = soundView;

            Enable();
        }

        public void Enable() => 
            _soundView.ChangedMusic += ChangeMusic;

        public void Disable() => 
            _soundView.ChangedMusic -= ChangeMusic;

        public void PlayMusic()
        {
            _currentVolume = EnableVolume;
            _soundView.Master.audioMixer.SetFloat(MasterVolume, _currentVolume);
        }

        public void StopMusic()
        {
            _currentVolume = DisableVolume;
            _soundView.Master.audioMixer.SetFloat(MasterVolume, _currentVolume);
        }
        
        private void ChangeMusic(bool isEnabled)
        {
            if (isEnabled)
                StopMusic();
            else
                PlayMusic();
        }
    }
}