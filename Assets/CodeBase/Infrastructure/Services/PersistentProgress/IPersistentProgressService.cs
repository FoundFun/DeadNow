using CodeBase.Data;
using CodeBase.Services;

namespace CodeBase.Infrastructure.Infrastructure.GameBootstrapper
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}