using System;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;
        public KillData KillData;

        public PlayerProgress(string initialLevel)
        {
            WorldData = new WorldData(initialLevel);
            KillData = new KillData();
        }
    }
}