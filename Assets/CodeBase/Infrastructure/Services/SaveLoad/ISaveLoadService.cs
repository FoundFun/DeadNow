using CodeBase.Data;
using CodeBase.Services;

namespace CodeBase.Infrastructure.Infrastructure.GameBootstrapper
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}