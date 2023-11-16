using CodeBase.Data;

namespace CodeBase.Infrastructure.Infrastructure.GameBootstrapper
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}