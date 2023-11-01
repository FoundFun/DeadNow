namespace BasicTemplate.CodeBase.Services.Sound
{
    public interface ISoundService
    {
        bool IsPlay { get; }
        void PlayMusic();
        void StopMusic();
    }
}