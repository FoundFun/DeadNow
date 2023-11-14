namespace CodeBase.Infrastructure.Infrastructure.GameBootstrapper
{
    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
}