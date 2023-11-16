using CodeBase.Data;

namespace CodeBase.Infrastructure.Infrastructure.GameBootstrapper
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}