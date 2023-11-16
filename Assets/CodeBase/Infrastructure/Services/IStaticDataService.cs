using CodeBase.Services;
using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services
{
    public interface IStaticDataService : IService
    {
        void Load();
        EnemyStaticData ForMonster(EnemyTypeId typeId);
        LevelStaticData ForLevel(string sceneKey);
    }
}