namespace CodeBase.Infrastructure.Services.Sound
{
    public interface ISoundService
    {
        bool IsPlay { get; }
        void PlayMusic();
        void StopMusic();
    }
}